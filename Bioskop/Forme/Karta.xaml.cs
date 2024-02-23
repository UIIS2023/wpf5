using Bioskop.Forme;
using System;

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for Karta.xaml
    /// </summary>
    public partial class Karta : Window
    {
        private bool azuriraj;
        private int? id;
       
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private static string zaposleni = @"select Ime+' '+Prezime as 'zaposleni', IdZaposleni from Zaposleni";
        private static string Gledalac = @"select Ime+' '+Prezime as 'gledalac',IdGledaoca from Gledalac";
        private static string projekcija = @"select Naslov +' | '+tipPrikazivanja+' | '+CONVERT(NVARCHAR(30),Prikazivanje.Vreme,120) as 'prikazivanje',IdProjekcije from Projekcije join Prikazivanje on Projekcije.IdPrikazivanja=Prikazivanje.IdPrikazivanje
                                                                                                                 join Film on Projekcije.IdFilm=Film.IdFilm";

        private static string kapacitet = @"select Kapacitet from Projekcije join Sala on Projekcije.IdSale=Sala.IdSale
                                                                            where IdProjekcije=";


        private static string kartaSelect = @"select count(*) from Karta join Projekcije on Karta.IdProjekcije=Projekcije.IdProjekcije where Karta.IdProjekcije=";

        private static string brojSedistaSelect = @"select brojSedista from Karta join Projekcije on Karta.IdProjekcije=Projekcije.IdProjekcije
                                                                                     join Sala on Projekcije.IdSale=Sala.IdSale
                                                                                            where Karta.IdProjekcije=";

        private static string brojSaleSelect = @"select Projekcije.IdSale from Projekcije join Sala on Projekcije.IdSale=Sala.IdSale where IdProjekcije=";
        public Karta()
        {
            InitializeComponent();
            Popunjavac.Popuni(cbGledalac, Gledalac);
            Popunjavac.Popuni(cbProjekcija, projekcija);
            Popunjavac.Popuni(cbZaposleni, zaposleni);
            konekcija = kon.KreirajKonekciju();
        }
       
        public Karta(bool azuriraj,int? id)
        {
            InitializeComponent();
            Popunjavac.Popuni(cbGledalac, Gledalac);
            Popunjavac.Popuni(cbProjekcija, projekcija);
            Popunjavac.Popuni(cbZaposleni, zaposleni);
            konekcija = kon.KreirajKonekciju();
            this.id = id;
            this.azuriraj = azuriraj;
           
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
                cmd.Parameters.Add("@Zaposleni", SqlDbType.Int).Value = (int)cbZaposleni.SelectedValue;
                cmd.Parameters.Add("@Gledalac", SqlDbType.Int).Value = (int)cbGledalac.SelectedValue;
                cmd.Parameters.Add("@Projekcija", SqlDbType.Int).Value = (int)cbProjekcija.SelectedValue;
                cmd.Parameters.Add("@Cena", SqlDbType.Float).Value = float.Parse(txtCena.Text);
                cmd.Parameters.Add("@BrojSedista", SqlDbType.Int).Value = int.Parse(txtBrojSedista.Text);
                int[] niz = zauzetaSedista();
                for (int i = 0; i < niz.Length; i++)
                {
                    if (niz[i] == int.Parse(txtBrojSedista.Text))
                    {
                        MessageBox.Show("Mesto je vec zauzeto odaberite neko drugo mesto!", "Greska", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                }
                if (azuriraj)
                {

                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmd.CommandText = @"update Karta
                                        set IdZaposlenog=@Zaposleni,IdGledaoca=@Gledalac,IdProjekcije=@Projekcija,Cena=@Cena,BrojSedista=@BrojSedista
                                            where IdKarta=@id";

                    id = null;
                }
                else
                {

                    cmd.CommandText = @"insert into Karta values(@Zaposleni,@Gledalac,@Projekcija,@Cena,@BrojSedista)";

                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();

            }
            catch (Exception ex) { MessageBox.Show($"Greska:{ex.Message}","Greska",MessageBoxButton.OK,MessageBoxImage.Error); }
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

        private void Odabir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RezervacijaMesta frmRezervacija = new RezervacijaMesta();

                konekcija.Open();
                int id =(int)cbProjekcija.SelectedValue;
                SqlCommand cmd = new SqlCommand { Connection = konekcija };
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.CommandText = kapacitet + "@id";
                SqlDataReader dr = cmd.ExecuteReader();
                int kap=0;
                if (dr.Read())
                {
                    kap = dr.GetInt32(0);


                }
                dr.Close();
                cmd.Dispose();
                int brojElemenata=0;
               
                SqlCommand cmd1 = new SqlCommand { Connection = konekcija };
                cmd1.Parameters.Add("@id", SqlDbType.Int).Value = cbProjekcija.SelectedValue;
                cmd1.CommandText = kartaSelect+"@id";
                SqlDataReader dr1 = cmd1.ExecuteReader();
                if (dr1.Read())
                {
                    brojElemenata = dr1.GetInt32(0);


                }
                
                dr1.Close();
                cmd1.Dispose();
                SqlCommand cmd3 = new SqlCommand { Connection = konekcija };
                cmd3.Parameters.Add("@id", SqlDbType.Int).Value = cbProjekcija.SelectedValue;
                cmd3.CommandText = brojSaleSelect + "@id";
                SqlDataReader dr3 = cmd3.ExecuteReader();
                int brojSale=0;
                if (dr3.Read())
                {
                    brojSale = dr3.GetInt32(0);
                }
                dr3.Close();
                cmd3.Dispose();
                SqlCommand cmd2 = new SqlCommand { Connection = konekcija };
                cmd2.Parameters.Add("@id", SqlDbType.Int).Value = cbProjekcija.SelectedValue;
                cmd2.CommandText = brojSedistaSelect+"@id";
                SqlDataReader dr2 = cmd2.ExecuteReader();
                int[] niz=new int[brojElemenata];
                int k = 0;
                while (dr2.Read())
                {
                    niz[k]=dr2.GetInt32(0);
                    
                    k++;
                
                }
                dr2.Close();
                cmd2.Dispose();
                GroupBox groupBox = new GroupBox();
                groupBox.Background = Brushes.LightYellow;
                int brojRedova = (kap / 15)+1;
                groupBox.Height = brojRedova*37;
                groupBox.Width =400;
                double centerX = (Width/ 2)-200;
                
                groupBox.Margin = new Thickness(centerX, 50, 0, 0);
               
                // Kreiraj StackPanel unutar GroupBox-a
                
                WrapPanel wrapPanel = new WrapPanel();
                // Dodaj dugmad u StackPanel koristeći for petlju
              
                for (int i = 1; i <=kap; i++)
                {
                    Button button = new Button();
                    button.Height = 20;
                    button.Background = Brushes.Green;
                    for (int j = 0; j < brojElemenata; j++)
                    {
                        if (i == niz[j])
                        {
                            button.Background = Brushes.Red;
                        }
                    
                    }
                   
                    button.Margin = new Thickness(5, 15, 0, 0);
                    button.Width = 20;
                    
                    button.Content = i;
                    button.FontSize = 8;
                    button.FontWeight = FontWeights.Bold;
                    button.Click += Klikni;
                    wrapPanel.Children.Add(button);

                 
                }

                // Postavi StackPanel kao sadržaj GroupBox-a
                groupBox.Content = wrapPanel;

                // Dodaj GroupBox u glavni grid (ili drugi kontejner)
                frmRezervacija.rezervacija.Children.Add(groupBox);
                frmRezervacija.lblSala.Content ="Sala "+ brojSale.ToString();
                frmRezervacija.ShowDialog();



            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
            finally { 
            if(konekcija!=null)
                    konekcija.Close();
            
            }
        
        }
        private int[] zauzetaSedista()
        {
            int brojElemenata = 0;

            SqlCommand cmd1 = new SqlCommand { Connection = konekcija };
            cmd1.Parameters.Add("@id", SqlDbType.Int).Value = cbProjekcija.SelectedValue;
            cmd1.CommandText = kartaSelect + "@id";
            SqlDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                brojElemenata = dr1.GetInt32(0);


            }

            dr1.Close();
            cmd1.Dispose();
            SqlCommand cmd2 = new SqlCommand { Connection = konekcija };
            cmd2.Parameters.Add("@id", SqlDbType.Int).Value = cbProjekcija.SelectedValue;
            cmd2.CommandText = brojSedistaSelect + "@id";
            SqlDataReader dr2 = cmd2.ExecuteReader();
            int[] niz = new int[brojElemenata];
            int k = 0;
            while (dr2.Read())
            {
                niz[k] = dr2.GetInt32(0);

                k++;

            }
            dr2.Close();
            cmd2.Dispose();
            return niz;

        }
        private void Klikni(object sender, RoutedEventArgs e) {
            if (sender is Button button)
            {
                
                if (((SolidColorBrush)button.Background).Color == Colors.Red)
                {
                    MessageBox.Show("Mesto je vec zauzeto odaberite neko drugo mesto!","Greska",MessageBoxButton.OK,MessageBoxImage.Warning);
                }
                else
                { 
                MessageBoxResult result = MessageBox.Show("Mesto rezervisano!","Obavestenje",MessageBoxButton.OKCancel,MessageBoxImage.Information);
                if (result == MessageBoxResult.OK)
                {

                    button.Background=Brushes.Red;
                    int brSedista = (int)button.Content; 
                    txtBrojSedista.Text = brSedista.ToString();
                    Window.GetWindow(button).Close();
                }
                }
            }
        }
     
    }
}
