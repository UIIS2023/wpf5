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
    /// Interaction logic for Prikazivanje.xaml
    /// </summary>
    public partial class Prikazivanje : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private int? id;
        public Prikazivanje()
        {
            InitializeComponent();
            txtTipPrikazivanja.Focus();
            konekcija = kon.KreirajKonekciju();
        }
        public Prikazivanje(bool azuriraj, int? id)
        {
            InitializeComponent();
            txtTipPrikazivanja.Focus();
            konekcija = kon.KreirajKonekciju();
            this.azuriraj = azuriraj;
            this.id = id;
        }

        private void txtTipPrikazivanja_TextChanged(object sender, TextChangedEventArgs e)
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
                cmd.Parameters.Add("@Tip", SqlDbType.VarChar).Value = txtTipPrikazivanja.Text;
                cmd.Parameters.Add("@Vreme", SqlDbType.DateTime).Value = DateTime.Parse(dpVreme.Text);

                if (azuriraj)
                {

                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmd.CommandText = @"update Prikazivanje
                                        set tipPrikazivanja=@Tip,Vreme=@Vreme
                                            where IdPrikazivanje=@id";

                    id = null;
                }
                else
                {

                    cmd.CommandText = @"insert into Prikazivanje values(@Tip,@Vreme)";

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
