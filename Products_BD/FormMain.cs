using Products_BD.Controller;
using tEST_bd.Db;

namespace Products_BD
{
    public partial class FormMain : Form
    {
        private FormMAinController _formMainController;
        public FormMain()
        {
            InitializeComponent();

            _formMainController = new FormMAinController(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _formMainController.PrintToDoDataGritViewProducts();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pro = textBoxPro.Text;
            string tel = textBoxTel.Text;
            string name = textBoxName.Text;
            string add = textBoxAdd.Text;
            int price = int.Parse(textBoxPri.Text);

            _formMainController.CreateToDataGritViewProducts(pro, tel, name, add, price);
            _formMainController.PrintToDoDataGritViewProducts();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            DialogResult res = MessageBox.Show(
                    "Удалить?",
                    "?",
                    MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                _formMainController.DeleteProductsByIdToDatGridView(id);
            }
            _formMainController.PrintToDoDataGritViewProducts();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBoxUpdate.Text);
            string pro = textBoxPro.Text;
            string tel = textBoxTel.Text;
            string name = textBoxName.Text;
            string add = textBoxAdd.Text;
            int price = int.Parse(textBoxPri.Text);

            _formMainController.UpdateToDataGritViewProducts(pro, tel, name, add, price, id);
            _formMainController.PrintToDoDataGritViewProducts();
        }
    }
}