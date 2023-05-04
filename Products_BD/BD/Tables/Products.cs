using Npgsql;
using Products_BD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace tEST_bd.Db
{
    internal class TableWorkers
    {
        public NpgsqlConnection _connection;

        public TableWorkers(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public  List<ProductsModel> SelectAllWorkers()
        {
            List<ProductsModel> products = new List<ProductsModel>();

            string sqlRequest = "SELECT * FROM products ORDER BY id";
            NpgsqlCommand command = new NpgsqlCommand(sqlRequest, _connection);

            NpgsqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                int id = dataReader.GetInt32(dataReader.GetOrdinal("id"));
                string product = dataReader.GetString(dataReader.GetOrdinal("product"));
                string numberTel = dataReader.GetString(dataReader.GetOrdinal("number_tel"));
                string name = dataReader.GetString(dataReader.GetOrdinal("name"));
                string address = dataReader.GetString(dataReader.GetOrdinal("address"));
                int price = dataReader.GetInt32(dataReader.GetOrdinal("price"));


                products.Add(new ProductsModel()
                {
                    Id = id,
                    Products = product,
                    NumberTel = numberTel,
                    Name = name,
                    Address = address,
                    Price = price
                });
            }

            dataReader.Close();

            return products;
        }

        public void CreateNewProducts(string prod, string tel, string name, string address, int price)
        {
            string sqlRequest = $"INSERT INTO products (product, number_tel, name, address, price) " +
                $"VALUES ('{prod}', '{tel}', '{name}', '{address}', {price})";

            var cmd = new NpgsqlCommand(sqlRequest, _connection);
            cmd.ExecuteNonQuery();
        }

        public void DeleteProducts(string id)
        {
            string sqlRequest = $"DELETE FROM products WHERE id = {id}";

            var cmd = new NpgsqlCommand(sqlRequest, _connection);
            cmd.ExecuteNonQuery();
        }

        public void UpdateNewProducts(string prod, string tel, string name, string address, int price,int id)
        {
            if (prod != null) 
            {
                string sqlRequest = $"UPDATE products SET product = '{prod}'  WHERE id = {id};";

                var cmd = new NpgsqlCommand(sqlRequest, _connection);
                cmd.ExecuteNonQuery();
            }

            if (tel != null)
            {
                string sqlRequest = $"UPDATE products SET number_tel = '{tel}'  WHERE id = {id};";

                var cmd = new NpgsqlCommand(sqlRequest, _connection);
                cmd.ExecuteNonQuery();
            }

            if (name != null)
            {
                string sqlRequest = $"UPDATE products SET name = '{name}'  WHERE id =  {id} ;";

                var cmd = new NpgsqlCommand(sqlRequest, _connection);
                cmd.ExecuteNonQuery();
            }

            if (address != null)
            {
                string sqlRequest = $"UPDATE products SET address = '{address}'  WHERE id = {id};";

                var cmd = new NpgsqlCommand(sqlRequest, _connection);
                cmd.ExecuteNonQuery();
            }

            if (price != 1)
            {
                string sqlRequest = $"UPDATE products SET price = '{price}'  WHERE id = {id};";

                var cmd = new NpgsqlCommand(sqlRequest, _connection);
                cmd.ExecuteNonQuery();
            }
        }
    }
}