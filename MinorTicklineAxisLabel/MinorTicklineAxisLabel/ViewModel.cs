
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
        public ObservableCollection<Model> WheatCultivationData { get; set; }
        public ObservableCollection<Model> RiceCultivationData { get; set; }
        public ObservableCollection<Model> MaizeCultivationData { get; set; }

        public ViewModel()
        {
            CustomBrushes = new List<Brush>()
             {
                new SolidColorBrush(Color.FromArgb("#FF5F5D")),
                 new SolidColorBrush(Color.FromArgb("#FFB400")),
                 new SolidColorBrush(Color.FromArgb("#4CAFDF")),
             };

            WheatCultivationData = new ObservableCollection<Model>
            {
                 new Model(2002, 40),
                 new Model(2004, 17),
                 new Model(2006, 10),
                 new Model(2008, 14),
                 new Model(2010, 18),
                 new Model(2012, 22),
                 new Model(2014, 25),
                 new Model(2016, 24),
                 new Model(2018, 19),
                 new Model(2020, 14)
            };


            RiceCultivationData = new ObservableCollection<Model>
            {
                 new Model(2002, 80),
                 new Model(2004, 75),
                 new Model(2006, 70),
                 new Model(2008, 65),
                 new Model(2010, 60),
                 new Model(2012, 65),
                 new Model(2014, 70),
                 new Model(2016, 65),
                 new Model(2018, 60),
                 new Model(2020, 55)
            };

            MaizeCultivationData = new ObservableCollection<Model>
            {
                 new Model(2002, 100),
                 new Model(2004, 80),
                 new Model(2006, 70),
                 new Model(2008, 50),
                 new Model(2010, 30),
                 new Model(2012, 20),
                 new Model(2014, 10),
                 new Model(2016, 15),
                 new Model(2018, 40),
                 new Model(2020, 60)
            };

        }
    }
}
