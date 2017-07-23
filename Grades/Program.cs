using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            //GradeBook book = CreateGradeBook();
            //GetBookName(book);
            //Ahora pasamos a trabajar con un abstract class
            IGradeTracker book = CreateGradeBook();

            //book.NameChanged += new NameChangedDelegated(OnNameChanged);
            ////esta llamando a On Name changed cuando se poduce un cambio de nombre mediante el field de _name       
            //book.NameChanged += new NameChangedDelegated(OnNameChanged2);
            ////Para usar varias delegated, se realiza con un incremento àra no sobreescribir la llamada
            ////no es la mejor forma de manejar eventeos

            //VS sabe que es un namechangedelegated
            //book.NameChanged += OnNameChanged;


            book.Name = "Alex's Grade Book";
            AddGrades(book);

            //si hay alguna excepcion en este blque se ira al outFile
            using (StreamWriter outFile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outFile);
                outFile.Close();
            }

            WriteResults(book);

            Console.ReadKey();

        }



        private static IGradeTracker CreateGradeBook()
        {
            //Pruebas sobre reference types y como las clases son pointers a memoria de unos datos.
            //GradeBook g1 = new GradeBook();
            //GradeBook g2 = g1;

            //g1.Name = "Alex's grade  Book";
            //Console.WriteLine(g2.Name);

            //GradeBook book = new GradeBook();

            //Creamos una nueva instancia para probar el polimorfismo, llamando a la clase ThrowAwayGradebook en lugar de a gradebook como en la linea superior
            //Debido al override vamos a la clase derivada en lugar de a la clase padre en funcion del tipo de objeto que estamos instanciando
            return new ThrowAwayGradeBook();
        }

        private static void WriteResults(IGradeTracker book)
        {
            GradeStatistics stats = book.ComputeStatistics();
            Console.WriteLine(book.Name);

            //Console.WriteLine(stats.AverageGrade);
            //Console.WriteLine(stats.HighestGrade);
            //Console.WriteLine(stats.LowestGrade);
            foreach (float grade in book)
            {
                Console.WriteLine(grade);
            }

            WriteResult("Average", stats.AverageGrade);
            //Conversion explicita o cast el (int)
            WriteResult("Highest", (int)stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult(stats.Description, stats.LetterGrade);
        }

        private static void AddGrades(IGradeTracker book)
        {
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
        }

        private static void GetBookName(IGradeTracker book)
        {
            try
            {
                Console.WriteLine("Enter a name");
                book.Name = Console.ReadLine();
            }


            //Solo recoge las excepciones de tipo Argument
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Something went wrong!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong!");
            }
        }

        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Grade Book changing name from {args.ExistingName} to {args.NewName}");
        }
        //Usado con delegated
        //static void OnNameChanged2(string existinName, string newName)
        //{
        //    Console.WriteLine($"***");
        //}


        //Se puede tener dos metodos homonimos siempre que tengan parámetros diferentes
        //Cambian los overloads con ctrl + shift + spacebar

        static void WriteResult(string description, string result)
        {
            Console.WriteLine(description + ": " + result);
        }

        static void WriteResult(string description, int result)
        {
            Console.WriteLine(description + ": " + result);
        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine(description + ": " + result);
        }

    }
}
