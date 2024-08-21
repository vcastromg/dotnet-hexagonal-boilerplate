using Application.DTOs.Requests;
using Application.DTOs.Responses;

namespace Application.Repositories;

public interface BaseRepository<TEntity> where TEntity : class
{
    IEnumerable<TEntity> GetAll();
    IEnumerable<TDto> GetAll<TDto>();
    PaginatedResponseDTO<TDto> Get<TDto>(PaginatedRequestDTO paginatedRequest);
    PaginatedResponseDTO<TEntity> Get(PaginatedRequestDTO paginatedRequest);
    TEntity? GetById(object id);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    int Count();
    void SaveChanges();
}