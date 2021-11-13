﻿using CoffeeBook.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeBook.Services
{
    public class SupplierService
    {
        private readonly IConfiguration _config;
        private readonly string sqlDataSource;

        public SupplierService()
        {
        }

        public SupplierService(IConfiguration config)
        {
            _config = config;
            sqlDataSource = _config.GetConnectionString("CoffeeBook");
        }

        public DataTable findAll()
        {
            DataTable table = new DataTable();
            string query = "select * from Supplier";
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return table;
        }

        public DataTable save(Supplier supplier)
        {
            DataTable table = new DataTable();
            string query = @$"insert into Supplier(name, description, address, city, country, phone, url)
                             values('{supplier.Name}',
                             '{supplier.Description}',
                             '{supplier.Address}',
                             '{supplier.City}',
                             '{supplier.Country}',
                             '{supplier.Phone}',
                             '{supplier.Url}')";

            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return table;
        }

        public DataTable deleteById(int id)
        {
            DataTable table = new DataTable();
            string query = @$"delete from Supplier
                              where id = {id}";

            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return table;
        }

        public DataTable update(Supplier supplier)
        {
            DataTable table = new DataTable();
            string query = @$"update Supplier set
                              name = '{supplier.Name}',
                              description = '{supplier.Description}',
                              address = '{supplier.Address}',
                              city = '{supplier.City}',
                              country = '{supplier.Country}',
                              phone = '{supplier.Phone}',
                              url = '{supplier.Url}'
                              where id = {supplier.Id}";

            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return table;
        }
    }
}