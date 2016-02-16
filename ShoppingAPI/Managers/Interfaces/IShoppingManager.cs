using System.Collections.Generic;
using ShoppingAPI.DataAccess;

namespace ShoppingAPI.Managers.Interfaces
{
    public interface IShoppingManager
    {
        Shopping add(string name, int quantity);
        Shopping update(string name, int quantity);
        void delete(string name);
        Shopping get(string name);
        List<Shopping> get();
    }
}
