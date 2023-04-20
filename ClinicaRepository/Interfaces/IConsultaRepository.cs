﻿using ClinicaRepository.Models;

namespace ClinicaRepository.Interfaces
{
    public interface IConsultaRepository
    {
        Task CreateConsulta(ConsultaModel consulta);
        Task DeleteConsulta(Guid id);
        Task<IEnumerable<ConsultaModel>> GetAllConsultas(Guid clinicaId);
        Task<ConsultaModel?> GetConsultaById(Guid id);
        Task UpdateConsulta(ConsultaModel consulta);
    }
}