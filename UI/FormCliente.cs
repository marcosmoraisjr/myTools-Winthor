using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using Business.Logic.Layer;

namespace UI
{
    public partial class FormCliente : Form
    {
        public FormCliente()
        {
            InitializeComponent();
        }

        private void buttonBuscaCodigoCliente_Click(object sender, EventArgs e)
        {
            String objetodepesquisa = maskedTextBox1.Text.Trim();
            if (objetodepesquisa == string.Empty)
            {
                MessageBox.Show("Obrigatório informar código do cliente.");
                return;
            }

            StringBuilder SQL = new StringBuilder();
            DataTable dt = new DataTable();
            BLL_Curinga cmd = new BLL_Curinga();

            if (radioButton1.Checked)
            {
                SQL.Append("SELECT * FROM PCCLIENT WHERE PCCLIENT.CODCLI ='" + objetodepesquisa + "'");
            }
            if (radioButton2.Checked)
            {
                SQL.Append("SELECT * FROM PCCLIENT WHERE PCCLIENT.CGCENT ='" + objetodepesquisa + "'");
            }
            if (radioButton3.Checked)
            {
                SQL.Append("SELECT * FROM PCCLIENT WHERE PCCLIENT.CGCENT ='" + objetodepesquisa + "'");
            }

            dt = cmd.FindByQuery(SQL.ToString());

            if (dt.Rows.Count < 1)
            {
                MessageBox.Show(string.Format("Nenhum registro encontrado para a pesquisa {0}", objetodepesquisa));
                maskedTextBox1.Focus();
            }
            else
            {
                txtCodigo.Text = dt.Rows[0]["CODCLI"].ToString();
                txtNome.Text = dt.Rows[0]["CLIENTE"].ToString();
                txtLogradouro.Text = dt.Rows[0]["ENDERCOB"].ToString();
                txtNumero.Text = dt.Rows[0]["NUMEROCOB"].ToString();
                txtComplemento.Text = "";
                txtBairro.Text = dt.Rows[0]["BAIRROCOB"].ToString();
                txtCEP.Text = dt.Rows[0]["CEPCOB"].ToString();
                txtCidade.Text = dt.Rows[0]["MUNICCOB"].ToString();
                txtEstado.Text = dt.Rows[0]["ESTCOB"].ToString();
                txtCNPJCPF.Text = dt.Rows[0]["CGCENT"].ToString();
                txtIERG.Text = dt.Rows[0]["IEENT"].ToString();
                txtLimite.Text = Convert.ToDecimal(dt.Rows[0]["LIMCRED"].ToString()).ToString("R$ ##,##0.00");

                txtNome.ReadOnly = true;
                txtLogradouro.ReadOnly = true;
                txtBairro.ReadOnly = true;
                txtCEP.ReadOnly = true;
                txtCidade.ReadOnly = true;
                txtEstado.ReadOnly = true;
                txtCNPJCPF.ReadOnly = true;
                txtIERG.ReadOnly = true;
                txtLimite.ReadOnly = true;

                panel1.Enabled = true;
                tabControl1.SelectedTab = this.tabPage1;
                tabPage1.Focus();
                maskedTextBox1.Focus();
            }

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtComplemento_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblNumero_Click(object sender, EventArgs e)
        {

        }

        private void txtLimite_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void Limite_Click(object sender, EventArgs e)
        {

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIERG_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void txtCNPJCPF_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void txtEstado_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void txtCEP_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCidade_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBairro_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLogradouro_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
