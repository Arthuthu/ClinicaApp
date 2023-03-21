using ClinicaSite.Models;

namespace ClinicaSite.Services.PacienteService.Interfaces;

public interface IPacienteService
{
    Task<IList<PacienteModel>?> GetAllPacientes(Guid clinicaId);

    Task<string> RegisterPaciente(PacienteModel paciente);
}
