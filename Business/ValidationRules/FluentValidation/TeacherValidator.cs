using Entity.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class TeacherValidator : AbstractValidator<TeacherForRegisterDto>
    {
        public TeacherValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş keçilə bilməz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifrə boş keçilə bilməz");
            RuleFor(x => x.Profession).NotEmpty().WithMessage("İxtisas boş keçilə bilməz");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Ad boş keçilə bilməz");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyad boş keçilə bilməz");
            RuleFor(x => x.InformationVideo).NotEmpty().WithMessage("Video əlavə edin");
        }
    }
}
