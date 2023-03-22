namespace ClinicaApi.Response;

public class PacienteResponse
{
	public Guid Id { get; set; }
	public string Nome { get; set; }
	public string Sobrenome { get; set; }
	public string CPF { get; set; }
	public string CEP { get; set; }
	public string Estado { get; set; }
	public string Cidade { get; set; }
	public string Rua { get; set; }
	public string Bairro { get; set; }
	public string NumeroRua { get; set; }
	public string Email { get; set; }
	public string Cel { get; set; }
	public DateTime CreatedDate { get; set; }
	public DateTime UpdatedDate { get; set; }

	public Guid ClinicaId { get; set; }
}
