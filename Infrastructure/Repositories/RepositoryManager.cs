using Domain.Interfaces;

namespace Infrastructure.Repositories;

public class RepositoryManager(DapperContext context) : IRepositoryManager
{
    private readonly Lazy<IUserRepository> _userRepository = new(() => new UserRepository(context));
    private readonly Lazy<IEmployeeRepository> _employeeRepository = new(() => new EmployeeRepository(context));

    public IUserRepository User => _userRepository.Value;
    public IEmployeeRepository Employee => _employeeRepository.Value;
}
