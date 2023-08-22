namespace ClinicaSite.Models;

public class ClinicaModel
{
	public Guid Id { get; set; }
	public string Name { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
