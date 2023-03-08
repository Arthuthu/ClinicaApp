namespace ClinicaRepository.Models;

public class ClinicaModel
{
	public Guid Id { get; set; }
	public string? Name { get; set; }
	public string? User { get; set; }
	public string? Password { get; set; }
	public DateTime? CreatedDate { get; set; }
	public DateTime? UpdatedDate { get; set; }
}
