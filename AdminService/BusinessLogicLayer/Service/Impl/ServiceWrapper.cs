using AdminService.BusinessLogicLayer.Service.Interfaces;
using AdminService.DataAccessLayer.Context;
using AdminService.DataAccessLayer.Repository.Interfaces;

namespace AdminService.BusinessLogicLayer.Service.Impl
{
    public class ServiceWrapper : IServiceWrapper
    {
        private readonly IRepositoryWrapper wrapper;
        private readonly IUserService _user;

        public ServiceWrapper(IRepositoryWrapper wrapper)
        {
            this.wrapper = wrapper;
            _user = new UserService(wrapper);
        }

        public IUserService UserService => _user;
    }
}
