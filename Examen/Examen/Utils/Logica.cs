using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Utils
{
   public class Logica
    {
        public int generadorId()
        {
            int serial = 0;
            Random rnd = new Random();

            serial = rnd.Next(0, 999999);
            return serial;
        }


    }
}
