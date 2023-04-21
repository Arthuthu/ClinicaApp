namespace ClinicaSite.Models;

public class ConsultaModel
{
    public Guid Id { get; set; }
    public DateTime Data { get; set; } = DateTime.Today;
    public string? Descricao { get; set; }
    
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public Guid PacienteId { get; set; }
    public Guid ClinicaId { get; set; }

}
