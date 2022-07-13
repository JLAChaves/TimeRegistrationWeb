using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebUi.Controllers
{
    public class TimeLogsController : Controller
    {
        private readonly ITimeLogService _timeLogService;
        
        public TimeLogsController(ITimeLogService timeLogService)
        {
            _timeLogService = timeLogService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var timeLog = await _timeLogService.ReadTimeLogsDTOByIdAsync(id);
            if (timeLog.FirstOrDefault() == null)
            {
                return RedirectToAction("Index", "Contracts");
            }
            return View(timeLog);
        }

        [HttpGet]
        public async Task<IActionResult> RegisterTimeLog(int id)
        {
            if (ModelState.IsValid)
            {
                await _timeLogService.CreateTimeLogDTOAsync(id);
                return RedirectToAction("Index", "Contracts");
            }
            return View();
        }
    }
}
