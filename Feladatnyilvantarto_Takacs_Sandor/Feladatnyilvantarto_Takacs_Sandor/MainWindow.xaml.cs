using System;
using System.Collections.Generic;
using System.IO;
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

namespace Feladatnyilvantarto_Takacs_Sandor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<CheckBox> feladatokListaja = new List<CheckBox>();
        List<CheckBox> toroltFeladatok = new List<CheckBox>();
        List<string> checkboxok = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            szuksegesFeladatokListaja.ItemsSource = feladatokListaja;
            toroltFeladatokListaja.ItemsSource = toroltFeladatok;
        }

        private void UjELemHozzaadasa_Click(object sender, RoutedEventArgs e)
        {
            if (feladatSzovegbevitele.Text != "")
            {
                CheckBox ujCheckbox = new CheckBox();
                ujCheckbox.Content = feladatSzovegbevitele.Text;
                feladatokListaja.Add(ujCheckbox);
                ujCheckbox.Checked += new RoutedEventHandler(CheckBox_Checked);
                ujCheckbox.Unchecked += new RoutedEventHandler(CheckBox_UnChecked);
                szuksegesFeladatokListaja.Items.Refresh();
            }

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox jelenlegi = (CheckBox)sender;
            jelenlegi.FontStyle = FontStyles.Italic;
            jelenlegi.Foreground = Brushes.Gray;
        }

        private void CheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            CheckBox jelenlegi = (CheckBox)sender;
            jelenlegi.FontStyle = FontStyles.Normal;
            jelenlegi.Foreground = Brushes.Black;
        }

        private void kijeloltFeladatTorlese_Click(object sender, RoutedEventArgs e)
        {
            CheckBox kijelolt = (CheckBox)szuksegesFeladatokListaja.SelectedItem;
            toroltFeladatok.Add(kijelolt);
            feladatokListaja.Remove(kijelolt);
            toroltFeladatokListaja.Items.Refresh();
        }

        private void kijeloltFeladatVisszaallit_Click(object sender, RoutedEventArgs e)
        {
            CheckBox kijelolt = (CheckBox)toroltFeladatokListaja.SelectedItem;
            feladatokListaja.Add(kijelolt);
            toroltFeladatok.Remove(kijelolt);
            szuksegesFeladatokListaja.Items.Refresh();
        }

        private void kijeloltFeladatVeglegTorlese_Click(object sender, RoutedEventArgs e)
        {
            CheckBox kijelolt = (CheckBox)toroltFeladatokListaja.SelectedItem;
            toroltFeladatok.Remove(kijelolt);
            toroltFeladatokListaja.Items.Refresh();

        }

        private void kijeloltFeladatModositasa_Click(object sender, RoutedEventArgs e)
        {
            if (feladatSzovegbevitele.Text != "")
            {
                CheckBox kijelolt = (CheckBox)szuksegesFeladatokListaja.SelectedItem;
                kijelolt.Content = feladatSzovegbevitele.Text;
            }

        }

        private void szuksegesFeladatokListaja_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckBox kijelolt = (CheckBox)szuksegesFeladatokListaja.SelectedItem;
            feladatSzovegbevitele.Text = (string)kijelolt.Content;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            foreach (CheckBox x in szuksegesFeladatokListaja.Items)
            {
                int allapot = 0;
                if (x.IsChecked == true)
                    allapot = 1;
                string cbJellemzoje = x.Content.ToString() + ";" + allapot;
                checkboxok.Add(cbJellemzoje);
            }
            File.WriteAllLines("feladatokTaroloja", checkboxok);
            
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            foreach (CheckBox x in toroltFeladatokListaja.Items)
            { 
                int allapot = 0;
                if (x.IsChecked == true)
                    allapot = 1;
                string cbJellemzoje = x.Content.ToString() + ";" + allapot;
                checkboxok.Add(cbJellemzoje);
            }
            File.WriteAllLines("toroltFeladatokTaroloja", checkboxok);
        }
        /*
        private void Window_Activated(object sender, EventArgs e)
        {
           var be = File.ReadAllLines("feladatokTaroloja.txt");
           foreach(var x in be)
           {
               if (x != "")
               { 
                   szuksegesFeladatokListaja.ClearValue(ItemsControl.ItemsSourceProperty);
               CheckBox uj = new CheckBox();


                   uj.Content = x.Split(';')[0];
                   uj.IsChecked = x.Split(';')[1] == "1" ? true : false;
                   szuksegesFeladatokListaja.Items.Add(uj);
               }
           }
           var be2 = File.ReadAllLines("toroltFeladatokTaroloja.txt");
           foreach(var x in be2)
           {
               if(x != "")
               {
               toroltFeladatokListaja.ClearValue(ItemsControl.ItemsSourceProperty);
               CheckBox uj = new CheckBox();
               uj.Content = x.Split(';')[0];
               uj.IsChecked = x.Split(';')[1] == "1" ? true : false;
               toroltFeladatokListaja.Items.Add(uj);
               }
           }
        */
    }
    }
   


