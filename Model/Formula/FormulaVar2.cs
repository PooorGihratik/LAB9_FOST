using System;
using System.Collections.Generic;
using System.Linq;

namespace LAB9_FOST.Model.Formula
{
    class FormulaVar2 : IFormula
    {
        public decimal Time { get; private set; }
        public List<(decimal, decimal)> GetPoints(ObjectParameters param)
        {
            List<(decimal, decimal)> points = new List<(decimal, decimal)>();
            points.Add((0m, 0m));
            decimal time = 0;
            bool resitanceCond = param.Resistance != 0; // проверка на наличие сопротивления
            do
            {
                decimal exp = (decimal)Math.Exp((double)(-param.Ratio * time));
                decimal quotent = resitanceCond ? param.G / param.Ratio * (1 - exp) : time;
                decimal xSpeed = param.X0Speed * exp;
                decimal ySpeed = param.Y0Speed * exp - quotent * param.G;
                points.Add((points.Last().Item1 + xSpeed * param.DeltaT, points.Last().Item2 + ySpeed * param.DeltaT));
                time += param.DeltaT;
            } 
            while (points.Last().Item2 > 0);
            if (points.Last().Item1 != 0) Time = time;
            else Time = 0;
            return points;
        }
    }
}
