using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ContractDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name Is Required!")]
        [MinLength(3)]
        [MaxLength(150)]
        [DisplayName("Name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Value Is Required")]
        [DisplayName("Value Per Hour")]
        public double ValuePerHour { get; set; }

        [DisplayName("Total Value")]
        public double? TotalValue { get; set; }

        [DisplayName("Total Hours")]
        public double? TotalHours { get; set; }
    }
}
