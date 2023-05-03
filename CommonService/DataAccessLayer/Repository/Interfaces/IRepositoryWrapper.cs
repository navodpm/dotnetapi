namespace CommonService.DataAccessLayer.Repository.Interfaces
{
    public interface IRepositoryWrapper
    {
        public IUserRepository UserRepository { get; }
        Task<int> SaveAsync();
    }
}
