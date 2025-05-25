using BancoSimple2T1.Data;
using BancoSimple2T1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSimple2T1.Servicios
{
    //Esta clase lleva la logica para trabajar con los clientes y aqui van las validaciones 
    public class Servicio_Cliente
    {
        private readonly BancoSimpleContext _context;

        public Servicio_Cliente()
        {
            _context = new BancoSimpleContext();
        }

        public Cliente CrearCliente(string nombre, string identificacion)
        {
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(identificacion))
            {
                throw new ArgumentException("Todos los campos son necesarios");
            }

            var cliente = new Cliente
            {
                Nombre = nombre.Trim(),
                Identificacion = identificacion.Trim()
            };

            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            return cliente;
        }
    }
}
