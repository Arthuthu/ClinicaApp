using ClinicaRepository.Models;
using ClinicaService.Validators.Interfaces;
using FluentValidation;

namespace ClinicaService.Validators;

public class MessageHandler : IMessageHandler
{
	private readonly IValidator<ClinicaModel> _clinicaValidator;

	public MessageHandler(IValidator<ClinicaModel> clinicaValidator)
	{
		_clinicaValidator = clinicaValidator;
	}

	public async Task<IList<string>> ValidateClinicaRegistration(ClinicaModel clinicaData)
	{
		var validationResult = _clinicaValidator.Validate(clinicaData);
		IList<string> validationMessages = new List<string>();

		if (validationResult.IsValid is false)
		{
			foreach (var errors in validationResult.Errors)
			{
				validationMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
			}

			return validationMessages;
		}

		return validationMessages;
	}

	public async Task<string> ConcatRegistrationMessages(IList<string> responseMessages)
	{
		string cleanMessage = string.Join(", ", responseMessages);

		return cleanMessage;
	}
}
