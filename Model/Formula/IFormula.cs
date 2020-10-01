using System.Collections.Generic;

namespace LAB9_FOST.Model.Formula
{
    interface IFormula
    {
        decimal Time { get; }
        List<(decimal, decimal)> GetPoints(ObjectParameters parameters);
    }
}
