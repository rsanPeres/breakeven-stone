using BreakevenStoneApi.Controllers.Requests.EquipmentRequest;
using FluentValidation;

namespace BreakevenStoneApi.Controllers.Requests.Validators.EquipmentValidators
{
    public class UpdateEquipmentValidator : AbstractValidator<UpdateEquipmentRequest>
    {
        public UpdateEquipmentValidator()
        {
            RuleFor(p => p.Description)
                .MinimumLength(3)
                .NotNull()
                .NotEmpty();

            RuleFor(p => p.NewDescription)
                .MinimumLength(2)
                .NotNull();

        }
    }
}
