namespace ClinicaRepository.Models;

public class ClinicaModel
{
	public Guid Id { get; set; }
	public string? Name { get; set; }
	public string? Username { get; set; }
	public string? Password { get; set; }

	public byte[]? PasswordHash { get; set; }
	public byte[]? PasswordSalt { get; set; }


	public DateTime? CreatedDate { get; set; }
	public DateTime? UpdatedDate { get; set; }

	public Guid ClinicaId { get; set; }
}
