using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITimeLogService
    {
        Task CreateTimeLogDTOAsync(int id);
        Task<IEnumerable<TimeLogDTO>> ReadTimeLogDTOsAsync();
        Task<IEnumerable<TimeLogDTO>> ReadTimeLogsDTOByIdAsync(int id);
        //Task UpdateTimeLogDTOHourExitAsync(TimeLogDTO timeLogDTO);
        Task DeleteTimeLogDTOAsync(int id);
    }
}
