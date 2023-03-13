using ClinicaRepository.Models;

namespace ClinicaService.Validators.Interfaces
{
    public interface IMessageHandler
    {
        Task<IList<string>> ValidateClinicaRegistration(ClinicaModel clinicaData);
        Task<string> ConcatRegistrationMessages(IList<string> responseMessages);

	}
}