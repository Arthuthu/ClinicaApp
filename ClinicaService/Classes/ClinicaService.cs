using ClinicaRepository.Interfaces;
using ClinicaRepository.Models;
using ClinicaService.Interfaces;

namespace ClinicaService.Classes;

public class ClinicaClassService : IClinicaClassService
{
	private readonly IClinicaClassRepository _clinicaRepository;

	public ClinicaClassService(IClinicaClassRepository comentarioRepository)
	{
		_clinicaRepository = comentarioRepository;
	}

	public Task<IEnumerable<ClinicaModel>> GetAllClinicas()
	{
		return _clinicaRepository.GetAllClinicas();
	}

	public async Task<ClinicaModel?> GetClinicaById(Guid id)
	{
		return await _clinicaRepository.GetClinicaById(id);
	}

	public async Task CreateClinica(ClinicaModel comentario)
	{
		comentario.Id = Guid.NewGuid();
		comentario.CreatedDate = DateTime.UtcNow.AddHours(-3);
		await _clinicaRepository.CreateClinica(comentario);
	}

	public Task UpdateClinica(ClinicaModel comentario)
	{
		comentario.UpdatedDate = DateTime.UtcNow.AddHours(-3);
		return _clinicaRepository.UpdateClinica(comentario);
	}

	public Task DeleteClinica(Guid id)
	{
		return _clinicaRepository.DeleteClinica(id);
	}
}
