using BreakevenStoneApi.Controllers.Requests.ProductRequests;
using FluentValidation;

namespace BreakevenStoneApi.Controllers.Requests.Validators.ProductValidators
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2);
        }
    }
}
