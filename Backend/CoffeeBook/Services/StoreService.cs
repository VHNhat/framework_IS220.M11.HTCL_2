﻿using CoffeeBook.DataAccess;
using CoffeeBook.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeBook.Services
{
    public class StoreService
    {
        private readonly IConfiguration _config;
        private readonly string sqlDatasource;
        private readonly Context _context;

        public StoreService() { }
        public StoreService(IConfiguration config)
        {
            _config = config;
            sqlDatasource = _config.GetConnectionString("CoffeeBook");
        }
        public StoreService(IConfiguration config, Context context)
        {
            _config = config;
            sqlDatasource = _config.GetConnectionString("CoffeeBook");
            _context = context;
        }

        public List<Store> GetAllStores()
        {
            var stores = _context.Stores.ToList();
            return stores;
        }

        public Store GetStoreById(int id)
        {
            var store = _context.Stores.Where(w => w.Id == id).FirstOrDefault();
            return store;
        }

        public int Post(Store model)
        {
            _context.Stores.Add(model);
            var resutl = _context.SaveChanges();
            return resutl;
        }

        public int Put(int id, Store model)
        {
            var store = _context.Stores.Single(s => s.Id == id);
            store.StoreName = model.StoreName;
            store.Description = model.Description;
            store.Address = model.Address;
            store.Country = model.Country;
            store.Phone = model.Phone;
            store.ManagerId = model.ManagerId;

            var resulut = _context.SaveChanges();
            return resulut;
        }

        public int Delete(int id)
        {
            var store = _context.Stores.Single(s=>s.Id == id);
            _context.Stores.Remove(store);

            var resulut = _context.SaveChanges();
            return resulut;
        }
    }
}
