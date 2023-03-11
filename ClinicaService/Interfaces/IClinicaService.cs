using ClinicaRepository.Models;

namespace ClinicaService.Interfaces
{
    public interface IClinicaClassService
    {
        Task CreateClinica(ClinicaModel comentario);
        Task DeleteClinica(Guid id);
        Task<IEnumerable<ClinicaModel>> GetAllClinicas();
        Task<ClinicaModel?> GetClinicaById(Guid id);
        Task UpdateClinica(ClinicaModel comentario);
    }
}