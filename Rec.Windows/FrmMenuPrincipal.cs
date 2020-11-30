using Rec.BL;
using Rec.DL;
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
    public partial class FrmMenuPrincipal : Form
    {
        private List<Cuadrilatero> Lista;
        RepositorioDeCuadrilatero repositorio = new RepositorioDeCuadrilatero();
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmCuadrilateroAE frm = new FrmCuadrilateroAE();
            frm.Text = "nuevo";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                Cuadrilatero t = frm.GetCuadrilatero();
                repositorio.Agregar(t);
                DataGridViewRow r = ConstruirFila(t);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private DataGridViewRow ConstruirFila(Cuadrilatero t)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            SetearFila(r, t);
            return r;
        }

        private void SetearFila(DataGridViewRow r, Cuadrilatero t)
        {
            r.Cells[cmnLado1.Index].Value = t.Lado1;
            r.Cells[cmnLado2.Index].Value = t.Lado2;            
            r.Cells[cmnPerimetro.Index].Value = t.GetPerimetro();
            r.Cells[cmnArea.Index].Value = t.GetArea();           
            r.Tag = t;
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            Lista = repositorio.GetLista();
            if (repositorio.GetCantidad() > 0)
            {
                MostrarDatosEnGrilla();
            }
        }

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var t in Lista)
            {
                var r = ConstruirFila(t);
                AgregarFila(r);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Lista = repositorio.GetLista();
            MostrarDatosEnGrilla();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea guardar?", "guardar", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                repositorio.GuardarArchivo();
            }
        }

        private void btnNuevoCuadrado_Click(object sender, EventArgs e)
        {
            FrmCuadradoAE frm = new FrmCuadradoAE();
            frm.Text = "nuevo";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                Cuadrilatero t = frm.GetCuadrilatero();
                repositorio.Agregar(t);
                DataGridViewRow r = ConstruirFila2(t);
                AgregarFila(r);
            }
        }

        private DataGridViewRow ConstruirFila2(Cuadrilatero t)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            SetearFila2(r, t);
            return r;
        }

        private void SetearFila2(DataGridViewRow r, Cuadrilatero t)
        {
            r.Cells[cmnLado1.Index].Value = t.Lado1;            
            r.Cells[cmnPerimetro.Index].Value = t.GetPerimetro();
            r.Cells[cmnArea.Index].Value = t.getarea2();
            r.Tag = t;
        }

        private void lado1MenorAMayorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lista = repositorio.OrdenarAscendente();
            MostrarDatosEnGrilla();
        }

        
    }
}
