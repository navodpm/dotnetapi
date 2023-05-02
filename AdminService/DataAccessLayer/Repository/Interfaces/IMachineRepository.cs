using AdminService.DataAccessLayer.Entities;

namespace AdminService.DataAccessLayer.Repository.Interfaces
{
    public interface IMachineRepository: IRepository<Machine>
    {
        Task<Machine> CreateMachineAsync(Machine role);
    }
}
