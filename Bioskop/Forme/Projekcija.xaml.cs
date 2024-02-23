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
    /// Interaction logic for Projekcija.xaml
    /// </summary>
    public partial class Projekcija : Window
    {
        private bool azuriraj;
        private int? id;
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private static string Film = @"select * from Film";
        private static string Prikazivanje = @"select tipPrikazivanja+' | '+CONVERT(NVARCHAR(30),Prikazivanje.Vreme,120) as 'prikaz',IdPrikazivanje from Prikazivanje";
        private static string upit = @"select * from Sala";
        public Projekcija()
        {
            InitializeComponent();

            Popunjavac.Popuni(cbFilm, Film);
            Popunjavac.Popuni(cbPrikazivanje, Prikazivanje);
            Popunjavac.Popuni(cbSale, upit);
            konekcija = kon.KreirajKonekciju();
        }
        public Projekcija(bool azuriraj,int? id)
        {
            InitializeComponent();

            Popunjavac.Popuni(cbFilm, Film);
            Popunjavac.Popuni(cbPrikazivanje, Prikazivanje);
            Popunjavac.Popuni(cbSale, upit);
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
                cmd.Parameters.Add("@Film", SqlDbType.Int).Value = (int)cbFilm.SelectedValue;
                cmd.Parameters.Add("@Sala", SqlDbType.Int).Value = (int)cbSale.SelectedValue;
                cmd.Parameters.Add("@Prikazivanje", SqlDbType.Int).Value = (int)cbPrikazivanje.SelectedValue;
                if (azuriraj)
                {

                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmd.CommandText = @"update Projekcije
                                        set IdFilm=@Film,IdSale=@Sala,IdPrikazivanja=@Prikazivanje
                                            where IdProjekcije=@id";

                    id= null;
                }
                else
                {

                    cmd.CommandText = @"insert into Projekcije values(@Film,@Sala,@Prikazivanje)";

                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();

            }
            catch (Exception ex) { MessageBox.Show("Greska "+ex.Message); }
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    
    }
}
