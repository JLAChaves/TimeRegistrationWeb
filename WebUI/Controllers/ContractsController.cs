using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebUi.Controllers
{
    public class ContractsController : Controller
    {
        private readonly IContractService _contractService;
        public ContractsController(IContractService contractService)
        {
            _contractService = contractService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var contracts = await _contractService.ReadContracsDTOAsync();
            return View(contracts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContractDTO contract)
        {
            if (ModelState.IsValid)
            {
                await _contractService.CreateContractDTOAsync(contract);
                return RedirectToAction(nameof(Index));
            }
            return View(contract);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateValue(int id)
        {
            if (ModelState.IsValid)
            {
                await _contractService.UpdateContractDTOTotalHoursAsync(id);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }  
        
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                await _contractService.DeleteContractDTOAsync(id);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
