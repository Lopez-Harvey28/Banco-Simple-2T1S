using BancoSimple2T1.Models;
using BancoSimple2T1.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancoSimple2T1
{
    public partial class AgregarClienteForm : Form
    {
        //Cliente creado al aceptar el formulario 
        public Cliente NuevoCliente { get; private set; }
        public AgregarClienteForm()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                var servicio = new Servicio_Cliente();
                NuevoCliente = servicio.CrearCliente(txtNombre.Text, txtIdentificacion.Text);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
