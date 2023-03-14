using ClinicaSite.Models;

namespace ClinicaSite.Services.RegistrationService.Interfaces
{
    public interface IRegistrationService
    {
        Task<string> RegisterUser(RegistrationModel registrationUser);
    }
}