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

namespace Feladatnyilvantarto_Takacs_Sandor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<CheckBox> feladatokListaja = new List<CheckBox>();
        List<CheckBox> toroltFeladatok = new List<CheckBox>();
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
    }
}

