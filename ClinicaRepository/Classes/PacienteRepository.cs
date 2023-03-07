using ClinicaRepository.Models;
using ClinicaRepository.SqlDataAccess;

namespace ClinicaRepository.Classes;

public class PacienteRepository : IPacienteRepository
{
	private readonly ISqlDataAccess _db;

	public PacienteRepository(ISqlDataAccess db)
	{
		_db = db;
	}

	public Task<IEnumerable<PacienteModel>> GetAllPacientes()
	{
		return _db.LoadData<PacienteModel, dynamic>("dbo.spPacientes_GetAll", new { });
	}

	public async Task<PacienteModel?> GetPacientesId(Guid id)
	{
		var results = await _db.LoadData<PacienteModel, dynamic>(
			"dbo.spPacientes_GetById",
			new { Id = id });

		return results.FirstOrDefault();
	}

	public async Task<PacienteModel?> GetPacientesByName(PacienteModel paciente)
	{
		var results = await _db.LoadData<PacienteModel, dynamic>(
			"dbo.spPacientes_GetByName",
			new { Username = paciente.Name });

		return results.FirstOrDefault();
	}

	public Task AddPaciente(PacienteModel paciente)
	{
		return _db.SaveData("dbo.spPacientes_Add",
		new
		{
			paciente.Id,
			paciente.Name,
			paciente.LastName,
			paciente.CreatedDate
		});
	}

	public Task UpdatePaciente(PacienteModel paciente)
	{
		return _db.SaveData("dbo.spPaciente_Update", new
		{
			paciente.Id,
			paciente.Name,
			paciente.LastName,
			paciente.UpdatedDate
		});

	}

	public Task DeleteUser(Guid id)
	{
		return _db.SaveData("dbo.spUser_Delete", new { Id = id });
	}
}
