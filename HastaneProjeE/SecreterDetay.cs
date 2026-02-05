using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneProjeE
{
    public partial class SecreterDetay : Form
    {
        public SecreterDetay()
        {
            InitializeComponent();
        }


        public string TCnum;

        SqlBaglantisi bgl = new SqlBaglantisi();
        private void SecreterDetay_Load(object sender, EventArgs e)
        {
            lbltc.Text = TCnum;



            //Ad Soyad Çekme
            SqlCommand komut2 = new SqlCommand("Select SecreterAdSoyad From Tbl_Secreter where SecreterTc=@p1", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", lbltc.Text);
            SqlDataReader dr1 = komut2.ExecuteReader();
            while (dr1.Read())
            {
                lbladsoyad.Text = dr1[0].ToString();
            }


            //Bransları aktarma
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select BransAd From Tbl_Brans ", bgl.baglanti());
            da.Fill(dt1);
            dataGridView2.DataSource = dt1;

            //Doktorları aktarma
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select (DoctorAd +' '+DoctorSoyad) as 'Doctor' , DoctorBrans  From Tbl_Doctor ", bgl.baglanti());
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;

            //Branşları comboboxa aktarma
            SqlCommand komut3 = new SqlCommand("Select BransAd From Tbl_Brans", bgl.baglanti());
            SqlDataReader dr2 = komut3.ExecuteReader();
            while (dr2.Read())
            {
                cmbbrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();

        }



        //Doktorları comboboxa aktarma
        private void cmbbrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbdoctor.Items.Clear();

            SqlCommand komut4 = new SqlCommand("Select DoctorAd,DoctorSoyad From Tbl_Doctor where DoctorBrans=@p1", bgl.baglanti());
            komut4.Parameters.AddWithValue("@p1", cmbbrans.Text);
            SqlDataReader dr3 = komut4.ExecuteReader();
            while (dr3.Read())
            {
                cmbdoctor.Items.Add(dr3[0] + " " + dr3[1]);
            }
        }


        //randevuyu kaydetme
        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komutkaydet = new SqlCommand("insert into Tbl_Randevu (RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoctor) values (@r1,@r2,@r3,@r4)", bgl.baglanti());
            komutkaydet.Parameters.AddWithValue("@r1", msktarih.Text);
            komutkaydet.Parameters.AddWithValue("@r2", msksaat.Text);
            komutkaydet.Parameters.AddWithValue("@r3", cmbbrans.Text);
            komutkaydet.Parameters.AddWithValue("@r4", cmbdoctor.Text);
            komutkaydet.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Oluşturuldu");
        }

        private void btnduyuruolustur_Click(object sender, EventArgs e)
        {
            SqlCommand komutduyuru = new SqlCommand("insert into Tbl_Duyuru (Duyuru) values (@d1)", bgl.baglanti());
            komutduyuru.Parameters.AddWithValue("@d1", rchduyuru.Text);
            komutduyuru.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Duyuru Oluşturuldu","İSTEĞİNİZ ALINDI!",MessageBoxButtons.OKCancel,MessageBoxIcon.Asterisk);
        }

        private void btndoctorpanel_Click(object sender, EventArgs e)
        {
            DoctorPanel fr = new DoctorPanel();
            fr.Show();
        }

        private void btnbranspanel_Click(object sender, EventArgs e)
        {
            BransPanel fr = new BransPanel();
            fr.Show();
        }

        private void btnrandevuliste_Click(object sender, EventArgs e)
        {
            RandevuListesi fr = new RandevuListesi();
            fr.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Duyurular fr = new Duyurular();
            fr.Show();
        }
    }
}
