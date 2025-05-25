using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSimple2T1.Models
{
    public class Transaccion
    {
        [Key]
        public int TransaccionId { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string? Descripcion { get; set; }
        public int ? CuentaOrigenId { get; set; }
        public int ? CuentaDestinoId { get; set; }

    }
}
