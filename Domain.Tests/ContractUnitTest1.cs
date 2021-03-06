using Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace Domain.Tests
{
    public class ContractUnitTest1
    {
        [Fact]
        public void CreateContract_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Contract(1, "HouseGames", 20);
            action.Should().NotThrow<Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void UpdateTotalValue_UsingUpdateTotalValueMethodWithValidParameters_ResultObjectWithTotalValueNotNull()
        {
            Contract contract = new Contract("House Games", 20);

            Action action = () => contract.UpdateTotalValue(50);
            action.Should().NotThrow<Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void UpdateTotalValue_UsingUpdateTotalValueMethodWithoutValidParameters_DomainExceptionTotalValueNull()
        {
            Contract contract = new Contract("House Games", 20);

            Action action = () => contract.UpdateTotalValue(0);
            action.Should().Throw<Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Value Not Updated!");
        }

        [Fact]
        public void CreateContract_WithValuePerHourNegative_DomainExceptionNegativeValue()
        {
            Action action = () => new Contract(1, "HouseGames", -10);
            action.Should().Throw<Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Enter a Positive Value Greater Than Zero");
        }

        [Fact]
        public void CreateContract_WithValuePerHourNegative_DomainExceptionZeroValue()
        {
            Action action = () => new Contract(1, "HouseGames", 0);
            action.Should().Throw<Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Enter a Positive Value Greater Than Zero");
        }

        [Fact]
        public void CreateContract_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Contract(1, "", 20);
            action.Should().Throw<Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Name Is Required!");
        }

        [Fact]
        public void CreateContract_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Contract(1, "Ho", 20);
            action.Should().Throw<Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Minimun Three Characters Required!");
        }

        [Fact]
        public void UpdateTotalHours_UsingUpdateTotalHoursMethodWithValidParameters_ResultObjectWithTotalHoursNotNull()
        {
            Contract contract = new Contract("House Games", 20);

            Action action = () => contract.UpdateTotalHours(2.5);
            action.Should().NotThrow<Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void UpdateTotalHours_UsingUpdateTotalHoursMethodWithoutValidParameters_DomainExceptionTotalHoursNull()
        {
            Contract contract = new Contract("House Games", 20);
            Action action = () => contract.UpdateTotalHours(0);
            action.Should().Throw<Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Value Not Updated!");
        }
    }
}