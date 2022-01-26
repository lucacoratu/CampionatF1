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

namespace CampionatF1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_addRaceResult_Click(object sender, RoutedEventArgs e)
        {
            this.grid_view.Children.Clear();
            RaceResult rr = new RaceResult();
            this.grid_view.Children.Add(rr);
        }

        private void btn_viewPoints_Click(object sender, RoutedEventArgs e)
        {
            this.grid_view.Children.Clear();
            DriverPoints dp = new DriverPoints();
            this.grid_view.Children.Add(dp);
        }

        private void btn_viewConstructorPoints_Click(object sender, RoutedEventArgs e)
        {
            this.grid_view.Children.Clear();
            ConstructorPoints cp = new ConstructorPoints();
            this.grid_view.Children.Add(cp);
        }
    }
}
