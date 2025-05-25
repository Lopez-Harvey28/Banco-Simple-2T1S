using BancoSimple2T1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSimple2T1
{
    public class AccionesRepetidas
    {
        //En esta clase estaran las acciones que se repiten en varias partes del codigo
        //Aqui en este metodo hacemos que las validaciones solo se tengan que llamar para validarlas
        public static bool ValidarCampos(params string[] campos)
        {
            return campos.All(campos => !string.IsNullOrWhiteSpace(campos));
        }

    }
    //Con esto facilitaremos el uso de mensajes en el codigo
    public static class Mensajes
    {
        //Este para cuando todo vaya bien
        public static void MostrarExito(string mensaje)
        {
            MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Este por si ocurre un error al momento de ingresar algo
        public static void MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

}
