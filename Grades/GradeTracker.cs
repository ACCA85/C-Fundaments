using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Grades
{
    //se puede twnwe tantas interfacees como se quiera
    public abstract class GradeTracker : IGradeTracker
    {
        public abstract void AddGrade(float grade);
        public abstract GradeStatistics ComputeStatistics();
        public abstract void WriteGrades(System.IO.TextWriter destination);

        public abstract IEnumerator GetEnumerator();

        public event NameChangedDelegated NameChanged;

        protected string _name;

        public  string Name
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
    }
}
