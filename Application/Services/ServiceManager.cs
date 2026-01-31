using AutoMapper;
using Domain.Interfaces;
using Application.Interfaces;

namespace Application.Services;

public class ServiceManager(IRepositoryManager repositoryManager, IMapper mapper) : IServiceManager
{
    private readonly Lazy<IUserService> _userService = new(() => new UserService(repositoryManager, mapper));
    private readonly Lazy<IEmployeeService> _employeeService = new(() => new EmployeeService(repositoryManager, mapper));

    public IUserService UserService => _userService.Value;
    public IEmployeeService EmployeeService => _employeeService.Value;
}