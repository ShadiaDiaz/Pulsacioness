using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PulsacionesGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void RegistrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPersona frmRegistro = new FrmPersona();
            frmRegistro.MdiParent = this;
            frmRegistro.Show();
            
        }

        private void ConsultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsulta frmConsultar = new FrmConsulta();
           
            frmConsultar.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PersonaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FrmPersona()); 

        }

        private void SalirToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        private void AbrirFormInPanel(object formHijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }
        private void consultarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FrmConsulta());
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
    }

