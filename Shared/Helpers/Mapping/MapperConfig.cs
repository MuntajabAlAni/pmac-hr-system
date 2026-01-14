using AutoMapper;

namespace Shared.Helpers.Mapping;

public class MapperConfig
{
    public static IMapper GetMapperConfigs()
    {
        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new UserProfile());
            mc.AddProfile(new PermissionProfile());
            mc.AddProfile(new EmployeeProfile());
        });

        return mappingConfig.CreateMapper();
    }
}