using AdminService.BusinessLogicLayer.DTO;
using AdminService.DataAccessLayer.Entities;
using AdminService.DataAccessLayer.Repository.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdminService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MachineController : ApiBaseController
    {
        private readonly IRepositoryWrapper repository;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;

        public MachineController(IRepositoryWrapper repository, IConfiguration configuration, IMapper mapper)
        {
            this.repository = repository;
            this.configuration = configuration;
            this.mapper = mapper;
        }
        
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(200, Type = typeof(ApiResponseModel<string>))]
        public async Task<IActionResult> CreateMachine([FromBody] MachineRequestModel model)
        {
            var machine = mapper.Map<Machine>(model);
            var machineCreated = await repository.MachineRepository.CreateMachineAsync(machine);
            await repository.SaveAsync();
            return CreateSuccessResponse($"Machine created successfully with Id {machineCreated.Id}");
        }


    }
}
