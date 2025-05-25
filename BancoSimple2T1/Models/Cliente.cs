using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSimple2T1.Models
{
    public class Cliente
    {
        [Key] 
        public int ClienteId { get; set; }
        public required string Nombre { get; set; }
        public required string Identificacion { get; set; }

        // Relacion uno a muchos con cuentas 
        public List <Cuenta> Cuentas { get; set;} = new List<Cuenta>();
    }
}
