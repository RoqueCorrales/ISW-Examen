using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Examen
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
            this.showButtons();
            this.CenterToScreen();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmArticulo a = new FrmArticulo();
            a.Show();
        }

        private void showButtons() {
            if (Utils.RunningData.Usuario.estado)
            {
                btnCrear.Visible = true;
            }
        }

        private void btnCompra_Click(object sender, EventArgs e)
        {
            FrmCompra oCompra = new FrmCompra();
            oCompra.ShowDialog();
        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
