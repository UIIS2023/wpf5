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
    /// Interaction logic for Film.xaml
    /// </summary>
    public partial class Film : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija=new SqlConnection();
        private bool azuriraj;
        private int? id;

        public Film()
        {
            InitializeComponent();
            txtNaziv.Focus();
            konekcija = kon.KreirajKonekciju();
        }
        public Film(bool azuriraj, int? id)
        {
            InitializeComponent();
            txtNaziv.Focus();
            konekcija = kon.KreirajKonekciju();
            this.azuriraj= azuriraj;
            this.id = id;
        
        
        }

        private void txtNaziv_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtTrajanje_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

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
                cmd.Parameters.Add("@Naslov",SqlDbType.NVarChar).Value=txtNaziv.Text;
                cmd.Parameters.Add("@Zanr", SqlDbType.NVarChar).Value = txtZanr.Text;
                cmd.Parameters.Add("@Trajanje", SqlDbType.Int).Value = int.Parse(txtTrajanje.Text);
                if (azuriraj)
                {

                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmd.CommandText = @"update Film 
                                        set Naslov=@Naslov,Zanr=@Zanr,Trajanje=@Trajanje
                                            where IdFilm=@id";

                    id = null;
                }
                else {

                    cmd.CommandText = @"insert into Film values(@Naslov,@Zanr,@Trajanje)";
                
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();
            
            }
            catch (Exception ex) { MessageBox.Show("Unos odredjenih vrednosti"); }
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
