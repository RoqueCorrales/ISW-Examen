

using System.Collections.Generic;

namespace Examen.Utils
{
    public class RunningData
    {
        public static usuario Usuario { get; set; }
        public static Articulo articulo { get; set; }
        public static List<Articulo> listArticulos { get; set; }
        public static List<usuario> listUsuarios { get; set; }

        public static List<Compras> listCompras { get; set; }
    }
}
