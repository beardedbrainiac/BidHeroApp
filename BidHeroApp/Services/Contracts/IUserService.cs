using BidHeroApp.ViewModels;

namespace BidHeroApp.Services.Contracts
{
    public interface IUserService
    {
        Task<IList<UserViewModel>> ListAsync();
        Task ToggleAdminRoleAsync(string userId);
    }
}
