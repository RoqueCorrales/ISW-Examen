using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Examen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
            if (Utils.RunningData.listUsuarios == null){
                this.cargarAdmin();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!login())
            {
                MessageBox.Show("Crendenciales no validas");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registro r = new Registro();
            r.ShowDialog();
        }

        private Boolean login()
        {
            List<usuario> a = Utils.RunningData.listUsuarios;
            foreach (var item in a)
            {
                if (txtUser.Text==item.correo && txtPass.Text==item.pass)
                {
                    Utils.RunningData.Usuario = item;
                    Principal p = new Principal();
                    p.Show();
                    this.Hide();
                    return true;
                   
                }

            }

            return false;
        }

        public void cargarAdmin()
        {
            usuario u = new usuario();
            u.nombre = "admin";
            u.correo = "admin";
            u.cedula = "000000";
            u.pass = "123";
            u.estado = true;
            List<usuario> list = new List<usuario>();
            list.Add(u);
            Utils.RunningData.listUsuarios = list;
        }
    }
}
