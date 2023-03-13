using ClinicaRepository.Models;

namespace ClinicaRepository.Interfaces
{
    public interface IClinicaClassRepository
    {
        Task CreateClinica(ClinicaModel clinica);
        Task DeleteClinica(Guid id);
        Task<IEnumerable<ClinicaModel>> GetAllClinicas();
        Task<ClinicaModel?> GetClinicaById(Guid id);
        Task<ClinicaModel?> GetClinicaByName(ClinicaModel clinica);

		Task UpdateClinica(ClinicaModel clinica);
    }
}