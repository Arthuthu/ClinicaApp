using ClinicaRepository.Interfaces;
using ClinicaRepository.Models;
using ClinicaRepository.SqlDataAccess;

namespace ClinicaRepository.Classes;

public class ConsultaRepository : IConsultaRepository
{
    private readonly ISqlDataAccess _db;

    public ConsultaRepository(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<ConsultaModel>> GetAllConsultas(Guid clinicaId)
    {
        return _db.LoadData<ConsultaModel, dynamic>("dbo.spConsulta_GetAll", 
            new { clinicaId });
    }

    public async Task<ConsultaModel?> GetConsultaById(Guid id)
    {
        var results = await _db.LoadData<ConsultaModel, dynamic>(
            "dbo.spConsulta_GetById",
            new { Id = id });

        return results.FirstOrDefault();
    }

	public Task<IEnumerable<ConsultaModel>> GetConsultasByPacienteId(Guid clinicaId, Guid pacienteId)
	{
        return _db.LoadData<ConsultaModel, dynamic>("dbo.spConsulta_GetConsultasByPacienteId",
            new { clinicaId, pacienteId });
    }
	public Task CreateConsulta(ConsultaModel consulta)
    {
        return _db.SaveData("dbo.spConsulta_Add",
        new
        {
            consulta.Id,
            consulta.Data,
            consulta.Descricao,
            consulta.CreatedDate,
            consulta.PacienteId,
            consulta.ClinicaId
        });
    }

    public Task UpdateConsulta(ConsultaModel consulta)
    {
        return _db.SaveData("dbo.spConsulta_Update", new
        {
            consulta.Id,
            consulta.Data,
            consulta.Descricao,
            consulta.UpdatedDate
        });

    }

    public Task DeleteConsulta(Guid id)
    {
        return _db.SaveData("dbo.spConsulta_Delete", new { Id = id });
    }
}
