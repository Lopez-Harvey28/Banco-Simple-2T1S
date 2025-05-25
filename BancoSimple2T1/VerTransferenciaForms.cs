using BancoSimple2T1.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancoSimple2T1
{
    public partial class VerTransferenciaForms : Form
    {
        //Aqui ocurre lo mismo, el objeto "con" por si solo no nos dice nada al igual que antes
        //Por ello lo cambiaremos y utlizaremos el mismo nombre para llevar la misma logica que antes y asi no confundirnos por palabras sin relación
        //Se utiliza readonly BancoSimpleContext _dbcontext new BancoSimpleContext();
        private readonly BancoSimpleContext _dbcontext = new BancoSimpleContext();
        public VerTransferenciaForms()
        {
            InitializeComponent();
            CargarTransferencias();
        }

        private void CargarTransferencias()
        {
            //así que lo cambiamos a una con la que ya estamos realcionado
            dgvTransferencias.DataSource = _dbcontext.Transacciones.ToList();
        }
    }
}
