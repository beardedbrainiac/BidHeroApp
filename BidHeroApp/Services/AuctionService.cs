using AutoMapper;
using BidHeroApp.Data;
using BidHeroApp.Extensions;
using BidHeroApp.Services.Contracts;
using BidHeroApp.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BidHeroApp.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public AuctionService(
            IMapper mapper,
            ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IList<AuctionItemViewModel>> ListAsync(int? categoryId)
        {
            try
            {
                var items = new List<AuctionItemViewModel>();

                using (var connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
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
