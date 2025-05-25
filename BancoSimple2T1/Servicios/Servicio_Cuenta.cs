using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BancoSimple2T1.Data;
using BancoSimple2T1.Models;

namespace BancoSimple2T1.Servicios
{
    //Esta clase lleva toda la logica de cuentas y validaciones 
    public class Servicio_Cuenta
    {
        private readonly BancoSimpleContext _context;

        public Servicio_Cuenta()
        {
            _context = new BancoSimpleContext();
        }

        public Cuenta CrearCuenta(string numeroCuenta, decimal saldoInicial, int clienteId)
        {
            if (string.IsNullOrWhiteSpace(numeroCuenta))
                throw new ArgumentException("El número de cuenta es requerido");

            // Obtener el cliente correspondiente al clienteId
            var cliente = _context.Clientes.FirstOrDefault(c => c.ClienteId == clienteId);
            if (cliente == null)
                throw new ArgumentException("El cliente especificado no existe");

            
            var cuenta = new Cuenta
            {
                NumeroCuenta = numeroCuenta.Trim(),
                Saldo = saldoInicial,
                ClienteId = clienteId,
                cliente = cliente, // Establecer el miembro requerido 'cliente'
                Activa = true
            };

            _context.Cuentas.Add(cuenta);
            _context.SaveChanges();

            return cuenta;
        }
    }
}
