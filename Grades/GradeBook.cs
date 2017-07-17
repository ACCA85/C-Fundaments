using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook
    {
        //you can type ctor + tab twice
        public GradeBook()
        {
            grades = new List<float>();
        }

        public void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        public string Name;
        List<float> grades;

        //Devuelve un GradeStatistics object de la clase GradeStatistics 
        public  GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();
            stats.HighestGrade = 0;

            float sum = 0;

            foreach(float grade in grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }

            stats.AverageGrade = sum / grades.Count;

            return stats;

        }

        

    }
}
