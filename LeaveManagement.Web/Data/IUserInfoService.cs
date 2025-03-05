namespace LeaveManagement.Web.Data
{
    public interface IUserInfoService
    {
        Task<ApplicationUser> GetUser();
    }
}