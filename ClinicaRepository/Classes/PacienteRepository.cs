using ClinicaRepository.Interfaces;
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
		return _db.LoadData<PacienteModel, dynamic>("dbo.spPaciente_GetAll", new { });
	}

	public async Task<PacienteModel?> GetPacientesId(Guid id)
	{
		var results = await _db.LoadData<PacienteModel, dynamic>(
			"dbo.spPaciente_GetById",
			new { Id = id });

		return results.FirstOrDefault();
	}

	public async Task<PacienteModel?> GetPacienteByCPF(Guid clinicaId, string CPF)
	{
		var results = await _db.LoadData<PacienteModel, dynamic>(
			"dbo.spPaciente_GetByCPF",
			new { clinicaId = clinicaId, CPF = CPF });

		return results.FirstOrDefault();
	}

	public async Task<PacienteModel?> GetPacientesByName(PacienteModel paciente)
	{
		var results = await _db.LoadData<PacienteModel, dynamic>(
			"dbo.spPaciente_GetByName",
			new { Username = paciente.Nome });

		return results.FirstOrDefault();
	}

	public Task AddPaciente(PacienteModel paciente)
	{
		return _db.SaveData("dbo.spPaciente_Add",
		new
		{
            paciente.Id,
            paciente.Nome,
            paciente.Sobrenome,
            paciente.CPF,
            paciente.CEP,
            paciente.Estado,
            paciente.Cidade,
            paciente.Rua,
            paciente.Bairro,
            paciente.NumeroRua,
            paciente.Email,
            paciente.Cel,
            paciente.CreatedDate,
            paciente.ClinicaId
        });
	}

	public Task UpdatePaciente(PacienteModel paciente)
	{
		return _db.SaveData("dbo.spPaciente_Update", new
		{
            paciente.Id,
            paciente.Nome,
            paciente.Sobrenome,
            paciente.CPF,
            paciente.CEP,
            paciente.Estado,
            paciente.Cidade,
            paciente.Rua,
            paciente.Bairro,
            paciente.NumeroRua,
            paciente.Email,
            paciente.Cel,
            paciente.UpdatedDate,
            paciente.ClinicaId
        });

	}

	public Task DeletePaciente(Guid id)
	{
		return _db.SaveData("dbo.spPaciente_Delete", new { Id = id });
	}
}
