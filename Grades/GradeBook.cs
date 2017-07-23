using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook : GradeTracker
    {
        //you can type ctor + tab twice
        public GradeBook()
        {
            _name = "Empty";
            grades = new List<float>();
        }

        public override void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        //por convencion fields publicos capitalized 
        //Filtros para validar un campo de un objeto con get y set
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }

                if (!string.IsNullOrEmpty(value))
                {
                    if (_name != value && NameChanged != null)
                    {
                        NameChangedEventArgs args = new NameChangedEventArgs();
                        args.ExistingName = _name;
                        args.NewName = value;

                        NameChanged(this, args);
                        ////llama a una delegated
                        //NameChanged(_name, value);
                    }
                    _name = value;
                }
            }
        }

        public override void WriteGrades(TextWriter destination)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                destination.WriteLine(grades[i]);

            }
        }

        public event NameChangedDelegated NameChanged;

        protected string _name;

        //puedes acceder con el protected, desde su clase y desde las clases derivadas,
        //al hacer uso de la herencia accedemos aquí desde ThrowAwayGradeBook
        protected List<float> grades;

        //Devuelve un GradeStatistics object de la clase GradeStatistics 

        public override GradeStatistics  ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();
            stats.HighestGrade = 0;

            float sum = 0;

            foreach (float grade in grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }

            stats.AverageGrade = sum / grades.Count;

            return stats;

        }
        public override IEnumerator GetEnumerator()
        {
            return grades.GetEnumerator();
        }



    }
}
