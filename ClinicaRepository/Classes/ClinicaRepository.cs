using ClinicaRepository.Interfaces;
using ClinicaRepository.Models;
using ClinicaRepository.SqlDataAccess;

namespace ClinicaRepository.Classes;

public class ClinicaClassRepository : IClinicaClassRepository
{
	private readonly ISqlDataAccess _db;

	public ClinicaClassRepository(ISqlDataAccess db)
	{
		_db = db;
	}

	public Task<IEnumerable<ClinicaModel>> GetAllClinicas()
	{
		return _db.LoadData<ClinicaModel, dynamic>("dbo.spClinicas_GetAll", new { });
	}

	public async Task<ClinicaModel?> GetClinicaById(Guid id)
	{
		var results = await _db.LoadData<ClinicaModel, dynamic>(
			"dbo.spClinicas_GetById",
			new { Id = id });

		return results.FirstOrDefault();
	}

	public async Task<ClinicaModel?> GetClinicaByName(ClinicaModel clinica)
	{
		var results = await _db.LoadData<ClinicaModel, dynamic>(
			"dbo.spClinicas_GetByUsername",
			new { Username = clinica.Username });

		return results.FirstOrDefault();
	}

	public Task CreateClinica(ClinicaModel clinica)
	{
		return _db.SaveData("dbo.spClinicas_Add",
		new
		{
			clinica.Id,
			clinica.Name,
			clinica.Username,
			clinica.Password,
			clinica.CreatedDate
		});
	}

	public Task UpdateClinica(ClinicaModel clinica)
	{
		return _db.SaveData("dbo.spClinica_Update", new
		{
			clinica.Id,
			clinica.Name,
			clinica.Username,
			clinica.UpdatedDate
		});

	}

	public Task DeleteClinica(Guid id)
	{
		return _db.SaveData("dbo.spClinica_Delete", new { Id = id });
	}
}
