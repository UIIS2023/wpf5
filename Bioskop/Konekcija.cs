using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace Bioskop
{
    public class Konekcija
    {
       
        public SqlConnection KreirajKonekciju()
        {
           
            SqlConnectionStringBuilder ccnSb = new SqlConnectionStringBuilder
            {
                DataSource = @"DESKTOP-0HK0OOI\SQLEXPRESS", 
                InitialCatalog = "Bioskop2023", 
                IntegratedSecurity = true 
            };
            string con = ccnSb.ToString();
            SqlConnection konekcija = new SqlConnection(con);
            return konekcija;
        }
    }
}
