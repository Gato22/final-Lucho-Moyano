using Rec.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rec.Windows
{
    public partial class FrmCuadrilateroAE : Form
    {
        private Cuadrilatero t;
        internal Cuadrilatero GetCuadrilatero()
        {
            return t;
        }

        public FrmCuadrilateroAE()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (t == null)
                {
                    t = new Cuadrilatero();
                }
                t.Lado1 = double.Parse(txtLado1.Text);
                t.Lado2 = double.Parse(txtLado2.Text);
               
                

                DialogResult = DialogResult.OK;
            }
        }
        
        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            double lado1 = 0, lado2 = 0;
            if (!double.TryParse((txtLado1.Text), out lado1))
            {
                valido = false;
                errorProvider1.SetError(txtLado1, "Ingrese un numero");
            }
            else if (lado1 <= 0)
            {
                valido = false;
                errorProvider1.SetError(txtLado1, "no puede ser menor que 0");
            }
            if (!double.TryParse((txtLado2.Text), out lado2))
            {
                valido = false;
                errorProvider1.SetError(txtLado2, "Ingrese un numero");
            }
            else if (lado2 <= 0)
            {
                valido = false;
                errorProvider1.SetError(txtLado2, "no puede ser menor que 0");
            }
            return valido;
        }
    }
}
