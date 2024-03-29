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
    public partial class talep : Form
    {

        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ouysa\source\repos\esnaf-stok\bin\Debug\esnaf1.accdb;";
        public talep()
        {
            InitializeComponent();
        }
        data_yenile yenile = new data_yenile();
        private void talep_Load(object sender, EventArgs e)
        {
            yenile.data_taleb(dataGridView1);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string urunAdi = textBox1.Text;
            string barkodNo = textBox2.Text;
            string iletisim = textBox3.Text;
            decimal alimFiyati = numericUpDown1.Value; // Decimal değeri numericUpDown'dan alınmalıdır.
            int stokAdet = Convert.ToInt32(numericUpDown2.Value); // NumericUpDown'tan int değeri alınmalıdır.
            DateTime teslimatTarihi = dateTimePicker1.Value; // DateTime değeri dateTimePicker'dan alınmalıdır.

            // Veritabanına ekleme işlemi
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = "INSERT INTO urun_tedarik ([urun-adi], [tedarikci-şirket], [iletişim], [alım-fiyatı-adet],[talep-adet],[teslimat-tarihi] ) VALUES (@UrunAdi, @BarkodNo, @İletişim, @AlimFiyati ,@StokAdet, @TeslimatTarihi )";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UrunAdi", urunAdi);
                    command.Parameters.AddWithValue("@BarkodNo", barkodNo);
                    command.Parameters.AddWithValue("@İletişim", iletisim);
                    command.Parameters.AddWithValue("@AlimFiyati", alimFiyati);
                    command.Parameters.AddWithValue("@StokAdet", stokAdet);
                    command.Parameters.AddWithValue("@TeslimatTarihi", teslimatTarihi);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show("Ürün başarıyla Talep edildi.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message);
                    }
                }
                yenile.data_taleb(dataGridView1);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int selectedId = Convert.ToInt32(selectedRow.Cells["id"].Value);

                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ouysa\source\repos\esnaf-stok\bin\Debug\esnaf1.accdb;";

                string query = "DELETE FROM urun_tedarik WHERE id = @SelectedId";

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SelectedId", selectedId);

                        try
                        {
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();
                            MessageBox.Show("Talep başarıyla silindi.");
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
                MessageBox.Show("Talep iptali için bir talep seç.");
            }
            yenile.data_urunbilgi(dataGridView1);
        }
    }
    }
}
