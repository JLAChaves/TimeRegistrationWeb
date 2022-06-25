using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class ContractRepository : IContractRepository
    {

        ApplicationDbContext _contractContext;
        public ContractRepository(ApplicationDbContext context)
        {
            _contractContext = context;
        }
        public async Task<Contract> CreateContractAsync(Contract contract)
        {
            _contractContext.Add(contract);
            await _contractContext.SaveChangesAsync();
            return contract;
        }

        public async Task<IEnumerable<Contract>> ReadContractsAsync()
        {
            return await _contractContext.Contracts.ToListAsync();
        }
        
        public async Task<Contract> ReadContractByIdAsync(int id)
        {
            return await _contractContext.Contracts.FindAsync(id);
        }

        public async Task<IEnumerable<Contract>> ReadContractByNameAsync(string name)
        {
            return await _contractContext.Contracts.Where(p => p.Name.Contains(name)).ToArrayAsync();
        }

        public async Task<Contract> UpdateContractAsync(Contract contract)
        {
            _contractContext.Contracts.Update(contract);
            await _contractContext.SaveChangesAsync();
            return contract;
        }

        public async Task<Contract> UpdateContractTotalHoursAsync(int? id)
        {
            var contract = await _contractContext.Contracts.FindAsync(id);
            contract.UpdateTotalHours(Math.Round( (double) TotalHours(id), 2));
            contract.UpdateTotalValue(TotalValue(contract));
            _contractContext.Update(contract);
            await _contractContext.SaveChangesAsync();
            return contract;
        }

        public double? TotalHours(int? id)
        {
            return _contractContext.TimeLogs.Where(p => p.ContractId == id).Sum(p => p.Hours);
        }

        public double? TotalValue(Contract contract)
        {
            return contract.TotalHours * contract.ValuePerHour;
        }

        public async Task<Contract> DeleteContractAsync(Contract contract)
        {
            _contractContext.Remove(contract);
            await _contractContext.SaveChangesAsync();
            return contract;           
        }
    }
}
