using Application.Repositories;
using AutoMapper;
using Domain;
using Infra.Adapters;

namespace Infra.RepositoriesImp;

public class MenuItemRepositoryImp(ApplicationDbContext applicationDbContext, IMapper mapper)
    : BaseRepositoryImp<MenuItem>(applicationDbContext, mapper), MenuItemRepository
{
    private readonly ApplicationDbContext _applicationDbContext1 = applicationDbContext;

    public IEnumerable<MenuItem> GetMenuItemsByIds(long[] ids)
    {
        return _applicationDbContext1.MenuItems
            .Where(q => ids.Contains(q.Id))
            .ToList();
    }
}