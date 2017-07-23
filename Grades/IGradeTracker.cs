using System;
using System.Collections;

namespace Grades
{
    internal interface IGradeTracker : IEnumerable
    {
        void AddGrade(float grade);
        GradeStatistics ComputeStatistics();
        void WriteGrades(System.IO.TextWriter destination);
        string Name { get; set; }
 
    }
}