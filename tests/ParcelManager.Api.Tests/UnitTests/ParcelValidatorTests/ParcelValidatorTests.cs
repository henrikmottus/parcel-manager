using FluentValidation.TestHelper;
using NUnit.Framework;
using ParcelManager.Core.Entities;
using ParcelManager.Core.Validators;

namespace PackageManager.API.Tests
{
    public class ParcelValidatorTests
    {
        private ParcelValidator _validator;
        private Parcel _parcel;
        [SetUp]
        public void Setup()
        {
            _validator = new ParcelValidator();
            _parcel = new Parcel
            {
                ParcelNumber = "ab123456cd",
                RecipientName = "This is less than 100 characters",
                DestinationCountry = "EE",
                Weight = 12345.321M,
                Price = 12345.21M
            };
        }

        [Test]
        public void ShoulSucceedWhenParcelHasDefaultValues()
        {
            var validationResult = _validator.TestValidate(_parcel);
            validationResult.ShouldNotHaveAnyValidationErrors();
        }

        [Test]
        public void ShouldFailWhenParcelNumberFormatIsNotCorrect()
        {
            _parcel.ParcelNumber = "1ab123456cd0";

            var validationResult = _validator.TestValidate(_parcel);
            validationResult.ShouldHaveValidationErrorFor(parcel => parcel.ParcelNumber);
        }

        [Test]
        public void ShouldSucceedWhenParcelNumberFormatIsCorrect()
        {
            var validationResult = _validator.TestValidate(_parcel);
            validationResult.ShouldNotHaveValidationErrorFor(parcel => parcel.ParcelNumber);
        }

        [Test]
        public void ShouldFailWhenRecipientNameHasTooManyCharacters()
        {
            _parcel.RecipientName = new string('1', 101);

            var validationResult = _validator.TestValidate(_parcel);
            validationResult.ShouldHaveValidationErrorFor(parcel => parcel.RecipientName);
        }

        [Test]
        public void ShouldSucceedWhenRecipientNameIsCorrect()
        {
            var validationResult = _validator.TestValidate(_parcel);
            validationResult.ShouldNotHaveValidationErrorFor(parcel => parcel.RecipientName);
        }

        [Test]
        public void ShouldFailWhenDestinationCountryHasWrongAmountOfCharacters()
        {
            _parcel.DestinationCountry = new string('E', 3);

            var validationResult = _validator.TestValidate(_parcel);
            validationResult.ShouldHaveValidationErrorFor(parcel => parcel.DestinationCountry);
        }

        [Test]
        public void ShouldFailWhenDestinationCountryHasLowerCaseLetters()
        {
            _parcel.DestinationCountry = new string('e', 2);

            var validationResult = _validator.TestValidate(_parcel);
            validationResult.ShouldHaveValidationErrorFor(parcel => parcel.DestinationCountry);
        }

        [Test]
        public void ShouldSucceedWhenDestinationCountryIsCorrect()
        {
            var validationResult = _validator.TestValidate(_parcel);
            validationResult.ShouldNotHaveValidationErrorFor(parcel => parcel.RecipientName);
        }

        [Test]
        public void ShouldFailWhenParcelWeightHasWrongPrecision()
        {
            _parcel.Weight = 12345.4321M;

            var validationResult = _validator.TestValidate(_parcel);
            validationResult.ShouldHaveValidationErrorFor(parcel => parcel.Weight);
        }

        [Test]
        public void ShouldSucceedWhenParcelWeightHasCorrectPrecision()
        {
            var validationResult = _validator.TestValidate(_parcel);
            validationResult.ShouldNotHaveValidationErrorFor(parcel => parcel.Weight);
        }

        [Test]
        public void ShouldFailWhenParcelPriceHasWrongPrecision()
        {
            _parcel.Price = 12345.4321M;

            var validationResult = _validator.TestValidate(_parcel);
            validationResult.ShouldHaveValidationErrorFor(parcel => parcel.Price);
        }

        [Test]
        public void ShouldSucceedWhenParcelPriceHasCorrectPrecision()
        {
            var validationResult = _validator.TestValidate(_parcel);
            validationResult.ShouldNotHaveValidationErrorFor(parcel => parcel.Price);
        }
    }
}