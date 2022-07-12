using BreakevenStoneApi.Controllers.Requests.EmployeeRequests;
using FluentValidation;

namespace BreakevenStoneApi.Controllers.Requests.Validators.EmployeeValidators
{
    public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeRequest>
    {
        public CreateEmployeeValidator()
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

            RuleFor(p => p.Password)
                .NotNull()
                .NotEmpty()
                .MinimumLength(8);
        }
    }
}
