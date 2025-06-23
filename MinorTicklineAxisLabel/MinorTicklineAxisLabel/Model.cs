using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinorTicklineAxisLabel
{
    public class Model
    {
        public DateTime Date { get; set; }
        public double Value { get; set; }

        public Model(DateTime date, double value)
        {
            Date = date;
            Value = value;
        }
    }
}
