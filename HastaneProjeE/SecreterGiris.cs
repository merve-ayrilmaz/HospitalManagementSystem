using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HastaneProjeE
{
    public partial class SecreterGiris : Form
    {
        public SecreterGiris()
        {
            InitializeComponent();
        }

      SqlBaglantisi bgl = new SqlBaglantisi();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From Tbl_Secreter where SecreterTC=@p1  and SecreterSifre=@p2 " , bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskTC.Text);
            komut.Parameters.AddWithValue("@p2", txtsifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                SecreterDetay fr = new SecreterDetay();
                fr.TCnum = mskTC.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı TC veya Şifre.", "DİKKAT!", MessageBoxButtons.OK, MessageBoxIcon.None );
            }


        }
    }
}
