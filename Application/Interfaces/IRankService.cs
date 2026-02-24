using Application.DataTransferObjects;

namespace Application.Interfaces;

public interface IRankService
{
    Task<IEnumerable<RankDto>> GetAll();
    Task<RankDto> GetById(Guid id);
    Task<Guid> Create(RankForCreationDto rankDto);
    Task Update(Guid id, RankForUpdateDto rankDto);
    Task Delete(Guid id);
}
