using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace esnaf_stok
{
 
    public partial class stok_takip : Form
    {
        public stok_takip()
        {
            InitializeComponent();
        }

        private void stok_takip_Load(object sender, EventArgs e)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ouysa\source\repos\esnaf-stok\bin\Debug\esnaf1.accdb;";
            string query = "SELECT * FROM urun_bilgileri";


            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                DataTable dt = new DataTable();
                try
                {
                    connection.Open();
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" +ex.Message);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            stoga_ürün_alım sta = new stoga_ürün_alım();
            sta.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 ana = new Form1();
            ana.Show();
            this.Hide();
        }
    }   
}
