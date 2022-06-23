using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IContractService
    {
        Task CreateContractDTOAsync(ContractDTO contractDTO);
        Task<IEnumerable<ContractDTO>> ReadContracsDTOAsync();
        Task<ContractDTO> ReadContractDTOByIdAsync(int id);
        Task<IEnumerable<ContractDTO>> ReadContractDTOByNameAsync(string name);
        Task UpdateContractDTOAsync(ContractDTO contractDTO);
        Task UpdateContractDTOTotalHoursAsync(int? id);
        Task DeleteContractDTOAsync(int id);
    }
}
