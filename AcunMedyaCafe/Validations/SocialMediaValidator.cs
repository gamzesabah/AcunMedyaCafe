using AcunMedyaCafe.Entities;
using FluentValidation;

namespace AcunMedyaCafe.Validations
{
    public class SocialMediaValidator : AbstractValidator<SocialMedia>
    {
        public SocialMediaValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Platform Adı Boş Geçilemez!");

            RuleFor(x => x.AccountUrl).NotEmpty().WithMessage("Hesap Linki Boş Geçilemez!");

            RuleFor(x => x.IconUrl).NotEmpty().WithMessage("Resim Boş Geçilemez!");
        }
    }
}