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
        public void CreateTimeLog_WithValidParameters_ResultObjectValidStateWithId()
        {
            Action action = () => new TimeLog(1, DateTime.ParseExact("22/06/2022", "dd/MM/yyyy", CultureInfo.InvariantCulture),
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

        [Fact]
        public void CreateTimeLog_UpdateHoursMethodWithValidParameters_ResultObjectWithHoursNotNull()
        {
            TimeLog timeLog = new TimeLog(DateTime.ParseExact("22/06/2022", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                                                DateTime.ParseExact("23/06/2022", "dd/MM/yyyy", CultureInfo.InvariantCulture));

            Action action = () => timeLog.UpdateHours(24);
            action.Should().NotThrow<Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateTimeLog_UpdateHoursMethodWithoutValidParameters_DomainExceptionHoursNull()
        {
            TimeLog timeLog = new TimeLog(DateTime.ParseExact("22/06/2022", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                                                DateTime.ParseExact("23/06/2022", "dd/MM/yyyy", CultureInfo.InvariantCulture));

            Action action = () => timeLog.UpdateHours(0);
            action.Should().Throw<Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Value Not Updated!");
        }

        [Fact]
        public void CreateTimeLog_UpdateEndTimeMethodWithValidParameters_ResultObjectValidState()
        {
            TimeLog timeLog = new TimeLog(DateTime.ParseExact("22/06/2022", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                                    DateTime.ParseExact("22/06/2022", "dd/MM/yyyy", CultureInfo.InvariantCulture));

            Action action = () => timeLog.UpdateEndTime(DateTime.ParseExact("23/06/2022", "dd/MM/yyyy", CultureInfo.InvariantCulture));
            action.Should().NotThrow<Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateTimeLog_UpdateEndTimeMethodWithoutValidParameters_DomainExceptionEndTimeError()
        {
            TimeLog timeLog = new TimeLog(DateTime.ParseExact("22/06/2022", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                                    DateTime.ParseExact("22/06/2022", "dd/MM/yyyy", CultureInfo.InvariantCulture));

            Action action = () => timeLog.UpdateEndTime(DateTime.ParseExact("21/06/2022", "dd/MM/yyyy", CultureInfo.InvariantCulture));
            action.Should().Throw<Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Time Conflict! Work Start Time is Greater Than End Time");
        }
    }
}
