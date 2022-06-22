using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ITimeLogRepository
    {
        Task<TimeLog> CreateAsync(TimeLog timeLog);
        Task<IEnumerable<TimeLog>> ReadTimeLogsAsync();
        Task<TimeLog> ReadTimeLogByIdAsync(int id);
        Task<TimeLog> UpdateHourExitAsync(int id);
        Task<TimeLog> DeleteAsync(TimeLog timeLog);
    }
}
