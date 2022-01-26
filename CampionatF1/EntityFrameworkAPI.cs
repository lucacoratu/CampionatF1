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
    static class EntityFrameworkAPI
    {
        static Campionat_F1Entities context = new Campionat_F1Entities();

        static List<int> points_per_place = new List<int>() {25, 18, 15, 12, 10, 8, 6 ,4, 2, 1};
        static public List<string> GetDriverNames()
        {
            List<string> drivers = (from d in context.Pilots
                                    orderby d.Score descending
                                    select d.Name
                                    ).ToList();

            return drivers;
        }

        static public List<int> GetDriverPoints()
        {
            List<int> points = (from d in context.Pilots
                                orderby d.Score descending
                                select d.Score).ToList();

            return points;
        }

        static public List<string> GetConstructorNames()
        {
            List<string> constructors = (from c in context.Constructors
                                         orderby c.Score descending
                                        select c.Name).ToList();

            return constructors;
        }

        static public List<int> GetConstructorsPoints()
        {
            List<int> points = (from c in context.Constructors
                                orderby c.Score descending
                                select c.Score).ToList();

            return points;
        }

        static public string GetDriverConstructor(string driver)
        {
            string constructor = (from d in context.Pilots
                                  where d.Name == driver
                                  select d.Constructor.Name).FirstOrDefault();

            return constructor;
        }

        static public bool AddRaceResult(List<ComboBox> comboboxes, List<CheckBox> checkboxes)
        {
            for(int i =0; i < 10; i++)
            {
                string driver_name = comboboxes[i].SelectedItem as string;
                Pilot pilot = (from d in context.Pilots
                               where d.Name == driver_name
                               select d).FirstOrDefault();

                pilot.Score += points_per_place[i];

                if(checkboxes[i].IsChecked == true)
                {
                    pilot.Score += 1;
                }

                Constructor constructor = (from c in context.Constructors
                                           where c.ConstructorID == pilot.ConstructorID
                                           select c).FirstOrDefault();

                constructor.Score += pilot.Score;
            }

            context.SaveChanges();

            return true;
        }
    }
}
