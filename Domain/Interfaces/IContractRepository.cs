using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IContractRepository
    {
        Task<Contract> CreateContractAsync(Contract contract);
        Task<IEnumerable<Contract>> ReadContractsAsync();
        Task<Contract> ReadContractByIdAsync(int id);
        Task<IEnumerable<Contract>> ReadContractByNameAsync(string name);
        Task<Contract> UpdateContractAsync(Contract contract);
        Task<Contract> UpdateContractTotalHoursAsync(int? id);
        Task<Contract> DeleteContractAsync(Contract contract);
    }
}
