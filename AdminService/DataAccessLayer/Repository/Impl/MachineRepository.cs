using AdminService.DataAccessLayer.Context;
using AdminService.DataAccessLayer.Entities;
using AdminService.DataAccessLayer.Repository.Interfaces;
using System.Linq.Expressions;

namespace AdminService.DataAccessLayer.Repository.Impl
{
    public class MachineRepository : RepositoryBase<Machine>, IMachineRepository
    {
        private readonly DefaultDBContext dbContext;

        public MachineRepository(DefaultDBContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Machine> CreateMachineAsync(Machine machine)
        {
            var result = await dbContext.Machines.AddAsync(machine);
            return result.Entity;
        }
    }
}
