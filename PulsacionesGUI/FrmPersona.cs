using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Entity;

namespace PulsacionesGUI
{
    public partial class FrmPersona : Form
    {
       

        public FrmPersona()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Persona persona = new Persona();

            persona.Identificacion = txtIdentificacion.Text;
            persona.Nombre = TxtNombre.Text;
            persona.Edad = Convert.ToInt32(TxtEdad.Text);
            persona.Sexo = ComboSexo.Text.Trim();
            persona.CalcularPulsaciones();

            TxtPulsaciones.Text = persona.Pulsaciones.ToString();
            string mensaje = PersonaService.Guardar(persona);
            MessageBox.Show(mensaje, "Mensaje de Guardado",MessageBoxButtons.OK,MessageBoxIcon.Information);
            Limpiar();
        }


        private void Label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Limpiar()
        {
            txtIdentificacion.Text = "";
            TxtNombre.Text = "";
            TxtEdad.Text = "";
            ComboSexo.Text = " ";
            TxtPulsaciones.Text = "";
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            string identificacion = txtIdentificacion.Text;
            if ( identificacion !=  "")
            {
                Persona persona = PersonaService.Buscar(identificacion);
                if (persona != null)
                {
                    TxtNombre.Text = persona.Nombre;
                    TxtEdad.Text = persona.Edad.ToString();
                    ComboSexo.Text = persona.Sexo;
                    TxtPulsaciones.Text = persona.Pulsaciones.ToString();

                }
                else
                {
                    MessageBox.Show($"La persona con la identificacion{identificacion} No se encuentra registrada");
                }
            }
            else
            {
                MessageBox.Show("Por favor digite una identificacion");
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            string identificacion = txtIdentificacion.Text;
            Persona persona = PersonaService.Buscar(identificacion);
            if (persona != null)
            {
                var respuesta = MessageBox.Show("Esta seguro de eliminar la informacion", "Mensaje de Eliminacion", MessageBoxButtons.YesNo);
                if (respuesta == DialogResult.Yes)
                {
                    PersonaService.Eliminar(identificacion);
                    Limpiar();
                }
                else
                {

                }

            }
            else
            {
                MessageBox.Show($"La persona con la identificacion {identificacion} no se encuentra registrada");

            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            txtIdentificacion.Text = "";
            TxtNombre.Text = "";
            TxtEdad.Text = "";
            ComboSexo.Text = " ";
            TxtPulsaciones.Text = "";
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            string identificacion = txtIdentificacion.Text;


            if (identificacion != "")
            {
                Persona persona = PersonaService.Buscar(identificacion);
                if (persona != null)
                {
                    persona.Nombre = TxtNombre.Text;
                    persona.Edad = int.Parse(TxtEdad.Text);
                    persona.Sexo = ComboSexo.Text;
                    Limpiar();
                    string mensaje = PersonaService.Modificar(persona);
                    MessageBox.Show(mensaje, "Mensaje de Modificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show($"Lo sentimos la persona con la identificacion {identificacion} no se encuentra en el sistema");
                }
            }
        }

        private void FrmPersona_Load(object sender, EventArgs e)
        {

        }
    }
    }
