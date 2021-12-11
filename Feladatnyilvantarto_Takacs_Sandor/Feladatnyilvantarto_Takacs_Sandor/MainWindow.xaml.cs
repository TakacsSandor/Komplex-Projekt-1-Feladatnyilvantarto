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
                szuksegesFeladatokListaja.Items.Refresh();
            }
        }

        }
    }
