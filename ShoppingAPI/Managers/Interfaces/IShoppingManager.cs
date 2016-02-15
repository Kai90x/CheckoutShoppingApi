using System.Collections.Generic;
using ShoppingAPI.DataAccess;

namespace ShoppingAPI.Managers.Interfaces
{
    public interface IShoppingManager
    {
        void add(string name,int quantity);
        void update(int id, int quantity);
        void delete(int id);
        Shopping get(string name);
        List<Shopping> get();
    }
}
