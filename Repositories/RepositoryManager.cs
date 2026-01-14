using Interfaces;

namespace Repositories;

public class RepositoryManager(DapperContext context) : IRepositoryManager
{
    private readonly Lazy<IUserRepository> _userRepository = new(() => new UserRepository(context));
    public IUserRepository User => _userRepository.Value;
}