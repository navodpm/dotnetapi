using CommonService.DataAccessLayer.Repository.Interfaces;

namespace CommonService.BusinessLogicLayer.Service.Interfaces
{
    public interface IServiceWrapper
    {
        public IUserService UserService { get; }
    }
}
