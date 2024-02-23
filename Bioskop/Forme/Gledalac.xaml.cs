using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bioskop
{
    /// <summary>
    /// Interaction logic for Gledalac.xaml
    /// </summary>
    public partial class Gledalac : Window
    {
        
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private int? id;
        private static string upit = @"select * from Grickalice_i_pice";
      
        public Gledalac()
        {
            InitializeComponent();
            txtIme.Focus();
            konekcija = kon.KreirajKonekciju();
            Popunjavac.Popuni(cbGrickalice, upit);
           
        }
        public Gledalac(bool azuriraj, int? id)
        {
            InitializeComponent();
            txtIme.Focus();
            konekcija = kon.KreirajKonekciju();
           
            Popunjavac.Popuni(cbGrickalice, upit);
            this.azuriraj = azuriraj;
            this.id = id;
            


        }
        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@Ime", SqlDbType.NVarChar).Value = txtIme.Text;
                cmd.Parameters.Add("@Prezime", SqlDbType.NVarChar).Value = txtPrezime.Text;
              
                cmd.Parameters.Add("@idGrickalice", SqlDbType.Int).Value = cbGrickalice.SelectedValue;
                if (azuriraj)
                {

                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmd.CommandText = @"update Gledalac
                                        set Ime=@Ime,Prezime=@Prezime,IdGrickalice=@idGrickalice
                                            where IdGledaoca=@id";

                    id = null;
                }
                else
                {

                    cmd.CommandText = @"insert into Gledalac
                                                       values(@idGrickalice,@Ime,@Prezime)";

                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();

            }
            catch (SqlException ex) { MessageBox.Show(ex.Message); }
            finally
            {
                if (konekcija != null)
                { konekcija.Close(); }
            }
        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
