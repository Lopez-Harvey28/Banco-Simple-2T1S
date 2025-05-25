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

            var cuenta = new Cuenta
            {
                NumeroCuenta = numeroCuenta.Trim(),
                Saldo = saldoInicial,
                ClienteId = clienteId,
                Activa = true
            };

            _context.Cuentas.Add(cuenta);
            _context.SaveChanges();

            return cuenta;
        }
    }
}
