using BreakevenStoneApi.Controllers.Requests.UserRequests;
using FluentValidation;

namespace BreakevenStoneApi.Controllers.Requests.Validators.UserValidators
{
    public class GetUserValidator : AbstractValidator<GetUserRequest>
    {
        public GetUserValidator()
        {
            RuleFor(p => p.FirstName)
                .MinimumLength(2)
                .NotNull()
                .NotEmpty();

        }
    }
}
