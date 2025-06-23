
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinorTicklineAxisLabel
{
    public class ViewModel
    {
        public List<Brush> CustomBrushes { get; set; }
        public ObservableCollection<Model> TemperatureData { get; set; }
        public ObservableCollection<Model> HumidityData { get; set; }
        public ObservableCollection<Model> RainfallData { get; set; }

        public ViewModel()
        {
            CustomBrushes = new List<Brush>()
             {
                new SolidColorBrush(Color.FromArgb("#FF5F5D")),
                 new SolidColorBrush(Color.FromArgb("#FFB400")),
                 new SolidColorBrush(Color.FromArgb("#4CAFDF")),
             };

            TemperatureData = new ObservableCollection<Model>
            {
                new Model(new DateTime(2023, 1, 1), 40),
                new Model(new DateTime(2023, 2, 1), 17),
                new Model(new DateTime(2023, 3, 1), 10),
                new Model(new DateTime(2023, 4, 1), 14),
                new Model(new DateTime(2023, 5, 1), 18),
                new Model(new DateTime(2023, 6, 1), 22),
                new Model(new DateTime(2023, 7, 1), 25),
                new Model(new DateTime(2023, 8, 1), 24),
                new Model(new DateTime(2023, 9, 1), 19),
                new Model(new DateTime(2023, 10, 1), 14),
                new Model(new DateTime(2023, 11, 1), 8),
                new Model(new DateTime(2023, 12, 1), 5)
            };

            HumidityData = new ObservableCollection<Model>
            {
                new Model(new DateTime(2023, 1, 1), 80),
                new Model(new DateTime(2023, 2, 1), 75),
                new Model(new DateTime(2023, 3, 1), 70),
                new Model(new DateTime(2023, 4, 1), 65),
                new Model(new DateTime(2023, 5, 1), 60),
                new Model(new DateTime(2023, 6, 1), 65),
                new Model(new DateTime(2023, 7, 1), 70),
                new Model(new DateTime(2023, 8, 1), 65),
                new Model(new DateTime(2023, 9, 1), 60),
                new Model(new DateTime(2023, 10, 1), 55),
                new Model(new DateTime(2023, 11, 1), 70),
                new Model(new DateTime(2023, 12, 1), 80)
            };

            RainfallData = new ObservableCollection<Model>
            {
                new Model(new DateTime(2023, 1, 1), 100),
                new Model(new DateTime(2023, 2, 1), 80),
                new Model(new DateTime(2023, 3, 1), 70),
                new Model(new DateTime(2023, 4, 1), 50),
                new Model(new DateTime(2023, 5, 1), 30),
                new Model(new DateTime(2023, 6, 1), 20),
                new Model(new DateTime(2023, 7, 1), 10),
                new Model(new DateTime(2023, 8, 1), 15),
                new Model(new DateTime(2023, 9, 1), 40),
                new Model(new DateTime(2023, 10, 1), 60),
                new Model(new DateTime(2023, 11, 1), 90),
                new Model(new DateTime(2023, 12, 1), 110)
            };
        }
    }
}
