using Domain.Entities;
using FluentAssertions;
using System;
using System.Globalization;
using Xunit;

namespace Domain.Tests
{
    public class TimeLogUnitTest1
    {
        [Fact]
        public void CreateTimeLog_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new TimeLog(DateTime.ParseExact("22/06/2022", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                                                DateTime.ParseExact("23/06/2022", "dd/MM/yyyy", CultureInfo.InvariantCulture));

            action.Should().NotThrow<Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateTimeLog_StartTimeGreaterThanEndTime_DomainExceptionStartTimeGreatedThanEndTime()
        {
            Action action = () => new TimeLog(DateTime.ParseExact("23/06/2022", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                                                DateTime.ParseExact("22/06/2022", "dd/MM/yyyy", CultureInfo.InvariantCulture));
            action.Should().Throw<Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Time Conflict! Work Start Time is Greater Than End Time");
        }


    }
}
