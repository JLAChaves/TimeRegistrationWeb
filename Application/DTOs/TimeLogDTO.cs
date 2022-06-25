using Domain.Entities;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Application.DTOs
{
    public class TimeLogDTO
    {
        [DisplayName("Start Time")]
        public DateTime StartTime { get; set; }

        [DisplayName("End Time")]
        public DateTime EndTime { get; set; }

        [DisplayName("Hours")]
        public double? Hours { get; set; }

        [DisplayName("Contract")]
        public int ContractId { get; set; }

        [JsonIgnore]
        public Contract? Contract { get; set; }
    }
}
