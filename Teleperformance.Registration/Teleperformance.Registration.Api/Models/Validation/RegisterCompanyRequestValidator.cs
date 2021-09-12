using FluentValidation;
using Teleperformance.Registration.Api.Models.Request;

namespace Teleperformance.Registration.Api.Models.Validation
{
    public class RegisterCompanyRequestValidator : AbstractValidator<RegisterCompanyRequest>
    {
        public RegisterCompanyRequestValidator()
        {
            RuleFor(x => x.IdentificationType).InclusiveBetween(0, 5).WithMessage("Id no corresponde");
            RuleFor(x => x.IdentificationNumber).Length(2, 15).WithMessage("Debe contener entre 2 y 15 numeros"); ;
            RuleFor(x => x.Email).EmailAddress().WithMessage("El formato del correo no es válido");
        }
    }
}
