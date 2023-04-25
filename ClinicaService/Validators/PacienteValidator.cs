using ClinicaRepository.Models;
using FluentValidation;

namespace ClinicaService.Validators;

public class PacienteValidator : AbstractValidator<PacienteModel>
{
    public PacienteValidator()
    {
        RuleFor(x => x.NomeCompleto)
            .NotEmpty().WithMessage("O campo nome precisa ser preenchido")
            .MaximumLength(100).WithMessage("Os caracteres nao podem ultrapassar 100");

        RuleFor(x => x.CPF)
            .MaximumLength(16).WithMessage("CPF não pode conter mais que 16 caracteres");

        RuleFor(x => x.CEP)
            .MaximumLength(12).WithMessage("O CEP não pode ultrapassar 12 caracteres");

        RuleFor(x => x.Estado)
            .MaximumLength(20).WithMessage("O Estado não pode ultrapassar 20 caracteres");

        RuleFor(x => x.Cidade)
            .MaximumLength(50).WithMessage("A cidade não pode ultrapassar 50 caracteres");

        RuleFor(x => x.Rua)
            .MaximumLength(50).WithMessage("A rua não pode ultrapassar 50 caracteres");

        RuleFor(x => x.NumeroRua)
            .MaximumLength(5).WithMessage("O numero da rua não pode ultrapassar 5 caracteres");

        RuleFor(x => x.Email)
            .MaximumLength(50).WithMessage("O email não pode ultrapassar 50 caracteres");

        RuleFor(x => x.Cel)
            .MaximumLength(15).WithMessage("O celular mão pode ultrapssar 15 caracteres");
    }
}
