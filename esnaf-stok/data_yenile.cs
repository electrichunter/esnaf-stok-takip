using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace esnaf_stok
{
    internal class data_yenile
    {
        public void data_urunbilgi(DataGridView dataGridView1)
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
                    MessageBox.Show("Error:" + ex.Message);
                }
            }



        }



        public void data_taleb(DataGridView dataGridView1)
        {

            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ouysa\source\repos\esnaf-stok\bin\Debug\esnaf1.accdb;";
            string query = "SELECT * FROM urun_tedarik";

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
                    MessageBox.Show("Error:" + ex.Message);
                }
            }
        }

    

    }
}
 