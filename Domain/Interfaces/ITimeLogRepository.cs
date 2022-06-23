using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ITimeLogRepository
    {
        Task<TimeLog> CreateTimeLogAsync(int id);
        Task<IEnumerable<TimeLog>> ReadTimeLogsAsync();
        Task<TimeLog> ReadTimeLogByIdAsync(int id);
        Task<TimeLog> UpdateTimeLogHourExitAsync(int id);
        Task<TimeLog> DeleteTimeLogAsync(int id);
    }
}
