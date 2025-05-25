using BancoSimple2T1.Models;
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
            if (!AccionesRepetidas.ValidarCampos(txtNombre, txtIdentificacion))
            {
                //aqui se utilizo el metodo de la clase AccionesRepetidas para evitar la duplicacion de codigo
                Mensajes.MostrarError("Por favor, complete todos los campos.");
                return;
            }
            Mensajes.MostrarExito("Cliente agregado con éxito.");
            NuevoCliente = new Cliente
            {
                Nombre = txtNombre.Text,
                Identificacion = txtIdentificacion.Text
            };
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
