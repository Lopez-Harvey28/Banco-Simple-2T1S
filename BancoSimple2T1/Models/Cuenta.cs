using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSimple2T1.Models
{
    public class Cuenta
    {
        [Key]
        public int CuentaId { get; set; }
        public string NumeroCuenta { get; set; }
        public decimal Saldo { get; set; }
        public bool Activa { get; set; } = true;
        
        // Nombre de propiedad de capitalizacion por convencion
        public int ClienteId { get; set; }
        public Cliente cliente { get; set; }

    }
}
          
