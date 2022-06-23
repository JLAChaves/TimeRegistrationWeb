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
        Task<TimeLogDTO> ReadTimeLogDTOByIdAsync(int id);
        Task<TimeLogDTO> UpdateTimeLogDTOHourExitAsync(int id);
        Task<TimeLogDTO> DeleteTimeLogDTOAsync(int id);
    }
}
