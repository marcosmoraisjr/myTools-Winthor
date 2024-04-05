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
    public partial class FormMapaSeparacao : Form
    {
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        public static extern bool Beep(UInt32 frequency, UInt32 duration);
        public int linhaAtual = 0;
        public FormMapaSeparacao()
        {
            InitializeComponent();
            
            
            maskedTextBoxPesquisa.Focus();
            tabControl1.Visible = false;
        }

        private void InitializeDataGridView(DataTable dt)
        {
            try
            {

                // Configure o DataGridView.
                dataGridView1.Dock = DockStyle.Fill;

                // Gere automaticamente as colunas DataGridView.
                dataGridView1.AutoGenerateColumns = true;

                // Configure a fonte de dados.
                bindingSource1.DataSource = dt ;
                dataGridView1.DataSource = bindingSource1;
                bindingNavigator1.BindingSource = bindingSource1;

                // Redimensione automaticamente as linhas visíveis.
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;

                // Defina a borda do controle DataGridView.
                dataGridView1.BorderStyle = BorderStyle.Fixed3D;

                // Definir botoes do bindigNavigator
                bindingNavigatorAddNewItem.Visible = false;
                bindingNavigatorDeleteItem.Visible = false;
                

                // Coloque as células no modo de edição quando o usuário as inserir.
                //dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;

            }
            catch (Exception)
            {
                MessageBox.Show("To run this sample replace connection.ConnectionString" +
                    " with a valid connection string to a Northwind" +
                    " database accessible to your system.", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                System.Threading.Thread.CurrentThread.Abort();
            }
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            String objetodepesquisa = maskedTextBoxPesquisa.Text.Trim();
            if (objetodepesquisa == string.Empty)
            {
                MessageBox.Show("Obrigatório informar Carregamento.");
                return;
            }

            StringBuilder SQL = new StringBuilder();
            DataTable dt = new DataTable();
            BLL_Curinga cmd = new BLL_Curinga();


            if (radioButton1.Checked)
            {
                SQL.Append("SELECT numnotas, numviasmapa, numcar, dtsaida, vltotal,  dtfecha, datamon, datamapa, destino, codfuncmon FROM pccarreg WHERE 1=1 and numcar ='" + objetodepesquisa + "' and rownum < 10");
            }

            
            dt = cmd.FindByQuery(SQL.ToString());
            

            if (dt.Rows.Count < 1)
            {
                MessageBox.Show(string.Format("Nenhum registro encontrado para a pesquisa {0}", objetodepesquisa));
                maskedTextBoxPesquisa.Focus();
                
                tabControl1.Visible = false;
            }
            else
            {
                InitializeDataGridView(dt);
                tabControl1.Visible = true;
                tabControl1.SelectedTab = this.tabPage1;
                tabPage1.Focus();
                maskedTextBoxPesquisa.Focus();
            }
        }

        private void buttonZerar_Click(object sender, EventArgs e)
        {
            string message = "Este procedimento é perigoso. Confirma assim mesmo?";
            string caption = "Zerar número de impressões do mapa de separação";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }
            else
            {
  
                BLL_PCCARREG comando = new BLL_PCCARREG();
                EL_PCCARREG registro = new EL_PCCARREG();
                registro.numcar = Convert.ToInt32(maskedTextBoxPesquisa.Text);
                comando.Alterar(registro, maskedTextBoxPesquisa.Text);
                Beep(500, 100);

                caption = "Procedimento Completado";
                message = "Comando executado. \nFavor, verificar se tudo ocorreu bem.";
                result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            linhaAtual = dataGridView1.CurrentRow.Index;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void FormMapaSeparacao_Load(object sender, EventArgs e)
        {
            this.Text = "LISTA DE MAPA DE SEPARAÇÃO";
            maskedTextBoxPesquisa.SelectionStart = 0;
            maskedTextBoxPesquisa.Focus();
        }

       
        private void toolStripButtonZerarMapa_Click(object sender, EventArgs e)
        {
            string message = "Este procedimento é perigoso. Confirma assim mesmo?";
            string caption = "Zerar número de impressões do mapa de separação";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }
            else
            {
                BLL_PCCARREG comando = new BLL_PCCARREG();
                EL_PCCARREG registro = new EL_PCCARREG();
                registro.numcar = Convert.ToInt32(maskedTextBoxPesquisa.Text);
                comando.executarUpdate(registro);
                Beep(500, 100);

                caption = "Procedimento Completado";
                message = "Comando executado. \nFavor, verificar se tudo ocorreu bem.";
                result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                buttonBuscar_Click(sender, e);
                return;
            }

        }
    }
}
