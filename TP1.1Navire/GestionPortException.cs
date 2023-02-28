using System;
using System.Collections.Generic;
using System.Text;

namespace TP1._1Navire.Exceptions
{
    class GestionPortException :Exception
    {
        public GestionPortException(string message)
            : base("Erreur de : " +System.Environment.UserName + " le " + DateTime.Now.ToLocalTime() + "\n" + message) { }
    }
}
