using Domain.Validation;

namespace Domain.Entities
{
    public sealed class TimeLog : EntityBase
    {
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public double? Hours { get; private set; }
        public int ContractId { get; private set; }
        public Contract? Contract { get; set; }

        public TimeLog(DateTime startTime, DateTime endTime)
        {
            DomainExceptionValidation.When(startTime > endTime, "Time Conflict! Work Start Time is Greater Than End Time"); 
            StartTime = startTime;
            EndTime = endTime;
        }

        public TimeLog(int id, DateTime startTime, DateTime endTime)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id Value");

            DomainExceptionValidation.When(startTime > endTime, 
                "Time Conflict! Work Start Time is Greater Than End Time");

            Id = id;
            StartTime = startTime;
            EndTime = endTime;
        }

        public TimeLog(DateTime startTime, DateTime endTime, int contractId)
        {

            DomainExceptionValidation.When(startTime > endTime,
                "Time Conflict! Work Start Time is Greater Than End Time");

            StartTime = startTime;
            EndTime = endTime;
            ContractId = contractId;
        }

        public TimeLog UpdateEndTime(DateTime endTime)
        {
            this.EndTime = endTime;

            DomainExceptionValidation.When(this.StartTime > this.EndTime, 
                "Time Conflict! Work Start Time is Greater Than End Time");

            return this;
        }

        public TimeLog UpdateHours(double? hours)
        {
            this.Hours = hours;
            DomainExceptionValidation.When(this.Hours == null,
                "Value Not Updated!");
            return this;
        }
    }
}
