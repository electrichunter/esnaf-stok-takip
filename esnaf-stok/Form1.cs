using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace esnaf_stok
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stok_takip  st = new stok_takip();
            st.Show();
            this.Hide();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            stoga_ürün_alım sta=new stoga_ürün_alım();
            sta.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            talep talep = new talep();
            talep.Show();
            this.Hide();
        }
    }
}
