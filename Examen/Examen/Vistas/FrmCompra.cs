using System;
using System.Data;
using System.Windows.Forms;

namespace Examen
{
    public partial class FrmCompra : Form
    {
        Compras com;
        Articulo art;
        public FrmCompra()
        {

            InitializeComponent();
            validar();
            cargarTable('p');
            int id;
            com = new Compras();
            art = new Articulo();
            

        }

        public void cargarTable(char tipo)
        {
            dataTable.Rows.Clear();
            if (Utils.RunningData.listArticulos == null)
            {
                // MessageBox.Show("No hay articulos");
            }
            else
            {
                foreach (var item in Utils.RunningData.listArticulos)
                {
                    if (item.tipo == tipo)
                    {
                        this.dataTable.Rows.Add(item.nombre, item.categoria, item.autor, item.precio, item.existencias, " ", item.id);
                    }

                }
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbMusica.Checked)
            {
                cargarTable('c');
            }
            else if (rdbPelis.Checked)
            {
                cargarTable('p');
            }

        }

        private void dataTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int valor1 = (int)dataTable.CurrentRow.Cells["Id"].Value;
            MessageBox.Show(valor1 + "");

        }

        private void dataTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            string texto = Microsoft.VisualBasic.Interaction.InputBox(
            "Indique cantidad a comprar?",
            "Cantidad ",
            "1");


            int idArticulo = (int)dataTable.CurrentRow.Cells["Id"].Value;
            Utils.RunningData.articulo =  art.buscarArticulo(idArticulo);
            string cedula = Utils.RunningData.Usuario.cedula;


            double precio = (double)dataTable.CurrentRow.Cells["Precio"].Value;


            if (com.compraRealizada(cedula, idArticulo, Int32.Parse(texto)))
            {
                MessageBox.Show("La cantidad a cancelar es: " + com.calcularPrecio(Int32.Parse(texto), precio));
                Utils.RunningData.articulo.existencias = Utils.RunningData.articulo.existencias - Int32.Parse(texto);
               
                MessageBox.Show("Compra exitosa ");

            }
            else
            {
                MessageBox.Show("Problema de compra");
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            int idArticulo = (int)dataTable.CurrentRow.Cells["Id"].Value;
            Utils.RunningData.articulo = art.buscarArticulo(idArticulo);
            this.Close();
            FrmArticulo p = new Examen.FrmArticulo(Utils.RunningData.articulo);
            p.Show();
           


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            art = new Examen.Articulo();
            art.eliminar((int)dataTable.CurrentRow.Cells["Id"].Value);
            MessageBox.Show("Elimindado");
            cargarTable('p');


        }

        private void validar()
        {
            if(Utils.RunningData.Usuario.nombre != "admin")
            {
                btnEditar.Hide();
                btnEliminar.Hide();
            }
        }

    }
}
