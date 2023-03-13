using ClinicaRepository.Models;

namespace ClinicaService.Interfaces
{
    public interface IClinicaClassService
    {
        Task<IList<string>> CreateClinica(ClinicaModel clinica);
        Task DeleteClinica(Guid id);
        Task<IEnumerable<ClinicaModel>> GetAllClinicas();
        Task<ClinicaModel?> GetClinicaById(Guid id);
        Task<string> Login(ClinicaModel clinica);
        Task UpdateClinica(ClinicaModel comentario);
    }
}