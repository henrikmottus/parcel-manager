using FluentValidation;
using ParcelManager.Core.Entities;

namespace ParcelManager.Core.Validators
{
    public class BagWithParcelsValidator : AbstractValidator<BagWithParcels>
    {
        public BagWithParcelsValidator()
        {
            Include(new BagValidator());
        }
    }
}
