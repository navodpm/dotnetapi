using AdminService.DataAccessLayer.Context;
using AdminService.DataAccessLayer.Repository.Interfaces;

namespace AdminService.DataAccessLayer.Repository.Impl
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly DefaultDBContext dbContext;
        private readonly IUserRepository _user;
        private readonly IMachineRepository _machine;

        public RepositoryWrapper(DefaultDBContext dbContext)
        {
            this.dbContext = dbContext;
            _user = new UserRepository(dbContext);
            _machine = new MachineRepository(dbContext);
        }


        public IUserRepository UserRepository => _user;

        public IMachineRepository MachineRepository => _machine;

        public async Task<int> SaveAsync()
        {
            return await dbContext.SaveChangesAsync();
        }
    }
}
