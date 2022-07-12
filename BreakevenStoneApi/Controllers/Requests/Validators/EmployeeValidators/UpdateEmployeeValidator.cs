using BreakevenStoneApi.Controllers.Requests.EmployeeRequests;
using FluentValidation;

namespace BreakevenStoneApi.Controllers.Requests.Validators.EmployeeValidators
{
    public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeeRequest>
    {
        public UpdateEmployeeValidator()
        {
            RuleFor(p => p.Cpf)
                .MinimumLength(11)
                .MaximumLength(11)
                .NotEmpty()
                .NotNull();

            RuleFor(p => p.Function)
                .MinimumLength(3)
                .NotNull()
                .NotNull();
        }
    }
}
