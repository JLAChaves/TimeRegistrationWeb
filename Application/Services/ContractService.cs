using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class ContractService : IContractService
    {
        private readonly IContractRepository _contractRepository;
        private readonly IMapper _mapper;

        public ContractService(IContractRepository contractRepository, IMapper mapper)
        {
            _contractRepository = contractRepository;
            _mapper = mapper;
        }


        public async Task CreateContractDTOAsync(ContractDTO contractDTO)
        {
            var contractEntity = _mapper.Map<Contract>(contractDTO);
            await _contractRepository.CreateContractAsync(contractEntity);
        }
        public async Task<IEnumerable<ContractDTO>> ReadContracsDTOAsync()
        {
            var contractsEntity = await _contractRepository.ReadContractsAsync();
            return _mapper.Map<IEnumerable<ContractDTO>>(contractsEntity);
        }
        public async Task<ContractDTO> ReadContractDTOByIdAsync(int id)
        {
            var contractEntity = await _contractRepository.ReadContractByIdAsync(id);
            return _mapper.Map<ContractDTO>(contractEntity);
        }
        public async Task<IEnumerable<ContractDTO>> ReadContractDTOByNameAsync(string name)
        {
            var contractEntity = await _contractRepository.ReadContractByNameAsync(name);
            return _mapper.Map<IEnumerable<ContractDTO>>(contractEntity);
        }
        public async Task UpdateContractDTOAsync(ContractDTO contractDTO)
        {
            var contractEntity = _mapper.Map<Contract>(contractDTO);
            await _contractRepository.UpdateContractAsync(contractEntity);
        }
        public async Task UpdateContractDTOTotalHoursAsync(int? id)
        {
            await _contractRepository.UpdateContractTotalHoursAsync(id);
        }
        public async Task DeleteContractDTOAsync(int id)
        {
            var contractEntity = _contractRepository.ReadContractByIdAsync(id).Result;
            await _contractRepository.DeleteContractAsync(contractEntity);
        }
    }
}
