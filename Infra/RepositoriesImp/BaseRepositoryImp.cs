using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Infra.Adapters;
using Microsoft.EntityFrameworkCore;

namespace Infra.RepositoriesImp;

public class BaseRepositoryImp<T> : BaseRepository<T> where T : class
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    private readonly DbSet<T> _table;

    protected BaseRepositoryImp(ApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _table = _applicationDbContext.Set<T>();
        _mapper = mapper;
    }

    public IEnumerable<T> GetAll()
    {
        return _table.ToList();
    }

    public IEnumerable<TDto> GetAll<TDto>()
    {
        return _table
            .AsNoTracking()
            .ProjectTo<TDto>(_mapper.ConfigurationProvider)
            .ToList();
    }

    public PaginatedResponseDTO<TDto> Get<TDto>(PaginatedRequestDTO paginatedRequest)
    {
        return new PaginatedResponseDTO<TDto>
        {
            TotalCount = Count(),
            Items = _table
                .AsNoTracking()
                .Skip((paginatedRequest.PageNumber - 1) * paginatedRequest.PageSize)
                .Take(paginatedRequest.PageSize)
                .ProjectTo<TDto>(_mapper.ConfigurationProvider)
                .ToList()
        };
    }

    public PaginatedResponseDTO<T> Get(PaginatedRequestDTO paginatedRequest)
    {
        return new PaginatedResponseDTO<T>
        {
            TotalCount = Count(),
            Items = _table
                .Skip((paginatedRequest.PageNumber - 1) * paginatedRequest.PageSize)
                .Take(paginatedRequest.PageSize)
                .ToList()
        };
    }

    public T? GetById(object id)
    {
        return _table.Find(id);
    }

    public void Add(T entity)
    {
        _table.Add(entity);
    }

    public void Update(T entity)
    {
        _table.Attach(entity);
        _applicationDbContext.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(T entity)
    {
        _applicationDbContext.Remove(entity);
    }

    public int Count()
    {
        return _table.Count();
    }

    public void SaveChanges()
    {
        _applicationDbContext.SaveChanges();
    }
}