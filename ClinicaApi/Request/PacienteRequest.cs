﻿namespace ClinicaApi.Request;

public class PacienteRequest
{
	public Guid? Id { get; set; }
	public string NomeCompleto { get; set; }
	public string CPF { get; set; }
	public string CEP { get; set; }
	public string Estado { get; set; }
	public string Cidade { get; set; }
	public string Rua { get; set; }
	public string Bairro { get; set; }
	public string NumeroRua { get; set; }
	public string Email { get; set; }
	public string Cel { get; set; }

	public Guid ClinicaId { get; set; }
}
