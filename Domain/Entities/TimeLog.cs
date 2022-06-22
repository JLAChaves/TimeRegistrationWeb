using Domain.Validation;

namespace Domain.Entities
{
    public class TimeLog : EntityBase
    {
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public double? Hours { get; set; }
        public int ContractId { get; set; }
        public Contract? Contract { get; set; }

        public TimeLog(DateTime startTime, DateTime endTime, double hours)
        {
            ValidateDomain(startTime, endTime, hours);
        }

        public TimeLog(int id, DateTime startTime, DateTime endTime, double hours)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id Value");
            Id = id;
            ValidateDomain(startTime, endTime, hours);
        }

        private void ValidateDomain(DateTime startTime, DateTime endTime, double hours)
        {
            DomainExceptionValidation.When(startTime > endTime,
                "Time Conflict! Work Start Time is Greater Than End Time");

            StartTime = startTime;
            EndTime = endTime;
            Hours = hours;
        }
    }
}
