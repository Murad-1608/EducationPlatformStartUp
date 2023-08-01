using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class SubCategoryValidator : AbstractValidator<SubCategory>
    {
        public SubCategoryValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Ad boş keçilə bilməz");
        }
    }
}
