using Domain.Entities;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Application.DTOs
{
    public class TimeLogDTO
    {
        [DisplayName("Start Time")]
        public DateTime StartTime { get; private set; }

        [DisplayName("End Time")]
        public DateTime EndTime { get; private set; }

        [DisplayName("Hours")]
        public double? Hours { get; private set; }

        [DisplayName("Contract")]
        public int ContractId { get; private set; }

        [JsonIgnore]
        public Contract? Contract { get; set; }
    }
}
