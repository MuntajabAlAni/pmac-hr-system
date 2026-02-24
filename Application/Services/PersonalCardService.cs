using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Interfaces;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace Application.Services;

public class PersonalCardService(IRepositoryManager repositoryManager, IMapper mapper) : IPersonalCardService
{
    public async Task<IEnumerable<PersonalCardDto>> GetAll()
    {
        var personalCards = await repositoryManager.PersonalCard.FindAll();
        return mapper.Map<IEnumerable<PersonalCardDto>>(personalCards);
    }

    public async Task<PersonalCardDto> GetById(Guid id)
    {
        var personalCard = await repositoryManager.PersonalCard.FindById(id);
        if (personalCard is null)
            throw new EntityNotFoundException("PersonalCard", "Id", id);

        return mapper.Map<PersonalCardDto>(personalCard);
    }

    public async Task<Guid> Create(PersonalCardForCreationDto personalCardDto)
    {
        var personalCard = mapper.Map<PersonalCard>(personalCardDto);
        return await repositoryManager.PersonalCard.Create(personalCard);
    }

    public async Task Update(Guid id, PersonalCardForUpdateDto personalCardDto)
    {
        var personalCard = await repositoryManager.PersonalCard.FindById(id);
        if (personalCard is null)
            throw new EntityNotFoundException("PersonalCard", "Id", id);

        mapper.Map(personalCardDto, personalCard);
        personalCard.Id = id;
        await repositoryManager.PersonalCard.Update(personalCard);
    }

    public async Task Delete(Guid id)
    {
        var personalCard = await repositoryManager.PersonalCard.FindById(id);
        if (personalCard is null)
            throw new EntityNotFoundException("PersonalCard", "Id", id);

        await repositoryManager.PersonalCard.Delete(id);
    }
}
