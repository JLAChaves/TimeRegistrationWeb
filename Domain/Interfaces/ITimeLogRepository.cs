using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ITimeLogRepository
    {
        Task<TimeLog> CreateTimeLogAsync(int id);
        Task<IEnumerable<TimeLog>> ReadTimeLogsAsync();
        Task<IEnumerable<TimeLog>> ReadTimeLogsByContractIdAsync(int id);
        Task<TimeLog> UpdateTimeLogHourExitAsync(TimeLog timeLog);
        Task<TimeLog> DeleteTimeLogAsync(int id);
    }
}
