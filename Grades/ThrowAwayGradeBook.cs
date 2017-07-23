using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    //hereda las propiedades de Gradebook, despues de los dos puntos, es como si fuese una clase 
    //más específica de Gradebook
    public class ThrowAwayGradeBook : GradeBook
    {
       public override GradeStatistics ComputeStatistics()
        {
     

            float lowest = float.MaxValue;
            foreach(float grade in grades)
            {
                lowest = Math.Min(grade, lowest);
            }
            grades.Remove(lowest);

            return base.ComputeStatistics();
        }
    }
}
