using BancoSimple2T1.Data;
using BancoSimple2T1.Servicios;
using Microsoft.EntityFrameworkCore;
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
    public partial class TransaccionesForms : Form
    {
        // Se ocupa el readonly para que no se pueda modificar el monto desde afuera de la clase
        public decimal Monto { get; private set; }
        private readonly int _cuentaOrigenId;
        private readonly int _cuentaDestinoId;
        //Hacemos los mismos cambios que hicimos anteriormente
        private readonly BancoSimpleContext _dbcontext;
        public TransaccionesForms(int cuentaOrigenId, int cuentaDestinoId)
        {
            InitializeComponent();
            _cuentaOrigenId = cuentaOrigenId;
            _cuentaDestinoId = cuentaDestinoId;

            //Se cambio aquí
            _dbcontext = new BancoSimpleContext();
            CargarInformacionCuenta();

        }
        //este es un metodo hecho para cargar las cuentas 
        private void CargarInformacionCuenta()
        {
            var servicio = new Servicio_Transaccion();
            try
            {
                var (infoOrigen, infoDestino, saldo) = servicio.ObtenerInfoCuentas(_cuentaOrigenId, _cuentaDestinoId);
                lblOrigen.Text = infoOrigen;
                lblDestino.Text = infoDestino;
                lblDisponible.Text = saldo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar cuentas: " + ex.Message);
                Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        //Aqui lleva una condicional para que el monto sea mayor a 0
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtSaldo.Text, out decimal monto))
            {
                var servicio = new Servicio_Transaccion();
                if (servicio.ValidarMonto(monto))
                {
                    Monto = monto;
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Ingrese un monto mayor a 0");
                }
            }
            else
            {
                MessageBox.Show("Monto inválido");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
