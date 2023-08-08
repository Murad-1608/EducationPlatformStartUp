using Entity.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class SupportQuestionValidator : AbstractValidator<SupportQuestionDto>
    {
        public SupportQuestionValidator()
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage("Sual boş keçilə bilməz");
        }
    }
}
