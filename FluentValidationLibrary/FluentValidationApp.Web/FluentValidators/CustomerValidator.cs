using FluentValidation;
using FluentValidationApp.Web.Models;
using System;

namespace FluentValidationApp.Web.FluentValidators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public string NotEmptyMessage { get; } = "{PropertyName} alanı boş olamaz";
        public CustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.Email).NotEmpty().WithMessage(NotEmptyMessage)
               .EmailAddress().WithMessage("Email alanı doğru formatta olmalıdır. ");
            RuleFor(x => x.Age).NotEmpty().WithMessage(NotEmptyMessage).InclusiveBetween(18, 60).WithMessage("Age alanı 18-60 arasında olmalıdır.");
            RuleFor(x => x.BirthDay).NotEmpty().WithMessage(NotEmptyMessage).Must(x =>
            {
                return DateTime.Now.AddYears(-18) >= x;
            }).WithMessage("Yaşınız 18 yaşından büyük olmalıdır.");
            RuleFor(x=> x.Gender).IsInEnum().WithMessage("{PropertyName} alanı Erkek=1, Bayan=2 olamalıdır.");

            RuleForEach(x=>x.Addresses).SetValidator(new AddressValidator());
        }
    }
}
