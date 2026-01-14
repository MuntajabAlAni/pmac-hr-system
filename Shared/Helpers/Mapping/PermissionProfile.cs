using System.ComponentModel.DataAnnotations;
using System.Reflection;
using AutoMapper;
using Entities.Enums;
using Shared.DataTransferObjects;

namespace Shared.Helpers.Mapping;

public class PermissionProfile : Profile
{
    public PermissionProfile()
    {
        CreateMap<Permission, PermissionDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => (int)src))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => GetEnumName(src)))
            .ForMember(dest => dest.Tag, opt => opt.MapFrom(src => GetEnumDescription(src)));
    }

    private static string GetEnumDescription<TEnum>(TEnum value)
    {
        var field = typeof(TEnum).GetField(value!.ToString()!);
        var attr = field?.GetCustomAttribute<DisplayAttribute>();
        return attr?.Description ?? value.ToString()!;
    }

    private static string GetEnumName<TEnum>(TEnum value)
    {
        var field = typeof(TEnum).GetField(value!.ToString()!);
        var attr = field?.GetCustomAttribute<DisplayAttribute>();
        return attr?.Name ?? value.ToString()!;
    }
}
