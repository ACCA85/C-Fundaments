using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Grades
{ 
    //por convencion para manejar eventos primero se pone de parametro el sender del evento (en nuestro caso gradebook)
    //y despues se colocan los argumentos del evento definidos en otra clase inherit from :EventArgs
    public delegate void NameChangedDelegated(object sender, NameChangedEventArgs args);
  
}
