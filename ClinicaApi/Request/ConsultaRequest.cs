namespace ClinicaApi.Request;

public class ConsultaRequest
{
    public Guid Id { get; set; }
    public DateTime Data { get; set; }
    public string? Descricao { get; set; }
    public string? PacienteCel { get; set; }
    public string? PacienteNome { get; set; }

    public Guid PacienteId { get; set; }
    public Guid ClinicaId { get; set; }
}
