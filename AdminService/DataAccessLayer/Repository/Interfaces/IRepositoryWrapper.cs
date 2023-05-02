namespace AdminService.DataAccessLayer.Repository.Interfaces
{
    public interface IRepositoryWrapper
    {
        public IUserRepository UserRepository { get; }
        public IMachineRepository MachineRepository { get; }
        Task<int> SaveAsync();
    }
}
