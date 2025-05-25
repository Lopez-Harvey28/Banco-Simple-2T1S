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
        private readonly BancoSimpleContext _dbcontext;

        public Servicio_Cliente()
        {
            _dbcontext = new BancoSimpleContext();
        }

        public Cliente CrearCliente(string nombre, string identificacion)
        {
            if (!AccionesRepetidas.ValidarCampos(nombre,identificacion))
            {
                throw new ArgumentException("Todos los campos son necesarios");
            }
            if (nombre.Any(char.IsDigit))
            {
                throw new ArgumentException("El nombre no puede contener números");
            }
            Mensajes.MostrarExito("Se ha creado el cliente con exito");
            var cliente = new Cliente
            {
                Nombre = nombre.Trim(),
                Identificacion = identificacion.Trim()
            };

            _dbcontext.Clientes.Add(cliente);
            _dbcontext.SaveChanges();

            return cliente;
        }
    }
}
