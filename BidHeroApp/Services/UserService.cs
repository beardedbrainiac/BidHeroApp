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
                //var users = await _context.VwUsers.ToListAsync();
                //return _mapper.Map<List<UserViewModel>>(users);

                var userViewModelList = _context.Users
                  .Select(x => new UserViewModel()
                  {
                      Id = Guid.Parse(x.Id),
                      Email = x.Email,
                      FamilyName = x.FamilyName,
                      GivenName = x.GivenName,
                      IsAdmin = false,
                  })
                  .ToList();
                if (userViewModelList != null && userViewModelList.Any())
                {
                    var adminRole = _context.Roles.First(x => x.Name == "Administrator");
                    if (adminRole != null)
                    {
                        foreach (var userViewModel in userViewModelList)
                        {
                            userViewModel.IsAdmin = _context.UserRoles.Any(x => x.UserId == userViewModel.Id.ToString() && x.RoleId == adminRole.Id);
                        }
                    }
                }

                return userViewModelList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task ToggleAdminRoleAsync(string userId)
        {
            try
            {
                await _context.Database.ExecuteSqlInterpolatedAsync($"spToggleAdminRole @UserId={userId}");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
