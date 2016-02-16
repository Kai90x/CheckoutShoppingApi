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

        public Shopping add(string name, int quantity)
        {
            var existingItem =
                _entities.Shoppings.FirstOrDefault(se => se.name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (existingItem != null)
                throw new Exception(string.Format("{0} already exists",name));
            
            var item = new Shopping
            {
                name = name,
                quantity = quantity,
                date_created = DateTime.Now,
                date_modified = DateTime.Now
            };

            _entities.Shoppings.Add(item);
            _entities.SaveChanges();

            return item;
        }

        public Shopping update(string name, int quantity)
        {
            var existingItem = get(name);
            if (existingItem == null)
                throw new Exception(string.Format("item {0} does not exists", name));

            existingItem.quantity = quantity;
            existingItem.date_modified = DateTime.Now;

            _entities.Shoppings.AddOrUpdate(existingItem);
            _entities.SaveChanges();

            return existingItem;
        }

        public void delete(string name)
        {
            var existingItem = get(name);
            if (existingItem == null)
                throw new Exception(string.Format("item {0} does not exists", name));

            _entities.Shoppings.Remove(existingItem);
            _entities.SaveChanges();
        }

        public Shopping get(string name)
        {
            return _entities.Shoppings.FirstOrDefault(se => se.name.Equals(name,StringComparison.OrdinalIgnoreCase));
        }

        public List<Shopping> get()
        {
            return _entities.Shoppings.ToList();
        }
    }
}