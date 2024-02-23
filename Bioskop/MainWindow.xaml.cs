using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bioskop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool azuriraj=false;
        private string ucitanaTabela;
        Konekcija kon = new Konekcija();
        SqlConnection konekcija=new SqlConnection();

        #region Select upiti

        private static string zaposleniSelect = @"select IdZaposleni as ID,Ime,Prezime,JMBG from Zaposleni";
        private static string salaSelect = @"select IdSale as ID,Kapacitet as 'Kapacitet sale' from Sala ";
        private static string filmSelect = @"select IdFilm as ID,Naslov as 'Naslov filma',Zanr,Trajanje as 'Trajanje filma (minuti)' from Film";
        private static string grickaliceSelect = @"select IdGrickalice as ID,Naziv,Cena from Grickalice_i_pice";
        private static string gledaociSelect = @"SELECT Gledalac.IdGledaoca AS 'ID Gledaoca', 
       Grickalice_i_pice.Naziv AS 'Naziv grickalice', 
       Gledalac.Ime, 
       Gledalac.Prezime 
         FROM Gledalac
          LEFT JOIN Grickalice_i_pice ON Gledalac.IdGrickalice = Grickalice_i_pice.IdGrickalice;";
        private static string prikazivanjeSelect = @"select IdPrikazivanje as ID,tipPrikazivanja as 'Tip prikazivanja',Vreme as 'Vreme prikazivanja' 
                     from Prikazivanje";
        private static string projekcijeSelect = @"select IdProjekcije as ID,Naslov as 'Naslov filma',Sala.IdSale as 'ID Sale',
            tipPrikazivanja as 'Tip prikazivanja',Vreme as 'Vreme prikazivanja' from Projekcije join Film on Projekcije.IdFilm=Film.IdFilm
                                                                                                                                                                                                                join Sala on Projekcije.IdSale=Sala.IdSale
                                                                                                                                                                                                                  join Prikazivanje on Projekcije.IdPrikazivanja=Prikazivanje.IdPrikazivanje";
        private static string kartaSelect = @"select IdKarta as ID,Zaposleni.Ime+' '+Zaposleni.Prezime as 'Zaposleni',
            Gledalac.Ime+' '+Gledalac.Prezime as 'Gledalac',Projekcije.IdProjekcije as 'ID Projekcije',
            Cena as 'Cena karte',BrojSedista as 'Broj sedista' from Karta join Zaposleni on Karta.IdZaposlenog=Zaposleni.IdZaposleni
                                                                                                                                                                                                                               join Gledalac on Karta.IdGledaoca=Gledalac.IdGledaoca
                                                                                                                                                                                                                                 join Projekcije on Karta.IdProjekcije=Projekcije.IdProjekcije";
        #endregion


        #region Select sa uslovom

            private static string selectUslovZaposleni = @"select * from Zaposleni where IdZaposleni=";
            private static string selectUslovGrickalice = @"select * from Grickalice_i_pice where idGrickalice=";
            private static string selectUslovSala = @"select * from Sala where IdSale=";
            private static string selectUslovFilm = @"select * from Film where idFilm=";
            private static string selectUslovPrikazivanje = @"select * from Prikazivanje where IdPrikazivanje=";
            private static string selectUslovGledalac = @"select * from Gledalac where idGledaoca=";
            private static string selectUslovProjekcije = @"select * from Projekcije where IdProjekcije=";
            private static string selectUslovKarta = @"select * from Karta where idKarta=";

        #endregion

        #region Delete naredbe

        private static string deleteZaposleni = @"delete from Zaposleni where IdZaposleni=";
        private static string deleteGrickalice = @"delete from Grickalice_i_pice where idGrickalice=";
        private static string deleteSala = @"delete from Sala where IdSale=";
        private static string deleteFilm = @"delete from Film where idFilm=";
        private static string deletePrikazivanje = @"delete from Prikazivanje where IdPrikazivanje=";
        private static string deleteGledalac = @"delete from Gledalac where idGledaoca=";
        private static string deleteProjekcije = @"delete from Projekcije where IdProjekcije=";
        private static string deleteKarta = @"delete from Karta where idKarta=";

        #endregion
        





        public MainWindow()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            UcitajPodatke(zaposleniSelect);
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Window prozor;

            if (ucitanaTabela.Equals(zaposleniSelect))
            {
                prozor = new Zaposleni();
                prozor.ShowDialog();
                UcitajPodatke(zaposleniSelect);

            }
            else if (ucitanaTabela.Equals(salaSelect))
            {
                prozor = new Sala();
                prozor.ShowDialog();
                UcitajPodatke(salaSelect);

            }
            else if (ucitanaTabela.Equals(filmSelect))
            {
                prozor = new Film();
                prozor.ShowDialog();
                UcitajPodatke(filmSelect);

            }
            else if (ucitanaTabela.Equals(grickaliceSelect))
            {
                prozor = new Grickalice();
                prozor.ShowDialog();
                UcitajPodatke(grickaliceSelect);

            }
            else if (ucitanaTabela.Equals(gledaociSelect))
            {
                prozor = new Gledalac();
                prozor.ShowDialog();
                UcitajPodatke(gledaociSelect);

            }
            else if (ucitanaTabela.Equals(prikazivanjeSelect))
            {
                prozor = new Prikazivanje();
                prozor.ShowDialog();
                UcitajPodatke(prikazivanjeSelect);

            }
            else if (ucitanaTabela.Equals(projekcijeSelect))
            {
                prozor = new Projekcija();
                prozor.ShowDialog();
                UcitajPodatke(projekcijeSelect);

            }
            else if (ucitanaTabela.Equals(kartaSelect))
            {
                prozor = new Karta();
                prozor.ShowDialog();
                UcitajPodatke(kartaSelect);

            }

        }
        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            
            if (dataGridCentralni.SelectedItems.Count == 0)
            {
                MessageBox.Show("Morate selektovati red koji zelite da izmenite", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (dataGridCentralni.SelectedItems.Count > 1)
            {
                MessageBox.Show("Selektujte samo 1 red", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (ucitanaTabela.Equals(zaposleniSelect))
                {
                    PopuniFormu(selectUslovZaposleni);
                    UcitajPodatke(zaposleniSelect);

                }
                else if (ucitanaTabela.Equals(salaSelect))
                {
                    PopuniFormu(selectUslovSala);
                    UcitajPodatke(salaSelect);

                }
                else if (ucitanaTabela.Equals(filmSelect))
                {
                   PopuniFormu(selectUslovFilm);
                    UcitajPodatke(filmSelect);

                }
                else if (ucitanaTabela.Equals(grickaliceSelect))
                {
                    PopuniFormu(selectUslovGrickalice);
                    UcitajPodatke(grickaliceSelect);

                }
                else if (ucitanaTabela.Equals(gledaociSelect))
                {
                    PopuniFormu(selectUslovGledalac);
                    UcitajPodatke(gledaociSelect);

                }
                else if (ucitanaTabela.Equals(prikazivanjeSelect))
                {
                 
                    PopuniFormu(selectUslovPrikazivanje);
                    UcitajPodatke(prikazivanjeSelect);

                }
                else if (ucitanaTabela.Equals(projekcijeSelect))
                {
                    PopuniFormu(selectUslovProjekcije);
                    UcitajPodatke(projekcijeSelect);

                }
                else if (ucitanaTabela.Equals(kartaSelect))
                {
                    PopuniFormu(selectUslovKarta);
                    UcitajPodatke(kartaSelect);

                }







            }

        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridCentralni.SelectedItems.Count == 0)
            {
                MessageBox.Show("Morate selektovati red koji zelite da izmenite", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (dataGridCentralni.SelectedItems.Count > 1)
            {
                MessageBox.Show("Selektujte samo 1 red", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Da li ste sigurni da zelite da obrisete selektovani element?", "Upit", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    if (ucitanaTabela.Equals(zaposleniSelect))
                    {


                        Brisanje(deleteZaposleni);
                        UcitajPodatke(zaposleniSelect);


                    }
                    else if (ucitanaTabela.Equals(salaSelect))
                    {
                        Brisanje(deleteSala);
                        UcitajPodatke(salaSelect);

                    }
                    else if (ucitanaTabela.Equals(filmSelect))
                    {
                        Brisanje(deleteFilm);
                        UcitajPodatke(filmSelect);

                    }
                    else if (ucitanaTabela.Equals(grickaliceSelect))
                    {
                        Brisanje(deleteGrickalice);
                        UcitajPodatke(grickaliceSelect);

                    }
                    else if (ucitanaTabela.Equals(gledaociSelect))
                    {
                        Brisanje(deleteGledalac);
                        UcitajPodatke(gledaociSelect);

                    }
                    else if (ucitanaTabela.Equals(prikazivanjeSelect))
                    {

                        Brisanje(deletePrikazivanje);
                        UcitajPodatke(prikazivanjeSelect);

                    }
                    else if (ucitanaTabela.Equals(projekcijeSelect))
                    {
                        Brisanje(deleteProjekcije);
                        UcitajPodatke(projekcijeSelect);

                    }
                    else if (ucitanaTabela.Equals(kartaSelect))
                    {
                        Brisanje(deleteKarta);
                        UcitajPodatke(kartaSelect);

                    }
                }
                else
                    return;

            }



            }
         private void UcitajPodatke(string selectUpit)
       {
            try
            {

            konekcija.Open();
            SqlDataAdapter da=new SqlDataAdapter(selectUpit,konekcija);
            DataTable dt=new DataTable();
            da.Fill(dt);
            if (dataGridCentralni != null)
            {

                dataGridCentralni.ItemsSource = dt.DefaultView;

            }
            ucitanaTabela = selectUpit;
            da.Dispose();
            dt.Dispose();

            }
            catch (SqlException)
            {

                MessageBox.Show("Greska prilikom ucitavanja podataka!","Greska",MessageBoxButton.OK,MessageBoxImage.Error);

            }
            finally 
            {

                if (konekcija != null)
                { konekcija.Close(); }

            }



        }

        private void PopuniFormu(string selectUslov)
        {
           
            try
            {
                konekcija.Open();
                azuriraj = true;
                var selectedRow = (DataRowView)dataGridCentralni.SelectedItem;
                object a = selectedRow.Row.ItemArray[0];
                int? id = (int?)a;
                SqlCommand cmd = new SqlCommand { Connection = konekcija };
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.CommandText = selectUslov + "@id";
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    if (ucitanaTabela.Equals(zaposleniSelect))
                    {
                       Zaposleni frmZaposleni=new Zaposleni(azuriraj,id);
                        frmZaposleni.txtIme.Text = dr["Ime"].ToString();
                        frmZaposleni.txtPrezime.Text = dr["Prezime"].ToString();
                        frmZaposleni.txtJmbg.Text = dr["JMBG"].ToString();
                        frmZaposleni.ShowDialog();


                    }
                    else if (ucitanaTabela.Equals(salaSelect))
                    {
                        Sala frmSala = new Sala(azuriraj,id);
                        frmSala.txtKapacitet.Text = dr["Kapacitet"].ToString();
                        frmSala.ShowDialog();


                    }
                    else if (ucitanaTabela.Equals(filmSelect))
                    {
                        Film frmFilm = new Film(azuriraj, id);
                        frmFilm.txtNaziv.Text = dr["Naslov"].ToString();
                        frmFilm.txtTrajanje.Text = dr["Trajanje"].ToString();
                        frmFilm.txtZanr.Text = dr["Zanr"].ToString();
                        frmFilm.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(grickaliceSelect))
                    {
                        Grickalice frmGrickalice = new Grickalice(azuriraj,id);
                        frmGrickalice.txtNaziv.Text = dr["Naziv"].ToString();
                        frmGrickalice.txtCena.Text = dr["Cena"].ToString();
                        frmGrickalice.ShowDialog(); 

                    }
                    else if (ucitanaTabela.Equals(gledaociSelect))
                    {
                        Gledalac frmGledalac = new Gledalac(azuriraj,id);
                        frmGledalac.txtIme.Text = dr["Ime"].ToString();
                        frmGledalac.txtPrezime.Text = dr["Prezime"].ToString();

                        
                         frmGledalac.cbGrickalice.SelectedValue = dr["IdGrickalice"].ToString(); 
                      
                        
                      
                        frmGledalac.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(prikazivanjeSelect))
                    {
                        Prikazivanje frmPrikazivanje = new Prikazivanje(azuriraj,id);
                       
                        frmPrikazivanje.txtTipPrikazivanja.Text = dr["tipPrikazivanja"].ToString();
                        frmPrikazivanje.dpVreme.SelectedDate = (DateTime)dr["Vreme"];
                        frmPrikazivanje.ShowDialog();

                    }
                    else if (ucitanaTabela.Equals(projekcijeSelect))
                    {
                        Projekcija frmProjekcija = new Projekcija(azuriraj,id);
                        frmProjekcija.cbFilm.SelectedValue = dr["IdFilm"];
                        
                        frmProjekcija.cbSale.SelectedValue = dr["IdSale"];
                        frmProjekcija.cbPrikazivanje.SelectedValue = dr["IdPrikazivanja"];
                        frmProjekcija.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(kartaSelect))
                    {
                        Karta frmKarta = new Karta(azuriraj, id);
                        frmKarta.cbZaposleni.SelectedValue = dr["IdZaposlenog"];
                        frmKarta.cbGledalac.SelectedValue = dr["IdGledaoca"];
                        frmKarta.cbProjekcija.SelectedValue = dr["IdProjekcije"];
                        frmKarta.txtCena.Text = dr["Cena"].ToString();
                        frmKarta.txtBrojSedista.Text = dr["BrojSedista"].ToString();

                        frmKarta.ShowDialog();

                    }
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception) { MessageBox.Show("Greska prilikom popunjavanja forme","Greska",MessageBoxButton.OK,MessageBoxImage.Error); }
            finally { if (konekcija != null)
                    konekcija.Close();
            }
        }

        private void Brisanje(string upit)
        {
            try {
                konekcija.Open();
                var selectedRow = (DataRowView)dataGridCentralni.SelectedItem;
                object a = selectedRow.Row.ItemArray[0];
                int? id = (int?)a;
                SqlCommand cmd = new SqlCommand { Connection = konekcija };
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.CommandText = upit + "@id";
                cmd.ExecuteNonQuery();
                cmd.Dispose ();

            }
            catch (SqlException) { MessageBox.Show("Ne mozete obrisati element koji se koristi u drugoj tabeli kao strani kljuc!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error); }
            finally { 
            if(konekcija!=null)
                    konekcija.Close ();
            }
        
        
        
        }

        public  int brojElemenataDataGrid()
        {
            return dataGridCentralni.Items.Count;
        
        }
        

private void btnKarta_Click(object sender, RoutedEventArgs e)
{
UcitajPodatke(kartaSelect);
}

private void btnZaposleni_Click(object sender, RoutedEventArgs e)
{
UcitajPodatke(zaposleniSelect);
}

private void btnGrickalice_Click(object sender, RoutedEventArgs e)
{
UcitajPodatke(grickaliceSelect);
}

private void btnGledalac_Click(object sender, RoutedEventArgs e)
{
UcitajPodatke(gledaociSelect);
}

private void btnSala_Click(object sender, RoutedEventArgs e)
{
UcitajPodatke(salaSelect);
}

private void btnFilm_Click(object sender, RoutedEventArgs e)
{
UcitajPodatke(filmSelect);
}

private void btnProjekcija_Click(object sender, RoutedEventArgs e)
{
UcitajPodatke(projekcijeSelect);
}

private void btnPrikazivanje_Click(object sender, RoutedEventArgs e)
{
UcitajPodatke(prikazivanjeSelect);
}
    }
}