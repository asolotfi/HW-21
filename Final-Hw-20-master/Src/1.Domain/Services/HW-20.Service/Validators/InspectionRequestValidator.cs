using FluentValidation;
using HW_20.Domain.Entites.Car;

public class InspectionRequestValidator : AbstractValidator<InspectionRequest>
{
    public InspectionRequestValidator()
    {
        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("شماره تلفن اجباری است.")
            .Matches(@"^09\d{9}$").WithMessage("فرمت شماره تلفن معتبر نیست.");

        RuleFor(x => x.CodeMeli)
            .NotEmpty().WithMessage("کد ملی اجباری است.")
            .Length(10).WithMessage("کد ملی باید ۱۰ رقم باشد.")
            .Matches(@"^\d{10}$").WithMessage("کد ملی فقط شامل اعداد باشد.");

        RuleFor(x => x.PlateNumber)
            .NotEmpty().WithMessage("شماره پلاک اجباری است.")
            .Matches(@"^\d{2}[\u0600-\u06FF]\d{2,3}-\d{2}$").WithMessage("فرمت شماره پلاک معتبر نیست.");
    }
}

