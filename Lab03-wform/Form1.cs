using System.Data;
using System.Data.SqlClient;

namespace Lab03_wform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cadena = "Server=LAB1507-15\\SQLEXPRESS02; Database=Lab03BDR; Integrated Security=True";
            SqlConnection connection = new SqlConnection(cadena);

            connection.Open();

            SqlCommand command = new SqlCommand("Select * from products", connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            connection.Close();

            dataGridView1.DataSource = dataTable;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cadena = "Server=LAB1507-15\\SQLEXPRESS02; Database=Lab03BDR; Integrated Security=True";
            SqlConnection connection = new SqlConnection(cadena);

            connection.Open();
            SqlCommand command = new SqlCommand("Select * from products", connection);

            List<Products> listaProducts = new List<Products>();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                connection.Close();

                Products products = new Products();
                products.ProductID = reader["Productid"].ToString();
                products.Name = reader["name"].ToString();
                products.Price = reader["price"].ToString();

                listaProducts.Add(products);
            
            }
            dataGridView1.DataSource = listaProducts;
        }
    }
}