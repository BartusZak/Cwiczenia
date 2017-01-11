using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cukiernia
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Przepis przepis = new Przepis();
        Skladnik skladnik=new Skladnik();      
        public MainWindow()
        {
            InitializeComponent();
        }
     
        private void NowyPrzepis(object sender, RoutedEventArgs e)
        {
            MainWindow Okno = new MainWindow();
            Okno.Show();
            this.Close();
        }

        private void NowySkladnik(object sender, RoutedEventArgs e)
        {
            pobierzNazwe.Visibility = Visibility.Hidden;
            pobierzCzas.Visibility = Visibility.Hidden;
            PrzyciskDodajPrzepis.Visibility = Visibility.Hidden;
            Etykieta1.Visibility = Visibility.Hidden;
            Etykieta2.Visibility = Visibility.Hidden;
            etykieta3.Visibility = Visibility.Visible;
            etykieta4.Visibility = Visibility.Visible;
            etykieta5.Visibility = Visibility.Visible;
            pobierzNazwe2.Visibility = Visibility.Visible;
            pobierzIlosc.Visibility = Visibility.Visible;
            pobierzcene.Visibility = Visibility.Visible;
            Dodaj.Visibility = Visibility.Visible;
        }

        private void NowaDostawa(object sender, RoutedEventArgs e)
        {
            Panel1.Visibility = Visibility.Hidden;
            Panel3.Visibility = Visibility.Visible;
        }

        private void Wyjscie(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void DodajNowyPrzepis(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(pobierzNazwe.Text)|| string.IsNullOrEmpty(pobierzCzas.Text))
            {
                MessageBox.Show("Prosze uzupełnic wszystkie pola");
            }
            else
            {
                try
                {
                    
                    przepis.UstawNazweICzas(pobierzNazwe.Text, Convert.ToInt32(pobierzCzas.Text));
                    if(przepis.CzyCzas()==false)
                    {
                        MessageBox.Show("Czas powinien byc od 0 do 300");
                    }
                    else
                    {
                        PrzyciskSkladnikow.Visibility = Visibility.Visible;
                        przyciskWyjscia.Visibility = Visibility.Visible;
                        PrzyciskNowegoPrzepisu.Visibility = Visibility.Visible;
                        Wyswietlacz.Visibility = Visibility.Visible;
                        Wyswietlacz.Text = "Nazwa przepisu: " + pobierzNazwe.Text + "\nCzas:" + pobierzCzas.Text + przepis.ToString() ;
                    }
                }
                catch(Exception k)
                {
                    MessageBox.Show(k.Message);
                }
            }
          
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(pobierzNazwe2.Text) || string.IsNullOrEmpty(pobierzcene.Text) || string.IsNullOrEmpty(pobierzIlosc.Text))
            {
                MessageBox.Show("Prosze wypelnic wszystkie pola");
            }
            else
            {
                try
                {
                    if (przepis.IleSkladnikow() > 3)
                    {
                        przyciskDostawy.Visibility = Visibility.Visible;
                    }
                    przepis.DodajSkladnik(pobierzNazwe.Text, pobierzIlosc.Text, Convert.ToDouble(pobierzcene.Text));

                    Wyswietlacz.Text = Wyswietlacz.Text + przepis.ToString();
                    

                }
                catch(Exception k)
                {
                    MessageBox.Show(k.Message);
                }
            }
        }

        private void Potwierdz(object sender, RoutedEventArgs e)
        {
              if (rodzajDostawy.SelectedIndex == 0)
              {
                        Zamowienie Nowe = new NaMiejscu();
                        MessageBox.Show("Klient je na miejscu");
              }
              else
              {
                     if(string.IsNullOrEmpty(Czasdostawy.Text))
                     {
                     MessageBox.Show("Wybierz czas dostawy");
                     }
            else
            {
                try
                {
                        Zamowienie Nowe = new NaWynos();
                        string Czas = Czasdostawy.Text;
                        DateTime czas = Convert.ToDateTime(Czas);
                        Nowe.UstawCzasDostawy(czas);
                        if (Nowe.PoprawnyCzas() == true)
                        {
                            MessageBox.Show(Czasdostawy.ToString());
                            

                        }
                        else
                        {
                            MessageBox.Show("Zly czas");
                        }
                    
                }
                catch(Exception k)
                {
                    MessageBox.Show(k.Message);
                }
              
            }
              }
         
            
        }


       
      }

           

        
   
}
