namespace ClinicaRepository.Models;

public class PacienteModel
{
	public Guid Id { get; set; }
	public string? Name { get; set; }
	public string? LastName { get; set; }
	public DateTime? CreatedDate { get; set; }
	public DateTime? UpdatedDate { get; set; }
}
