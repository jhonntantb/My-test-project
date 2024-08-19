using FluentValidation;

namespace WebApplication2.Features.Products.Commands
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator() {
            RuleFor(r => r.Description).NotNull();
            RuleFor(r => r.Price).NotNull().GreaterThan(0);
        }
    }
}
