using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;//adicionado
using System.Windows.Forms;

namespace WS01
{
    public partial class FrmIMC : Form
    {
        public FrmIMC()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Environment.Exit(0); // Remove tambem da barra de tarefas
        }

        private void FrmIMC_Load(object sender, EventArgs e)
        {
            IMC imc = new IMC();
            List<IMC> mcs = imc.ListaIMC();
            dgvIMC.DataSource = mcs;
        }

        private async void btnVerificar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "")
            {
                MessageBox.Show("Por Favor, Preencha com o seu nome!");
                this.ActiveControl = txtNome; //coloca o cursor lá
                return; // Para e sai do método
            }
            else if(txtPeso.Text == "")
            {
                MessageBox.Show("Por Favor, Preencha com o seu peso!");
                this.ActiveControl = txtPeso;
                return;
            }
            else if (txtAltura.Text == "")
            {
                MessageBox.Show("Por Favor, Preencha com a sua altura!");
                this.ActiveControl = txtAltura;
                return;
            }
            double imc, peso, altura;
            peso = Convert.ToDouble(txtPeso.Text);
            altura = Convert.ToDouble(txtAltura.Text);
            imc = (peso / (altura * altura));
            lblResultado.Text = imc.ToString("F");
            await Task.Delay(3000);
            IMC mc = new IMC();
            mc.Inserir(txtNome.Text, txtAltura.Text, txtPeso.Text, lblResultado.Text);
            List<IMC> mcs = mc.ListaIMC();
            dgvIMC.DataSource = mcs;
            txtNome.Text = "";
            txtPeso.Text = "";
            txtAltura.Text = "";
            lblResultado.Text = "";
            
        }

        private void dgvIMC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvIMC.Rows[e.RowIndex];
                this.dgvIMC.Rows[e.RowIndex].Selected = true;
                txtId.Text = row.Cells[0].Value.ToString();
                txtNome.Text = row.Cells[1].Value.ToString();
                txtPeso.Text = row.Cells[3].Value.ToString();
                txtAltura.Text = row.Cells[2].Value.ToString();
                lblResultado.Text = row.Cells[4].Value.ToString();
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "" || txtNome.Text == "" || txtPeso.Text == "" || txtAltura.Text == "")
            {
                MessageBox.Show("Existem Campos, Por Favor Preencha!!");
                return;
            }
            double imc, peso, altura;
            peso = Convert.ToDouble(txtPeso.Text);
            altura = Convert.ToDouble(txtAltura.Text);
            imc = (peso / (altura * altura));
            lblResultado.Text = imc.ToString("F");

            int Id = Convert.ToInt32(txtId.Text);
            await Task.Delay(3000);
            IMC mc = new IMC();
            mc.Atualizar(Id, txtNome.Text, txtAltura.Text, txtPeso.Text, lblResultado.Text);
            List<IMC> mcs = mc.ListaIMC();
            dgvIMC.DataSource = mcs;
            txtNome.Text = "";
            txtPeso.Text = "";
            txtAltura.Text = "";
            lblResultado.Text = "";
            txtId.Text = "";
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "" || txtNome.Text == "" || txtPeso.Text == "" || txtAltura.Text == "")
            {
                MessageBox.Show("Existem Campos, Por Favor Preencha!!");
                return;
            }
            int Id = Convert.ToInt32(txtId.Text);
            IMC mc = new IMC();
            mc.Excluir(Id);
            List<IMC> mcs = mc.ListaIMC();
            dgvIMC.DataSource = mcs;
            txtNome.Text = "";
            txtPeso.Text = "";
            txtAltura.Text = "";
            lblResultado.Text = "";
            txtId.Text = "";
        }
    }
}
