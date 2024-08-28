using FluentValidation;
using PD324_01.Models;

namespace PD324_01.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Поле не може бути порожнім")
                .NotNull().WithMessage("Поле не може бути порожнім")
                .MinimumLength(2).WithMessage("Ім'я повинне містити мінімум 2 літери");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Поле не може бути порожнім")
                .NotNull().WithMessage("Поле не може бути порожнім")
                .MinimumLength(10).WithMessage("Ім'я повинне містити мінімум 10 літер");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Поле не може бути порожнім")
                .NotNull().WithMessage("Поле не може бути порожнім");
        }
    }
}