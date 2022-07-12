using BreakevenStoneApi.Controllers.Requests.ProductRequests;
using FluentValidation;

namespace BreakevenStoneApi.Controllers.Requests.Validators.ProductValidators
{
    public class GetProductValidator : AbstractValidator<GetProductRequest>
    {
        public GetProductValidator()
        {
            RuleFor(p => p.Name)
                .MinimumLength(2)
                .NotNull()
                .NotEmpty();
        }
    }
}
