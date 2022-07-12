using BreakevenStoneApi.Controllers.Requests.EquipmentRequest;
using FluentValidation;

namespace BreakevenStoneApi.Controllers.Requests.Validators.EquipmentValidators
{
    public class EquipmentValidator : AbstractValidator<CreateEquipmentRequest>
    {
        public EquipmentValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3);

            RuleFor(p => p.Description)
                .NotNull()
                .NotEmpty();
        }
    }
}
