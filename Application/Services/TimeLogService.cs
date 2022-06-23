using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class TimeLogService : ITimeLogService
    {
        private readonly ITimeLogRepository _timeLogRepository;
        private readonly IMapper _mapper;
        private object contractDTO;

        public TimeLogService(ITimeLogRepository timeLogRepository, IMapper mapper)
        {
            _timeLogRepository = timeLogRepository;
            _mapper = mapper;
        }

        public async Task CreateTimeLogDTOAsync(int id)
        {
            await _timeLogRepository.CreateTimeLogAsync(id);
        }
        public async Task<IEnumerable<TimeLogDTO>> ReadTimeLogDTOsAsync()
        {
            var timeLogEntity = await _timeLogRepository.ReadTimeLogsAsync();
            return _mapper.Map<IEnumerable<TimeLogDTO>>(timeLogEntity);
        }
        public async Task<TimeLogDTO> ReadTimeLogDTOByIdAsync(int id)
        {
            var timeLogEntity = _timeLogRepository.ReadTimeLogByIdAsync(id);
            return _mapper.Map<TimeLogDTO>(timeLogEntity);
        }
        public async Task UpdateTimeLogDTOHourExitAsync(int id)
        {
            await _timeLogRepository.UpdateTimeLogHourExitAsync(id);
        }
        public async Task DeleteTimeLogDTOAsync(int id)
        {
            await _timeLogRepository.DeleteTimeLogAsync(id);
        }
    }
}
