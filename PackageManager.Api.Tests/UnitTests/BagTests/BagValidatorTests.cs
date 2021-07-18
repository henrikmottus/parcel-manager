using FluentValidation.TestHelper;
using NUnit.Framework;
using ParcelManager.Core.Entities;
using ParcelManager.Core.Validators;

namespace PackageManager.API.Tests
{
    public class BagWithLettersValidatorTests
    {
        private BagWithLettersValidator _validator;
        private BagWithLetters _bag;
        [SetUp]
        public void Setup()
        {
            _validator = new BagWithLettersValidator();
            _bag = new BagWithLetters
            {
                BagNumber = "123456789012345",
                LetterCount = 1,
                Weight = 12345.321M,
                Price = 12345.21M
            };
        }

        [Test]
        public void ShoulSucceedWhenBagHasDefaultValues()
        {
            var validationResult = _validator.TestValidate(_bag);
            validationResult.ShouldNotHaveAnyValidationErrors();
        }

        [Test]
        public void ShouldFailWhenBagNumberFormatIsNotCorrect()
        {
            _bag.BagNumber = "1234567890123456";

            var validationResult = _validator.TestValidate(_bag);
            validationResult.ShouldHaveValidationErrorFor(bag => bag.BagNumber);
        }

        [Test]
        public void ShouldSucceedWhenBagNumberFormatIsCorrect()
        {
            var validationResult = _validator.TestValidate(_bag);
            validationResult.ShouldNotHaveValidationErrorFor(bag => bag.BagNumber);
        }

        [Test]
        public void ShouldFailWhenBagHasNoLetters()
        {
            _bag.LetterCount = 0;

            var validationResult = _validator.TestValidate(_bag);
            validationResult.ShouldHaveValidationErrorFor(bag => bag.LetterCount);
        }

        [Test]
        public void ShouldSucceedWhenBagHasNoLetters()
        {
            var validationResult = _validator.TestValidate(_bag);
            validationResult.ShouldNotHaveValidationErrorFor(bag => bag.LetterCount);
        }

        [Test]
        public void ShouldFailWhenBagWeightHasWrongPrecision()
        {
            _bag.Weight = 12345.4321M;

            var validationResult = _validator.TestValidate(_bag);
            validationResult.ShouldHaveValidationErrorFor(bag => bag.Weight);
        }

        [Test]
        public void ShouldSucceedWhenBagWeightHasCorrectPrecision()
        {
            var validationResult = _validator.TestValidate(_bag);
            validationResult.ShouldNotHaveValidationErrorFor(bag => bag.Weight);
        }

        [Test]
        public void ShouldFailWhenBagPriceHasWrongPrecision()
        {
            _bag.Price = 12345.4321M;

            var validationResult = _validator.TestValidate(_bag);
            validationResult.ShouldHaveValidationErrorFor(bag => bag.Price);
        }

        [Test]
        public void ShouldSucceedWhenBagPriceHasCorrectPrecision()
        {
            var validationResult = _validator.TestValidate(_bag);
            validationResult.ShouldNotHaveValidationErrorFor(bag => bag.Price);
        }
    }
}