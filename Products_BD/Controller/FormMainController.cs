using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tEST_bd.Db;

namespace Products_BD.Controller
{
    internal class FormMAinController
    {
        private FormMain FormMain;
        private DbManager _dbManager;

        public FormMAinController(FormMain formfirst)
        {
            FormMain = formfirst;
            _dbManager = DbManager.Instance;
        }

        public void PrintToDoDataGritViewProducts()
        {
            DataGridView dataGridView = (DataGridView)FormMain.Controls["dataGridView1"];

            dataGridView.DataSource = null;
            dataGridView.DataSource = _dbManager.TableWorkers.SelectAllWorkers();

            dataGridView.Columns["Id"].HeaderText = "Id";
            dataGridView.Columns["Products"].HeaderText = "Products";
            dataGridView.Columns["NumberTel"].HeaderText = "NumberTel";
            dataGridView.Columns["Name"].HeaderText = "Name";
            dataGridView.Columns["Address"].HeaderText = "Address";
            dataGridView.Columns["Price"].HeaderText = "Price";
        }

        public void CreateToDataGritViewProducts(string pro, string tel, string name, string add, int price)
        {
            _dbManager.TableWorkers.CreateNewProducts(pro, tel, name, add, price);
        }

        public void DeleteProductsByIdToDatGridView(string id) 
        {
            _dbManager.TableWorkers.DeleteProducts(id);
        }
        public void UpdateToDataGritViewProducts(string pro, string tel, string name, string add, int price, int id)
        {
            _dbManager.TableWorkers.UpdateNewProducts(pro, tel, name, add, price, id);
        }

    }
}
