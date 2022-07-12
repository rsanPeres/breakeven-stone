using BreakevenStoneApi.Controllers.Requests.ProductRequests;
using FluentValidation;

namespace BreakevenStoneApi.Controllers.Requests.Validators.ProductValidators
{
    public class DeleteProductValidator : AbstractValidator<DeleteProductRequest>
    {
        public DeleteProductValidator()
        {
            RuleFor(p => p.Name)
                .MinimumLength(2)
                .NotEmpty()
                .NotNull();
        }
    }
}
