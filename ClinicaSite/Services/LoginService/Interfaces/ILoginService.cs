using ClinicaSite.Models;

namespace ClinicaSite.Services.LoginService.Interfaces
{
    public interface ILoginService
    {
        Task<AuthenticatedUserModel> Login(AuthenticationUserModel userForAuthentication);
        Task Logout();
    }
}