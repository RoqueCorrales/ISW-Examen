using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Examen
{
    public partial class FrmArticulo : Form
    {
        Utils.Logica logica = new Utils.Logica();
        Articulo art = new Articulo();
        public FrmArticulo()
        {
            InitializeComponent();
            this.CenterToScreen();
            btnEditar.Hide();

        }
        public FrmArticulo(Articulo a)
        {
            InitializeComponent();
            this.CenterToScreen();
            cargarDatos();
            btnSave.Hide();
        }

        private void rdbPeli_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCancion.Checked)
            {
                lblLista.Visible = true;
                txtLista.Visible = true;
            }
            else
            {
                lblLista.Visible = false;
                txtLista.Visible = false;
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            
            if (rdbCancion.Checked)
            {
                Musica oCancion = new Musica();
                oCancion.nombre = txtNombre.Text;
                oCancion.autor = txtAutor.Text;
                oCancion.categoria = txtCategoria.Text;
                oCancion.existencias = int.Parse(txtCant.Text);
                oCancion.precio = int.Parse(txtPrecio.Text);
                oCancion.lista = int.Parse(txtLista.Text);
                oCancion.tipo = 'c';
                oCancion.id = logica.generadorId();
                this.saveArticle(oCancion);
                
            }
            else
            {
                Pelicula oPelicula = new Pelicula();
                oPelicula.nombre = txtNombre.Text;
                oPelicula.autor = txtAutor.Text;
                oPelicula.categoria = txtCategoria.Text;
                oPelicula.existencias = int.Parse(txtCant.Text);
                oPelicula.precio = int.Parse(txtPrecio.Text);
                oPelicula.tipo = 'p';
                oPelicula.id = logica.generadorId();            
                    this.saveArticle(oPelicula);

            }
            MessageBox.Show("Articulo creado");
            this.Close();
        }
        private void saveArticle(Articulo oArticle)
        {
            if (Utils.RunningData.listArticulos == null)
            {
                List<Articulo> oList = new List<Articulo>();
                oList.Add(oArticle);
                Utils.RunningData.listArticulos = oList;
            }
            else
            {
                Utils.RunningData.listArticulos.Add(oArticle);
            }

        }

        private void cargarDatos()
        {
            Articulo a = new Articulo();
            a = Utils.RunningData.articulo;
            txtAutor.Text = a.autor;
            txtCant.Text = a.existencias.ToString();
            txtCategoria.Text = a.categoria;
            txtNombre.Text = a.nombre;
            txtPrecio.Text = a.precio.ToString();
            if (a.tipo == 'c')
            {
                rdbCancion.Select();
                rdbPeli.Hide();
            }
            else
                rdbPeli.Select();
            rdbCancion.Hide();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int id = Utils.RunningData.articulo.id;
            if (rdbCancion.Checked)
            {
                Musica oCancion = new Musica();
                oCancion.nombre = txtNombre.Text;
                oCancion.autor = txtAutor.Text;
                oCancion.categoria = txtCategoria.Text;
                oCancion.existencias = int.Parse(txtCant.Text);
                oCancion.precio = int.Parse(txtPrecio.Text);
               // oCancion.lista = int.Parse(txtLista.Text);
                oCancion.tipo = 'c';
                oCancion.id = id;
               art.editar(oCancion);

            }
            else
            {
                Pelicula oPelicula = new Pelicula();
                oPelicula.nombre = txtNombre.Text;
                oPelicula.autor = txtAutor.Text;
                oPelicula.categoria = txtCategoria.Text;
                oPelicula.existencias = int.Parse(txtCant.Text);
                oPelicula.precio = int.Parse(txtPrecio.Text);
                oPelicula.tipo = 'p';
                oPelicula.id = id;
               art.editar(oPelicula);

            }
         
            MessageBox.Show("Articulo editado");
            this.Close();
        }
    }
}
