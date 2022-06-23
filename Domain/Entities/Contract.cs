using Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Contract : EntityBase
    {
        public string? Name { get; set; }
        public double ValuePerHour { get; set; }
        public double? TotalValue { get; set; }
        public double? TotalHours { get; set; }
        public ICollection<TimeLog>? TimeLogs { get; set; }

        public Contract(string name, double valuePerHour)
        {
            ValidateDomain(name, valuePerHour);
        }

        public Contract(int id, string name, double valuePerHour)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id Value");
            Id = id;
            ValidateDomain(name, valuePerHour);
        }


        private void ValidateDomain(string name, double valuePerHour)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), 
                "Name Is Required!");

            DomainExceptionValidation.When(name.Length < 3,
                "Minimun Three Characters Required!");

            DomainExceptionValidation.When(valuePerHour == 0 || valuePerHour < 0,
                "Enter a Positive Value Greater Than Zero");

            Name = name;
            ValuePerHour = valuePerHour;
        }
    }
}
