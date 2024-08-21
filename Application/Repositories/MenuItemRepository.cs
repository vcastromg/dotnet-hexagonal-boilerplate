using Domain;

namespace Application.Repositories;

public interface MenuItemRepository : BaseRepository<MenuItem>
{
    public IEnumerable<MenuItem> GetMenuItemsByIds(long[] ids);
}