using BreakevenStoneApi.Controllers.Requests.UserRequests;
using FluentValidation;

namespace BreakevenStoneApi.Controllers.Requests.Validators.UserValidators
{
    public class DeleteUserValidator : AbstractValidator<DeleteUserRequest>
    {
        public DeleteUserValidator()
        {
            RuleFor(p => p.Cpf)
                .MinimumLength(11)
                .MaximumLength(11)
                .NotEmpty();
        }
    }
}
