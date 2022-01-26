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
    /// Interaction logic for ConstructorPoints.xaml
    /// </summary>
    public partial class ConstructorPoints : UserControl
    {
        public ConstructorPoints()
        {
            InitializeComponent();

            var constructors = EntityFrameworkAPI.GetConstructorNames();
            var points = EntityFrameworkAPI.GetConstructorsPoints();

            for(int i =0; i< constructors.Count; i++)
            {
                Label constructor = new Label();
                constructor.Content = constructors[i];
                constructor.Foreground = new SolidColorBrush(Colors.WhiteSmoke);
                constructor.HorizontalContentAlignment = HorizontalAlignment.Center;

                this.stckpanel_constructors.Children.Add(constructor);


                Label lbl_points = new Label();
                lbl_points.Content = points[i].ToString();
                lbl_points.Foreground = new SolidColorBrush(Colors.WhiteSmoke);
                lbl_points.HorizontalContentAlignment = HorizontalAlignment.Center;

                this.stckpanel_points.Children.Add(lbl_points);
            }
        }
    }
}
