namespace ClinicaApi.Response;

public class ConsultaResponse
{
    public Guid Id { get; set; }
    public DateTime Data { get; set; }
    public string? Descricao { get; set; }

    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public Guid PacienteId { get; set; }
}
