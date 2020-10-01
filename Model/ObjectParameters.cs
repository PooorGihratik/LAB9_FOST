using System;

namespace LAB9_FOST.Model
{
    class ObjectParameters
    {
        private decimal angle = 0;

        public decimal Speed { get; set; } = 0;
        public decimal Angle 
        { 
            get => angle; 
            set
            {
                angle = value * (decimal)Math.PI / 180;
            }
        }
        public decimal Resistance { get; set; } = 0;
        public decimal Mass { get; set; } = 1;
        public decimal DeltaT { get; set; } = 0.01m;
        public decimal X0Speed
        {
            get
            {
                return Speed * (decimal)Math.Cos((double)Angle);
            }
        }
        public decimal Y0Speed
        {
            get
            {
                return Speed * (decimal)Math.Sin((double)Angle);
            }
        }
        public decimal Ratio
        {
            get
            {
                if (Mass != 0) return Resistance / Mass;
                else return -1;
            }
        }
        public decimal G { get; } = 9.81m;
    }
}
