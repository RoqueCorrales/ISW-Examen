using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen
{
    
     public class Compras
    {
        Utils.Logica log = new Utils.Logica();
        public int id { get; set; }
        public int idUsuario { get; set; }
        public int idArticulo { get; set; }
        public int cantidadComprada { get; set; }

        public Compras(int id, int idUsuario, int idArticulo, int cantidadComprada)
        {
            this.id = id;
            this.idUsuario = idUsuario;
            this.idArticulo = idArticulo;
            this.cantidadComprada = cantidadComprada;
        }

        public Compras()
        {
         
        }
        

        public Boolean compraRealizada(string cedulaUsuario, int idArticulo,int cantidadAdquirida)
        {
            Compras c = new Compras();

            c.id = log.generadorId();
            c.idArticulo = idArticulo;
            c.idUsuario = int.Parse(cedulaUsuario);
            c.cantidadComprada = cantidadAdquirida;
            if (Utils.RunningData.listCompras == null)
            {
                List<Compras> oList = new List<Compras>();
                oList.Add(c);
                Utils.RunningData.listCompras = oList;
                return true;
            }
            else
            {
                Utils.RunningData.listCompras.Add(c);
                return true;
            }
           
          
            return false;
        }

        public double calcularPrecio(int cantidad, double valor)
        {
            double precio = 0;
            precio = cantidad * valor;

            return precio;
        }
    }
}
