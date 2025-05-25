using BancoSimple2T1.Data;
using BancoSimple2T1.Models;
using Microsoft.EntityFrameworkCore;
namespace BancoSimple2T1
    
{
    public partial class Form1 : Form
    {
        //Cambiamos el nombre del objeto para que sea mas familiar con el tipo de codigo que estamos trabajando 
        //pasa de ser con(No se relaciona mucho con los conceptos del entorno) a dbcontext haciendo que sea más entidible el tipo de trabajo que hace
        
        private BancoSimpleContext _dbcontext = new BancoSimpleContext();
        public Form1()
        {
            InitializeComponent();
            CargarInformacionCuenta();
        }

        private void CargarInformacionCuenta()
        {
            //Pasamos a actualizar el objeto en cada uno de sus usos
            //Como aquí
            var cuentas = _dbcontext.Cuentas.
                Include(c => c.cliente).Where(c => c.Activa).
                Select(c => new
                {
                    c.CuentaId,
                    c.NumeroCuenta,
                    c.Saldo,
                    NombreCliente = c.cliente.Nombre,
                    c.Activa,
                    c.ClienteId
                }).ToList();
            //Aquí también
            dgvClientes.DataSource = _dbcontext.Clientes.ToList();
            dgvCuentas.DataSource = cuentas;
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            var form = new AgregarClienteForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                //Para no repetir la misma palabra dire el proque de estos cambios
                //Una de las razones para cambiar el nombre del objeto es para implementarlo en otros usos
                _dbcontext.Clientes.Add(form.NuevoCliente);
                _dbcontext.SaveChanges();
                CargarInformacionCuenta();

            }
        }

        private void btnAgregarCuenta_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un cliente primero");
                return;
            }
            var clienteId = (int)dgvClientes.SelectedRows[0].Cells["ClienteId"].Value;
            var form = new AgregarCuentaForm(clienteId);
            if (form.ShowDialog() == DialogResult.OK)
            {
                //Por ejemplo este objeto es usado en otras partes del codigo 
                //Y su trabajo en todos es similar
                _dbcontext.Cuentas.Add(form.NuevaCuenta);
                _dbcontext.SaveChanges();
                CargarInformacionCuenta(); 
            }
        }
        //Transacciones
        private void RealizarTransaccion(int cuentaOrigenId, int cuentaDestinoId, decimal monto)
        {
            //implementacion
            //Nivel de aislamiento
            using var transferencia = _dbcontext.Database.BeginTransaction(System.Data.IsolationLevel.Serializable);
            try
            {
                //Filtro y ordenacion
                //Entonces para que sea mas fácil de identificar su funcionamiento es mejor trabajar el mismo nombre 
                //en las respectivas partes del codigo donde se utilizará
                var cuentaOrigen = _dbcontext.Cuentas.FirstOrDefault(c => c.CuentaId == cuentaOrigenId);
                var cuentaDestino = _dbcontext.Cuentas.FirstOrDefault(c => c.CuentaId == cuentaDestinoId);

                if (cuentaOrigen == null || cuentaDestino == null)
                    throw new Exception("Una o ambas cuentas no existen");

                if (!cuentaOrigen.Activa || !cuentaDestino.Activa)
                    throw new Exception("Una o ambas cuentas están inactivas");
                if (cuentaOrigen.Saldo < monto)
                    throw new Exception("Saldo Insuficiente en la cuenta Origen");

                cuentaOrigen.Saldo -= monto;
                cuentaDestino.Saldo += monto;

                //Registrar la transaccion
                //Para que los que vean codigo les sea más fácil de identificar y sepan su uso
                _dbcontext.Transacciones.Add(new Transaccion
                {
                    Monto = monto,
                    Fecha = DateTime.Now,
                    Descripcion = "Transferencia entre cuentas",
                    CuentaOrigenId = cuentaOrigenId,
                    CuentaDestinoId = cuentaDestinoId
                });
                //Aqui tambien se modifico
                _dbcontext.SaveChanges();
                transferencia.Commit();
                MessageBox.Show("Transferencia realizada");
                CargarInformacionCuenta();


            }
            catch (Exception ex)
            {
                transferencia.Rollback();

                var inner = ex.InnerException?.Message ?? "No hay InnerException";
                MessageBox.Show($"Error al guardar:\n{ex.Message}\n\nDetalle:\n{inner}");
            }

        }

        private void btnTransferencia_Click(object sender, EventArgs e)
        {
            if (dgvCuentas.SelectedRows.Count != 2)
            {
                MessageBox.Show("Seleccione exactamente 2 cuentas");
                return;
            }
            var cuentaOrigenId = (int)dgvCuentas.SelectedRows[1].Cells["CuentaId"].Value;
            var cuentaDestinoId = (int)dgvCuentas.SelectedRows[0].Cells["CuentaId"].Value;

            var form = new TransaccionesForms(cuentaOrigenId, cuentaDestinoId);
            if (form.ShowDialog() == DialogResult.OK)
            {
                RealizarTransaccion(cuentaOrigenId, cuentaDestinoId, form.Monto);
            }

        }

        private void btnBuscarCleinte_Click(object sender, EventArgs e)
        {
            //Busqueda de patrones con like
            var patron = txtBuscarCliente.Text;
            //Otro motivo para el cambio es que al momento de verlo este se realcione inmediatamente con la clase BancoSimpleContext
            var cliente = _dbcontext.Clientes.Where(c => EF.Functions.Like(c.Nombre, $"%{patron}%")).ToList();

            dgvClientes.DataSource = cliente;
        }

        private void btnVerTrans_Click(object sender, EventArgs e)
        {
            var form = new VerTransferenciaForms();
            form.ShowDialog();
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (dgvCuentas.SelectedRows.Count != 1)
            {
                MessageBox.Show("Selecciones solo una cuenta exactamente");
                return;
            }
            else
            {
                var cuentaId = (int)dgvCuentas.SelectedRows[0].Cells["CuentaId"].Value;
                //hacienod que las personas sepan para que se usa
                var cuenta = _dbcontext.Cuentas.Find(cuentaId);
                if (cuenta != null)
                {
                    cuenta.Activa = false;
                    _dbcontext.SaveChanges();
                    CargarInformacionCuenta();
                }
                else
                {
                    MessageBox.Show("La cuenta seleccionada no existe.");
                }

            }
        }
    }
}
