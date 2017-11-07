using System;
using System.Windows.Forms;

namespace Examen
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
            this.CenterToScreen();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            usuario u = new usuario();
            u.nombre = txtNombre.Text;
            u.correo = txtCorreo.Text;
            u.cedula = txtCed.Text;
            u.pass = txtPass.Text;
            u.estado = false;
            
            Utils.RunningData.listUsuarios.Add(u);
            MessageBox.Show("Usuario Creado");
            Form1 login = new Form1();
            login.Show();
            this.Hide();
        }

        private void Registro_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }
    }
}
