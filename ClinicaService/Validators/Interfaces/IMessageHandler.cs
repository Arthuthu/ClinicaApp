using ClinicaRepository.Models;

namespace ClinicaService.Validators.Interfaces
{
    public interface IMessageHandler
    {
        Task<IList<string>> ValidateClinicaRegistration(ClinicaModel clinicaData);
        Task<IList<string>> ValidatePacienteRegistration(PacienteModel pacienteData);
        Task<string> ConcatRegistrationMessages(IList<string> responseMessages);

	}
}