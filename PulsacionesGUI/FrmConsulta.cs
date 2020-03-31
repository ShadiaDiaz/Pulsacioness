using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using BLL;

namespace PulsacionesGUI
{
    public partial class FrmConsulta : Form
    {
        

        public FrmConsulta()
        {
            InitializeComponent();
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            DtgPersona.DataSource = null;
            DtgPersona.DataSource = PersonaService.Consultar();
        }

        private void DtgPersona_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmConsulta_Load(object sender, EventArgs e)
        {

        }
    }
}
