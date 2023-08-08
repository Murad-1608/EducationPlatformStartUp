using Entity.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class SupportAnswerValidator : AbstractValidator<SupportAnswerDto>
    {
        public SupportAnswerValidator()
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage("Cavab boş keçilə bilməz");
            RuleFor(x => x.QuestionId).NotEmpty().WithMessage("Cavab boş keçilə bilməz");
        }
    }
}
