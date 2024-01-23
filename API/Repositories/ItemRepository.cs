using API.Data;
using API.Interfaces;
using API.Models;

namespace API.Repositories
{
    public class ItemRepository: IItemRepository
    {
        private readonly DataContext _context;

        public ItemRepository(DataContext context)
        {
            _context = context;
        }

        public Item GetItem(int id)
        {
            return _context.Find<Item>(id);
        }

        public ICollection<Item> GetItems()
        {
            return _context.Items.ToList();
        }

        public bool UpdateItem(int id, Item item)
        {

            var existingItem = _context.Find<Item>(id);
            if (existingItem != null)
            {

            _context.Items.Update(item);
            }
            else
            {
                _context.Items.Add(item);
            }
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

    }
}
