using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Bioskop
{
    class Popunjavac
    {
        public static void Popuni(ComboBox cb, string selectUpit)
        {
            Konekcija kon = new Konekcija();
            SqlConnection konekcija = new SqlConnection();
            try
            {
                konekcija = kon.KreirajKonekciju();
                konekcija.Open();

                SqlDataAdapter da = new SqlDataAdapter(selectUpit, konekcija);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (cb != null)
                {
                    cb.ItemsSource = dt.DefaultView;
                }
                da.Dispose();
                dt.Dispose();

            }
            catch(SqlException ex) { MessageBox.Show(ex.Message,"Greska",MessageBoxButton.OK,MessageBoxImage.Error); }
            finally {
            if(konekcija!=null)
                    konekcija.Close();
            
            }


        }
    }
}
