using AutoMapper;
using Domain.Models;
using Application.DataTransferObjects;

namespace Application.Mapping;

public class RewardProfile : Profile
{
    public RewardProfile()
    {
        CreateMap<Reward, RewardDto>();
        CreateMap<RewardForCreationDto, Reward>();
        CreateMap<RewardForUpdateDto, Reward>();
    }
}
