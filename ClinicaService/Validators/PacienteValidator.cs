using ClinicaRepository.Models;
using FluentValidation;

namespace ClinicaService.Validators;

public class PacienteValidator : AbstractValidator<PacienteModel>
{
    public PacienteValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("O campo nome precisa ser preenchido")
            .MaximumLength(50).WithMessage("Os caracteres nao podem ultrapssar 50");

        RuleFor(x => x.Sobrenome)
            .NotEmpty().WithMessage("O campo sobrenome precisa ser preenchido")
            .MinimumLength(2).WithMessage("A senha precisa ter no minimo 2 caracters")
            .MaximumLength(40).WithMessage("A senha não pode ultrapassar 40 caracteres");
    }
}
