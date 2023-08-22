namespace ClinicaSite.Models
{
    public class PacienteModel
    {
        public Guid Id { get; set; }
        public string NomeCompleto { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string CEP { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Rua { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string NumeroRua { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Cel { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Guid ClinicaId { get; set; }
    }
}
