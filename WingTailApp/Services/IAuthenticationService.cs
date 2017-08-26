namespace WingTailApp.Services
{
    public interface IUserAuthenticationService
    {
        UserAccount IsValidUser(string tenantName, string userName, string password);
    }
}