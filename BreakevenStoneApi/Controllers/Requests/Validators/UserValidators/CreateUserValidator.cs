using BreakevenStoneApi.Controllers.Requests.UserRequests;
using FluentValidation;

namespace BreakevenStoneApi.Controllers.Requests.Validators.UserValidators
{
    public class CreateUserValidator : AbstractValidator<UserRequest>
    {

        public CreateUserValidator()
        {
            RuleFor(p => p.CPF)
                .NotNull()
                .MaximumLength(11)
                .MinimumLength(11)
                .NotEmpty();

            RuleFor(p => p.FirstName)
                .NotNull()
                .MinimumLength(3)
                .NotEmpty();

            RuleFor(p => p.Email)
                .NotEmpty()
                .NotNull()
                .MinimumLength(8);

        }
    }
}