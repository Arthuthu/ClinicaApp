namespace ClinicaApi.Request;

public class ConsultaRequest
{
    public DateTime Data { get; set; }
    public string? Descricao { get; set; }

    public Guid PacienteId { get; set; }
    public Guid ClinicaId { get; set; }
}
