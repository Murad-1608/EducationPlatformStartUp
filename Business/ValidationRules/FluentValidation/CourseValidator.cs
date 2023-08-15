using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CourseValidator : AbstractValidator<Course>
    {
        public CourseValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Ad boş keçilə bilməz");
            RuleFor(c => c.Description).NotEmpty().WithMessage("Kurs açığlaması boş keçilə bilməz");
            RuleFor(c => c.Image).NotEmpty().WithMessage("Şəkil boş qoyula bilməz");
            RuleFor(c => c.Spoiler).NotEmpty().WithMessage("Spoyler boş qoyula bilməz");
            RuleFor(c => c.Language).NotEmpty().WithMessage("Dil bölməsi boş keçilə bilməz");
            RuleFor(c => c.Price).NotEmpty().WithMessage("Qiymət boş keçilə bilməz");
            //RuleFor(c => c.Category).NotEmpty().WithMessage("Kateqoriya seçmək mütləqdir");
            RuleFor(c => c.SubCategory).NotEmpty().WithMessage("Alt Kateqoriya seçmək mütləqdir");
            RuleFor(c => c.LessonTitles).NotEmpty().WithMessage("Dərs başlıqları boş keçilə bilməz");
        }
    }
}
