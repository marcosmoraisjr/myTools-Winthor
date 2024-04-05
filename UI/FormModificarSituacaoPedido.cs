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
using System.Data.OracleClient;

namespace UI
{
    public partial class FormModificarSituacaoPedido : Form
    {
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        public static extern bool Beep(UInt32 frequency, UInt32 duration);

        public FormModificarSituacaoPedido()
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

            if (radioButton4.Checked)
            {
                SQL.Append(" select " +
                    " p.numped, " +
                    " p.codfilial, " +
                    " p.codfilialnf, " +
                    " p.posicao, " +
                    " p.codusur, " +
                    " c.codcli, " +
                    " c.CLIENTE, " +
                    " c.ENDERCOB, " +
                    " c.NUMEROCOB, " +
                    " c.BAIRROCOB, " +
                    " c.CEPCOB, " +
                    " c.MUNICCOB, " +
                    " c.ESTCOB, " +
                    " c.CGCENT, " +
                    " c.IEENT," +
                    " c.LIMCRED," +
                    " i.CODPROD," +
                    " i.QT," +
                    " i.PVENDA," +
                    " i.PERDESC," +
                    " i.PERCOM" +
                    " from pcpedc p" +
                    " left join pcpedi i on i.numped = p.numped" +
                    " left join pcclient c on c.codcli = p.codcli" +
                    " where 1 = 1 and" +
                    " p.codcli = c.codcli and" +
                    " p.numped = i.numped and" +
                    " p.numped = '" + objetodepesquisa + "' order by i.numseq");
            }
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
                //BindingSource bs = new BindingSource();
                //bs.DataSource = dt;
                //bindingNavigator1.BindingSource = bs;
                //dataGridView1.DataSource = bs;

                //gridControl1.DataSource = dt;
                //dataTable1BindingSource.DataSource = dt;
                //BindingSource bs = new BindingSource();
                //bs.DataSource = dt;

                //this.dataTable1TableAdapter.Fill(this.dsPedidos.DataTable1, int.Parse(objetodepesquisa));

                txtLimite.Text = Convert.ToDecimal(dt.Rows[0]["LIMCRED"].ToString()).ToString("R$ ##,##0.00");
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
                txtCODUSUR.Text = dt.Rows[0]["CODUSUR"].ToString();
                txtNumped.Text = dt.Rows[0]["NUMPED"].ToString();
                txtCodFilial.Text = dt.Rows[0]["CODFILIAL"].ToString();
                txtCodFilialNF.Text  = dt.Rows[0]["CODFILIALNF"].ToString();
                txtPosicao.Text = dt.Rows[0]["POSICAO"].ToString();

                txtNome.ReadOnly = true;
                txtLogradouro.ReadOnly = true;
                txtBairro.ReadOnly = true;
                txtCEP.ReadOnly = true;
                txtCidade.ReadOnly = true;
                txtEstado.ReadOnly = true;
                txtCNPJCPF.ReadOnly = true;
                txtIERG.ReadOnly = true;
                txtCODUSUR.ReadOnly = true;
                txtLimite.ReadOnly = true;

                txtNumped.ReadOnly = true;
                txtPosicao.ReadOnly = true;
                txtCodFilial.ReadOnly = true;
                txtCodFilialNF.ReadOnly = true;
                

                if(dt.Rows[0]["POSICAO"].ToString() == "P" || 
                    dt.Rows[0]["POSICAO"].ToString() == "B")
                {
                    txtCodFilialNF.BackColor = Color.Yellow;
                    btnCancelar.Visible = true;
                    btnConfirmar.Visible = true;
                    txtCodFilialNF.ReadOnly = false;
                } else
                {
                    txtCodFilialNF.BackColor = Color.LightYellow;
                    txtCodFilialNF.ForeColor = Color.Black;
                    btnCancelar.Visible = false;
                    btnConfirmar.Visible = false;
                    txtCodFilialNF.ReadOnly = true;
                }

                panel1.Enabled = true;
                tabControl1.SelectedTab = this.tabPage1;
                tabPage1.Focus();
                maskedTextBox1.Focus();
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtCodFilialNF.ReadOnly = true;
            maskedTextBox1.Text = string.Empty;
            txtCodFilialNF.BackColor = txtCodigo.BackColor;
            btnCancelar.Visible = false;
            btnConfirmar.Visible = false;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string message =
            "Este procedimento é perigoso. Confirma assim mesmo?";
            string caption = "Alterar filial de faturamento do Pedido";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            } else
            {
                EL_PCPEDC objPCPEDC = new EL_PCPEDC();
                BLL_PCPEDC cmdPCPEDC = new BLL_PCPEDC();
                objPCPEDC.codfilialnf = txtCodFilialNF.Text;
                cmdPCPEDC.Alterar(objPCPEDC, txtNumped.Text);

                EL_PCPEDI objPCPEDI = new EL_PCPEDI();
                BLL_PCPEDI cmdPCPEDI = new BLL_PCPEDI();
                objPCPEDI.codfilialretira = txtCodFilialNF.Text;
                cmdPCPEDI.Alterar(objPCPEDI, txtNumped.Text);

                caption = "Procedimento Completado";
                message = "Comando executado. \nFavor, verificar se tudo ocorreu bem.";
                result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Exclamation);
                Beep(500, 100);
                return;
            }
            

        }

        private void FormModificarSituacaoPedido_Load(object sender, EventArgs e)
        {

        }

      
    }
}
