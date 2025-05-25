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
    public partial class AgregarCuentaForm : Form
    {
        public Cuenta NuevaCuenta { get;  private set; }
        private int _clienteId;
        public AgregarCuentaForm(int clienteId)
        {
            InitializeComponent();
            _clienteId = clienteId;
        }
        //boton para crear una nueva cuenta
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                var servicio = new Servicio_Cuenta();
                NuevaCuenta = servicio.CrearCuenta(txtNumeroCuenta.Text, numSaldoInicial.Value, _clienteId);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
