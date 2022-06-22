using Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace Domain.Tests
{
    public class ContractUnitTest1
    {
        [Fact]
        public void CreateContract_WuthValidParameters_ResultObjectValidState()
        {
            Action action = () => new Contract(1, "HouseGames", 1, 0, 0);
            action.Should().NotThrow<Domain.Validation.DomainExceptionValidation>();
        }
    }
}