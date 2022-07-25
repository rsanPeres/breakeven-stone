using BreakevenStoneApi.Controllers.Requests.UserRequests;
using FluentValidation;

namespace BreakevenStoneApi.Controllers.Requests.Validators.UserValidators
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserValidator()
        {
            /*RuleFor(p => p.Cpf)
                .MinimumLength(11)
                .MaximumLength(11)
                .NotEmpty();
            */
            
            RuleFor(p => p.Adress)
                .NotEmpty()
                .NotNull();
        }
    }
}
