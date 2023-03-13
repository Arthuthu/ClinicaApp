using ClinicaRepository.Models;
using FluentValidation;

namespace ClinicaService.Validators;

public class ClinicaValidator : AbstractValidator<ClinicaModel>
{
    public ClinicaValidator()
    {
		RuleFor(x => x.Username)
			.NotEmpty().WithMessage("O campo nome precisa ser preenchido")
			.MaximumLength(50).WithMessage("Os caracteres nao podem ultrapssar 50");

		RuleFor(x => x.Password)
			.NotEmpty().WithMessage("O campo senha precisa ser preenchido")
			.MinimumLength(8).WithMessage("A senha precisa ter no minimo 8 caracters")
			.MaximumLength(20).WithMessage("A senha não pode ultrapassar 20 caracteres");
	}
}
