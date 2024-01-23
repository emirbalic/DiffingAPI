using API.DTOs;
using API.Models;

namespace API.Interfaces
{
    public interface IItemRepository
    {
        ICollection <Item> GetItems();
        Item GetItem(int id);
        bool UpdateItem(int id, Item item);
        bool Save();
    }
}
