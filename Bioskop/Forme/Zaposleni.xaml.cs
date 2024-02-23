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
    /// Interaction logic for Zaposleni.xaml
    /// </summary>
    public partial class Zaposleni : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private int? id;
        public Zaposleni()
        {
            InitializeComponent();
            txtIme.Focus();
            konekcija = kon.KreirajKonekciju();
        }
        public Zaposleni(bool azuriraj, int? id)
        {
            InitializeComponent();
            txtIme.Focus();
            konekcija = kon.KreirajKonekciju();
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
                if (txtJmbg.Text.Length == 13)
                    cmd.Parameters.Add("@JMBG", SqlDbType.VarChar).Value = txtJmbg.Text;
                else
                {
                    MessageBox.Show("JMBG mora imati 13 karaktera!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;


                }
                if (azuriraj)
                {

                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmd.CommandText = @"update Zaposleni
                                        set Ime=@Ime,Prezime=@Prezime,JMBG=@JMBG
                                            where IdZaposleni=@id";

                    id = null;
                }
                else
                {

                    cmd.CommandText = @"insert into Zaposleni values(@Ime,@Prezime,@JMBG)";

                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
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
