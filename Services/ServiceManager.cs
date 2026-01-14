using AutoMapper;
using Interfaces;
using Microsoft.Extensions.Configuration;
using Services.Interfaces;
using Shared.Email;

namespace Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IUserService> _userService;
    private readonly Lazy<IEmployeeService> _employeeService;

    public ServiceManager(IRepositoryManager repositoryManager,
        IConfiguration configuration,
        IMapper mapper,
        EmailServiceConfiguration mailServiceConfiguration)
    {
        Lazy<IEmailService> emailService = new(() => new EmailService(mailServiceConfiguration));

        _userService = new Lazy<IUserService>(() =>
            new UserService(repositoryManager, configuration, emailService.Value, mapper));
        
        _employeeService = new Lazy<IEmployeeService>(() =>
            new EmployeeService(repositoryManager, mapper));
    }

    public IUserService UserService => _userService.Value;
    public IEmployeeService EmployeeService => _employeeService.Value;
}