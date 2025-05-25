using BancoSimple2T1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BancoSimple2T1.Servicios
{
    public class Servicio_Transaccion
    {
        //Esta clase lleva la logica de la transaccion y las validaciones correspondientes 
        private readonly BancoSimpleContext _context;

        public Servicio_Transaccion()
        {
            _context = new BancoSimpleContext();
        }

        public (string infoOrigen, string infoDestino, string saldoDisponible) ObtenerInfoCuentas(int cuentaOrigenId, int cuentaDestinoId)
        {
            // Busca la cuenta origen incluyendo la información del cliente
            var cuentaOrigen = _context.Cuentas
                .Include(c => c.cliente)
                .FirstOrDefault(c => c.CuentaId == cuentaOrigenId);
            // Busca la cuenta destino incluyendo la información del cliente
            var cuentaDestino = _context.Cuentas
                .Include(c => c.cliente)
                .FirstOrDefault(c => c.CuentaId == cuentaDestinoId);
            // Verifica que ambas cuentas existan
            if (cuentaOrigen == null || cuentaDestino == null)
                throw new ArgumentException("Una de las cuentas no existe.");
            // Prepara la información de ambas cuentas y del saldo disponible
            string infoOrigen = $"Nombre: {cuentaOrigen.cliente.Nombre} cuenta {cuentaOrigen.NumeroCuenta}";
            string infoDestino = $"Nombre: {cuentaDestino.cliente.Nombre} cuenta {cuentaDestino.NumeroCuenta}";
            string saldo = $"Saldo Disponible : {cuentaOrigen.Saldo:c}";

            return (infoOrigen, infoDestino, saldo);
        }

        public bool ValidarMonto(decimal monto)
        {
            return monto > 0;
        }
    }
}
