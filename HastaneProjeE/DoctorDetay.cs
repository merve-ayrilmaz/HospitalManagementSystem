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
    public partial class DoctorDetay : Form
    {
        public DoctorDetay()
        {
            InitializeComponent();
        }


        SqlBaglantisi bgl = new SqlBaglantisi();


        public string TC;


        private void DoctorDetay_Load(object sender, EventArgs e)
        {
            lbltc.Text = TC;
        }
    }
}
