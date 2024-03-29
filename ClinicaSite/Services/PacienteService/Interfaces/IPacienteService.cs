﻿using ClinicaSite.Models;

namespace ClinicaSite.Services.PacienteService.Interfaces;

public interface IPacienteService
{
    Task<IList<PacienteModel>?> GetAllPacientes(Guid clinicaId);
	Task<PacienteModel?> GetPacienteById(Guid pacienteId);
	Task<string> UpdatePaciente(PacienteModel paciente);
	Task<string> RegisterPaciente(PacienteModel paciente);
}
