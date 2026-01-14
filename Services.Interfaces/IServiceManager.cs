namespace Services.Interfaces;

public interface IServiceManager
{
    IUserService UserService { get; }
    IEmployeeService EmployeeService { get; }
}