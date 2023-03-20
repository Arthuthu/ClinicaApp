using ClinicaSite.Models;

namespace ClinicaSite.Services.PacienteService.Interfaces;

public interface IPacienteService
{
	Task<string> RegisterPaciente(PacienteModel paciente);
}
