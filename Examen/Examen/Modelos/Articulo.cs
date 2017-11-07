using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen
{
    public class Articulo
    {

        public int id { get; set; }
        public string nombre { get; set; }
       public string autor { get; set; }
        public string categoria { get; set; }
        public double precio { get; set; }
        public int existencias { get; set; }

        public char tipo { get; set; }

        public Articulo(int id,string nombre, string autor, string categoria, double precio, int existencias, char tipo)
        {
            this.id = id;
            this.nombre = nombre;
            this.autor = autor;
            this.categoria = categoria;
            this.precio = precio;
            this.existencias = existencias;
            this.tipo = tipo;
        }


        public Articulo()
        {
            
        }

        public Articulo buscarArticulo(int id)
        {
            Articulo a = new Articulo();
            List<Articulo> lista = Utils.RunningData.listArticulos;
            foreach (var item in lista)
            {
                if (item.id == id)
                {
                    return item;
                }
            }
            return a;
        }

        public void editar(Articulo art)
        {
            
            Utils.RunningData.listArticulos.Remove(buscarArticulo(art.id));
            Utils.RunningData.listArticulos.Add(art);


        }
        public void eliminar(int id)
        {
            Utils.RunningData.listArticulos.Remove(buscarArticulo(id));
        }

    }
}
