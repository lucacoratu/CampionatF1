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
    /// Interaction logic for DriverPoints.xaml
    /// </summary>
    public partial class DriverPoints : UserControl
    {
        public DriverPoints()
        {
            InitializeComponent();

            var driver_names = EntityFrameworkAPI.GetDriverNames();
            var points = EntityFrameworkAPI.GetDriverPoints();

            for(int i = 0; i<  driver_names.Count; i++)
            {
                Label lbl_driver = new Label();
                lbl_driver.Content = driver_names[i];
                lbl_driver.Foreground = new SolidColorBrush(Colors.WhiteSmoke);
                lbl_driver.HorizontalContentAlignment = HorizontalAlignment.Center; 
                this.stckpanel_Names.Children.Add(lbl_driver);

                string constructor = EntityFrameworkAPI.GetDriverConstructor(driver_names[i]);
                Label lbl_constr = new Label();
                lbl_constr.Content = constructor;
                lbl_constr.Foreground = new SolidColorBrush(Colors.WhiteSmoke);
                lbl_constr.HorizontalContentAlignment = HorizontalAlignment.Center;
                this.stckpanel_Constructors.Children.Add(lbl_constr);


                Label lbl_points = new Label();
                lbl_points.Content = points[i].ToString();
                lbl_points.Foreground = new SolidColorBrush(Colors.WhiteSmoke);
                lbl_points.HorizontalContentAlignment = HorizontalAlignment.Center;
                this.stckpanel_Points.Children.Add(lbl_points);
            }
        }
    }
}
