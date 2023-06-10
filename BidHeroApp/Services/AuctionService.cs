using AutoMapper;
using BidHeroApp.Data;
using BidHeroApp.Extensions;
using BidHeroApp.Hubs;
using BidHeroApp.Models;
using BidHeroApp.Services.Contracts;
using BidHeroApp.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.EventArgs;

namespace BidHeroApp.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;
        private readonly IHubContext<AuctionHub> _hubContext;
        private readonly SqlTableDependency<Bid> _dependency;

        public AuctionService(
            IConfiguration configuration,
            IMapper mapper,
            ApplicationDbContext dbContext,
            IHubContext<AuctionHub> hubContext)
        {
            _configuration = configuration;
            _mapper = mapper;
            _dbContext = dbContext;
            _hubContext = hubContext;
            _dependency = new SqlTableDependency<Bid>(_configuration.GetConnectionString("DefaultConnection"), "Bid");
            _dependency.OnChanged += Changed;
            _dependency.Start();
        }

        private async void Changed(object sender, RecordChangedEventArgs<Bid> e)
        {
            var auctions = await ListAsync(null);
            await _hubContext.Clients.All.SendAsync("RefreshAuctions", auctions);
        }

        public async Task<IList<AuctionItemViewModel>> ListAsync(int? categoryId)
        {
            try
            {
                var items = new List<AuctionItemViewModel>();

                using (var connection = new SqlConnection(_dbContext.Database.GetDbConnection().ConnectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("[dbo].[spCategoryItems]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CategoryId", categoryId);

                        SqlDataReader reader = await command.ExecuteReaderAsync();
                        while (reader.Read())
                        {
                            var item = new AuctionItemViewModel()
                            {
                                Category = new SelectListItem()
                                {
                                    Value = reader.GetValueOrDefault<int>("CategoryId", 0).ToString(),
                                    Text = reader.GetValueOrDefault<string>("CategoryName", string.Empty)
                                },
                                Item = new SelectListItem()
                                {
                                    Value = reader.GetValueOrDefault<int>("ItemId", 0).ToString(),
                                    Text = reader.GetValueOrDefault<string>("ItemName", string.Empty)
                                },
                                Image = reader.GetValueOrDefault<string>("Image", string.Empty),
                                Points = reader.GetValueOrDefault<int>("Points", 0)
                            };

                            items.Add(item);
                        }

                        command.Dispose();
                    }

                    connection.Dispose();
                }

                return items;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
