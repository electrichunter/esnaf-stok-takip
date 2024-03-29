using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace esnaf_stok
{
    public partial class stoga_ürün_alım : Form
    {
        public stoga_ürün_alım()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        data_yenile yenile = new data_yenile();
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ouysa\source\repos\esnaf-stok\bin\Debug\esnaf1.accdb;";
        private void stoga_ürün_alım_Load(object sender, EventArgs e)
        {

            yenile.data_urunbilgi(dataGridView1);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string urunAdi = textBox1.Text;
            string barkodNo = textBox2.Text;
            decimal alimFiyati = Convert.ToDecimal(numericUpDown1.Text);
            int stokAdet = Convert.ToInt32(numericUpDown2.Text);

            // Veritabanına ekleme işlemi
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = "INSERT INTO urun_bilgileri ([urun-adi], [urun-barkod], [alım-fiyat], [urun-stok] ) VALUES (@UrunAdi, @BarkodNo, @AlimFiyati, @StokAdet)";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UrunAdi", urunAdi);
                    command.Parameters.AddWithValue("@BarkodNo", barkodNo);
                    command.Parameters.AddWithValue("@AlimFiyati", alimFiyati);
                    command.Parameters.AddWithValue("@StokAdet", stokAdet);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show("Ürün başarıyla eklendi.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message);
                    }
                }
                yenile.data_urunbilgi(dataGridView1);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int selectedId = Convert.ToInt32(selectedRow.Cells["id"].Value); 

                string urunAdi = selectedRow.Cells["urun-adi"].Value.ToString();
                string barkodNo = selectedRow.Cells["urun-barkod"].Value.ToString();
                decimal alimFiyati = Convert.ToDecimal(selectedRow.Cells["alım-fiyat"].Value);
                int stokAdet = Convert.ToInt32(selectedRow.Cells["urun-stok"].Value);

                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ouysa\source\repos\esnaf-stok\bin\Debug\esnaf1.accdb;";

                string query = "UPDATE urun_bilgileri SET urun_adi = @UrunAdi, urun_barkod = @BarkodNo, alim_fiyat = @AlimFiyati, urun_stok = @StokAdet WHERE id = @SelectedId";

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UrunAdi", urunAdi);
                        command.Parameters.AddWithValue("@BarkodNo", barkodNo);
                        command.Parameters.AddWithValue("@AlimFiyati", alimFiyati);
                        command.Parameters.AddWithValue("@StokAdet", stokAdet);
                        command.Parameters.AddWithValue("@SelectedId", selectedId); 

                        try
                        {
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();
                            MessageBox.Show("Ürün bilgileri güncellendi.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Güncellemek için bir ürün seçiniz.");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int selectedId = Convert.ToInt32(selectedRow.Cells["id"].Value); 

                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ouysa\source\repos\esnaf-stok\bin\Debug\esnaf1.accdb;";

                string query = "DELETE FROM urun_bilgileri WHERE id = @SelectedId";

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SelectedId", selectedId); 

                        try
                        {
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();
                            MessageBox.Show("Ürün başarıyla silindi.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Hata: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Silmek için bir ürün seçiniz.");
            }
            yenile.data_urunbilgi(dataGridView1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 ana = new Form1();
            ana.Show();
            this.Hide();
        }
    }
}