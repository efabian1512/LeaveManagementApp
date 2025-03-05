using Microsoft.AspNetCore.Identity;

namespace LeaveManagement.Web.Data
{
    public class UserInfoService(IHttpContextAccessor _httpContextAccessor, UserManager<ApplicationUser> _userManager) : IUserInfoService
    {
        Task<ApplicationUser> IUserInfoService.GetUser()
        {
            return _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
        }
    }
}
