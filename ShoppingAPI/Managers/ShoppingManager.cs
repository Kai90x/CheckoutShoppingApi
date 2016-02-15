using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using ShoppingAPI.DataAccess;
using ShoppingAPI.Managers.Interfaces;

namespace ShoppingAPI.Managers
{
    public class ShoppingManager : IShoppingManager
    {
        
        private readonly ShoppingEntities _entities;

        public ShoppingManager()
        {
            _entities = new ShoppingEntities();
        }

        public void add(string name, int quantity)
        {
            var existingItem =
                _entities.Shoppings.FirstOrDefault(se => se.name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (existingItem != null)
                throw new Exception(string.Format("{0} already exists",name));
            
            var item = new Shopping
            {
                name = name,
                quantity = quantity
            };

            _entities.Shoppings.Add(item);
            _entities.SaveChanges();
        }

        public void update(int id, int quantity)
        {
            var existingItem =
                _entities.Shoppings.FirstOrDefault(se => se.Id == id);
            if (existingItem == null)
                throw new Exception(string.Format("item with id {0} does not exists", id));

            existingItem.quantity = quantity;

            _entities.Shoppings.AddOrUpdate(existingItem);
            _entities.SaveChanges();
        }

        public void delete(int id)
        {
            var existingItem =
                _entities.Shoppings.FirstOrDefault(se => se.Id == id);
            if (existingItem == null)
                throw new Exception(string.Format("item with id {0} does not exists", id));

            _entities.Shoppings.Remove(existingItem);
            _entities.SaveChanges();
        }

        public Shopping get(string name)
        {
            return _entities.Shoppings.FirstOrDefault(se => se.name.Equals(name));
        }

        public List<Shopping> get()
        {
            return _entities.Shoppings.ToList();
        }
    }
}