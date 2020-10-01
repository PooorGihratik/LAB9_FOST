using LAB9_FOST.Model.Formula;
using OxyPlot;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace LAB9_FOST.Model
{
    class MathObjectModel : INotifyPropertyChanged
    {
        private string distance;
        private string time;
        private List<DataPoint> points;
        public ObjectParameters ObjectParameters = new ObjectParameters();
        public List<DataPoint> Points 
        {
            get => points;
            private set
            {
                points = value;
                OnPropertyChanged("Points");
            } 
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public string Distance
        {
            get
            {
                return distance;
            }
            private set
            {
                distance = value;
                OnPropertyChanged("Distance");
            }
        }
        public string Time
        {
            get
            {
                return time;
            }
            private set
            {
                time = value;
                OnPropertyChanged("Time");
            }
        }
        public void FindPoints(IFormula formula)
        {
            List<(decimal, decimal)> data = formula.GetPoints(ObjectParameters);
            Points = new List<DataPoint>();
            foreach ((decimal, decimal) point in data)
            {
                Points.Add(new DataPoint((double)point.Item1, (double)point.Item2));
            }
            Distance = Points.Last().X.ToString();
            Time = formula.Time.ToString();
        }
        public void FindPoints(bool variant)
        {
            IFormula formula;
            if (variant) formula = new FormulaVar2();
            else formula = new FormulaVar3();
            List<(decimal, decimal)> data = formula.GetPoints(ObjectParameters);
            Points = new List<DataPoint>();
            foreach ((decimal, decimal) point in data)
            {
                Points.Add(new DataPoint((double)point.Item1, (double)point.Item2));
            }
            Distance = Points.Last().X.ToString();
            Time = formula.Time.ToString();
        }

    }
}
