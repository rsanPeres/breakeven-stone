using BreakevenStoneApi.Controllers.Requests.EmployeeRequests;
using FluentValidation;

namespace BreakevenStoneApi.Controllers.Requests.Validators.EmployeeValidators
{
    public class GetEmployeeValidator : AbstractValidator<GetEmployeeRequest>
    {
        public GetEmployeeValidator()
        {
            RuleFor(p => p.Cpf)
                .MinimumLength(11)
                .MaximumLength(11)
                .NotNull()
                .NotEmpty();
        }
    }
}
