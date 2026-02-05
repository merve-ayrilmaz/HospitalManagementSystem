using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneProjeE
{
    internal class SqlBaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-IOMSQH7\\SQLEXPRESS;Initial Catalog=HastanePROJE;Integrated Security=True;");
            baglan.Open();
            return baglan;
        }
    }                                                    
}