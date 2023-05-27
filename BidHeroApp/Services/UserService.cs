using AutoMapper;
using BidHeroApp.Data;
using BidHeroApp.Services.Contracts;
using BidHeroApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BidHeroApp.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public UserService(
            IMapper mapper,
            ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IList<UserViewModel>> ListAsync()
        {
            try
            {
                var users = await _context.VwUsers.ToListAsync();
                return _mapper.Map<List<UserViewModel>>(users);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
