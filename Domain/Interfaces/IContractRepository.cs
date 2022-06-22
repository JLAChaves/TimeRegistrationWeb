using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IContractRepository
    {
        Task<Contract> CreateAsync(Contract contract);
        Task<IEnumerable<Contract>> ReadContractsAsync();
        Task<Contract> ReadContractByIdAsync(int id);
        Task<IEnumerable<Contract>> ReadContractByNameAsync(string name);
        Task<Contract> UpdateAsync(Contract contract);
        Task<Contract> UpdateTotalHoursAsync(int? id);
        Task<Contract> DeleteAsync(Contract contract);
    }
}
