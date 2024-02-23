﻿using System;
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
    /// Interaction logic for Grickalice.xaml
    /// </summary>
    public partial class Grickalice : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private int? id;
        public Grickalice()
        {
            InitializeComponent();
            txtNaziv.Focus();
            konekcija = kon.KreirajKonekciju();
        }
        public Grickalice(bool azuriraj, int? id)
        {
            InitializeComponent();
            txtNaziv.Focus();
            konekcija = kon.KreirajKonekciju();
            this.azuriraj = azuriraj;
            this.id = id;
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
                cmd.Parameters.Add("@Naziv", SqlDbType.NVarChar).Value = txtNaziv.Text;
                cmd.Parameters.Add("@Cena", SqlDbType.Float).Value = txtCena.Text;
            
                if (azuriraj)
                {

                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmd.CommandText = @"update Grickalice_i_pice
                                        set Naziv=@Naziv,Cena=@Cena
                                            where IdGrickalice=@id";

                    id = null;
                }
                else
                {

                    cmd.CommandText = @"insert into Grickalice_i_pice values(@Naziv,@Cena)";

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
