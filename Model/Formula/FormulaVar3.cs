using System;
using System.Collections.Generic;
using System.Linq;

namespace LAB9_FOST.Model.Formula
{
    class FormulaVar3 : IFormula
    {
        public decimal Time { get; private set; }
        public List<(decimal, decimal)> GetPoints(ObjectParameters param)
        {
            List<(decimal, decimal)> points = new List<(decimal, decimal)>();
            points.Add((0m, 0m));
            decimal xSpeed = param.X0Speed;
            decimal ySpeed = param.Y0Speed;
            decimal time = 0;
            do
            {
                points.Add((points.Last().Item1 + xSpeed*param.DeltaT, points.Last().Item2 + ySpeed * param.DeltaT));
                decimal modSpeed = (decimal)Math.Sqrt((double)(xSpeed*xSpeed + ySpeed*ySpeed));
                xSpeed -= param.Ratio * param.DeltaT * modSpeed * xSpeed;
                ySpeed -= param.G*param.DeltaT + param.Ratio * param.DeltaT * modSpeed * ySpeed;
                time += param.DeltaT;
            } 
            while (points.Last().Item2 > 0);
            if (points.Last().Item1 != 0) Time = time;
            else Time = 0;
            return points;
        }
    }
}
