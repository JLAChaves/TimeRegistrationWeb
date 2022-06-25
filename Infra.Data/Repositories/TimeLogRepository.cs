using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class TimeLogRepository : ITimeLogRepository
    {
        ApplicationDbContext _timeLogContext;
        public TimeLogRepository(ApplicationDbContext context)
        {
            _timeLogContext = context;
        }
        public async Task<TimeLog> CreateTimeLogAsync(int id)
        {
            var actualTimeLog = _timeLogContext.TimeLogs.FirstOrDefault(p => p.IsActual == true && p.ContractId == id);

            if (actualTimeLog == null)
            {
                TimeLog timeLog = new TimeLog(DateTime.Now, DateTime.Now, id);
                timeLog.UpdateHours(0);
                _timeLogContext.TimeLogs.Update(timeLog);
                await _timeLogContext.SaveChangesAsync();
                return timeLog;
            }
            else
            {
                await UpdateTimeLogHourExitAsync(actualTimeLog);
                await _timeLogContext.SaveChangesAsync();
                return actualTimeLog;
            }                        
        }

        public async Task<IEnumerable<TimeLog>> ReadTimeLogsAsync()
        {
            return await _timeLogContext.TimeLogs.ToListAsync();
        }

        public async Task<IEnumerable<TimeLog>> ReadTimeLogsByContractIdAsync(int id)
        {
            return await _timeLogContext.TimeLogs.Where(p => p.ContractId == id).OrderByDescending(p => p.Id).ToListAsync();
        }

        public async Task<TimeLog> UpdateTimeLogHourExitAsync(TimeLog timeLog)
        {
            HourExit(timeLog);
            _timeLogContext.Update(timeLog);
            await _timeLogContext.SaveChangesAsync();
            return timeLog;
        }
        private void HourExit(TimeLog timeLog)
        {
            timeLog.UpdateEndTime(DateTime.Now);

            timeLog.UpdateHours((double)Math.Round(Hours(timeLog), 2));
        }

        public double Hours(TimeLog timeLog)
        {
            TimeSpan ts = timeLog.EndTime - timeLog.StartTime;
            return ts.TotalHours;
        }

        public async Task<TimeLog> DeleteTimeLogAsync(int id)
        {
            var timeLog = await _timeLogContext.TimeLogs.FindAsync(id);
            _timeLogContext.TimeLogs.Remove(timeLog);
            await _timeLogContext.SaveChangesAsync();
            return timeLog;
        }
    }
}
