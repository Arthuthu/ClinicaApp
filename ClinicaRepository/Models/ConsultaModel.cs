﻿namespace ClinicaRepository.Models;

public class ConsultaModel
{
    public Guid Id { get; set; }
    public DateTime Data { get; set; }
    public string? Descricao { get; set; }
	public string? PacienteCel { get; set; }
	public string? PacienteNome { get; set; }

    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public Guid PacienteId { get; set; }
    public Guid ClinicaId { get; set; }
}
