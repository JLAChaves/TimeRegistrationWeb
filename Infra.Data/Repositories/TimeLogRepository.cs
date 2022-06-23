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
            TimeLog timeLog = new TimeLog(DateTime.Now, DateTime.Now, id);
            timeLog.UpdateHours(0);
            _timeLogContext.TimeLogs.Update(timeLog);
            await _timeLogContext.SaveChangesAsync();
            return timeLog;            
        }

        public async Task<IEnumerable<TimeLog>> ReadTimeLogsAsync()
        {
            return await _timeLogContext.TimeLogs.ToListAsync();
        }

        public async Task<TimeLog> ReadTimeLogByIdAsync(int id)
        {
            return await _timeLogContext.TimeLogs.FindAsync(id);
        }

        public async Task<TimeLog> UpdateTimeLogHourExitAsync(int id)
        {
            var timeLogExit = await _timeLogContext.TimeLogs.FindAsync(id);
            HourExit(timeLogExit);
            _timeLogContext.Update(timeLogExit);
            await _timeLogContext.SaveChangesAsync();
            return timeLogExit;
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
