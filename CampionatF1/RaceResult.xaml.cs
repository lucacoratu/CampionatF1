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
    /// Interaction logic for RaceResult.xaml
    /// </summary>
    public partial class RaceResult : UserControl
    {
        List<CheckBox> fastestlap_checkboxes = new List<CheckBox>();
        List<ComboBox> drivers_comboboxes = new List<ComboBox>();
        public RaceResult()
        {
            InitializeComponent();

            for(int i =1; i <= 10; i++)
            {
                Label label_nr = new Label();
                label_nr.Content = i.ToString() + ".";
                label_nr.HorizontalAlignment = HorizontalAlignment.Right;
                label_nr.Foreground = new SolidColorBrush(Colors.WhiteSmoke);
                this.stckpanel_place.Children.Add(label_nr);
            }

            List<string> driverNames = EntityFrameworkAPI.GetDriverNames();

            for(int i = 0; i < 10; i++)
            {
                ComboBox box = new ComboBox();
                //box.Width = 30;
                box.Height = 26;
                box.SelectionChanged += Box_SelectionChanged;
                foreach (var driver in driverNames)
                    box.Items.Add(driver);

                this.drivers_comboboxes.Add(box);
                this.stckpanel_drivers.Children.Add(box);
            }

            for(int i =0; i< 10; i++)
            {
                CheckBox chkbox = new CheckBox();
                chkbox.IsChecked = false;
                chkbox.Checked += chkbox_checked;
                chkbox.HorizontalAlignment = HorizontalAlignment.Center;
                chkbox.Height = 27;
                this.fastestlap_checkboxes.Add(chkbox);

                this.stckpanel_fastest.Children.Add(chkbox);
            }
        }

        private void Box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(!(sender is ComboBox))
            {
                return;
            }
            var sender_combobox = sender as ComboBox;
            foreach(var combo in drivers_comboboxes)
            {
                if (sender_combobox != combo)
                {
                    if (combo.SelectedIndex == sender_combobox.SelectedIndex && combo.SelectedIndex != -1)
                    {
                        sender_combobox.SelectedIndex = -1;
                        MessageBox.Show("Driver already selected!");
                    }
                }
            }
        }

        void chkbox_checked(object sender, RoutedEventArgs e)
        {
            if(!(sender is CheckBox))
            {
                return;
            }

            var sender_chkbox = sender as CheckBox;
            foreach(var chbox in fastestlap_checkboxes)
            {
                if(chbox != sender_chkbox && chbox.IsChecked == true)
                {
                    chbox.IsChecked = false;
                    sender_chkbox.IsChecked = true;
                }
            }
        }

        private void btn_addRace_Click(object sender, RoutedEventArgs e)
        {
            EntityFrameworkAPI.AddRaceResult(this.drivers_comboboxes, this.fastestlap_checkboxes);
        }
    }
}
