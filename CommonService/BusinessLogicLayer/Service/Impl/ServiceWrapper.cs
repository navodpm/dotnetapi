using CommonService.BusinessLogicLayer.Service.Interfaces;
using CommonService.DataAccessLayer.Context;
using CommonService.DataAccessLayer.Repository.Interfaces;

namespace CommonService.BusinessLogicLayer.Service.Impl
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
