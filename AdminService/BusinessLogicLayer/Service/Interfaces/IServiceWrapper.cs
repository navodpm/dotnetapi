using AdminService.DataAccessLayer.Repository.Interfaces;

namespace AdminService.BusinessLogicLayer.Service.Interfaces
{
    public interface IServiceWrapper
    {
        public IUserService UserService { get; }
    }
}
