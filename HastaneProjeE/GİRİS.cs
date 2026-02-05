using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneProjeE
{
    public partial class GİRİS : Form
    {
        public GİRİS()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HastaGiris h = new HastaGiris();
            h.Show();
           // this.Hide();
        }

        private void btnsecretergirirs_Click(object sender, EventArgs e)
        {
            SecreterGiris s = new SecreterGiris();  
            s.Show();
            //this.Hide();
        }

        private void btndoctorgiris_Click(object sender, EventArgs e)
        {
            DoctorGiris fr = new DoctorGiris();
            fr.Show();
           // this.Hide();
        }

        private void GİRİS_Load(object sender, EventArgs e)
        {

        }
    }
}
