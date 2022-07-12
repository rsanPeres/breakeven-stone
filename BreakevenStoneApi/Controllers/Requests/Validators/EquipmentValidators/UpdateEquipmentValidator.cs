using BreakevenStoneApi.Controllers.Requests.EquipmentRequest;
using FluentValidation;

namespace BreakevenStoneApi.Controllers.Requests.Validators.EquipmentValidators
{
    public class UpdateEquipmentValidator : AbstractValidator<UpdateEquipmentRequest>
    {
        public UpdateEquipmentValidator()
        {
            RuleFor(p => p.Name)
                .MinimumLength(2)
                .NotNull()
                .NotEmpty();

            RuleFor(p => p.NewName)
                .MinimumLength(2)
                .NotNull();

        }
    }
}
