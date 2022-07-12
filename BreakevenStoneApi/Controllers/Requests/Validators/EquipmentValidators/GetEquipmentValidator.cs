using BreakevenStoneApi.Controllers.Requests.EquipmentRequest;
using FluentValidation;

namespace BreakevenStoneApi.Controllers.Requests.Validators.EquipmentValidators
{
    public class GetEquipmentValidator : AbstractValidator<GetEquipmentRequest>
    {
        public GetEquipmentValidator()
        {
            RuleFor(x => x.Name)
                .MinimumLength(2)
                .NotNull()
                .NotEmpty();
        }
    }
}
