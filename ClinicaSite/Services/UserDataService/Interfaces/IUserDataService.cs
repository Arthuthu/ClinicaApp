using ClinicaSite.Models;

namespace ClinicaSite.Services.UserDataService.Interfaces
{
    public interface IUserDataService
    {
        Task<Guid> GetLoggedInUserId();
        Task<ClinicaModel> GetClinicaModel(Guid id);
        Task<string> UpdateClinica(ClinicaModel clinica);
    }
}