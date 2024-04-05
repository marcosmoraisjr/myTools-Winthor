using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormPrincipal : Form
    {
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        public static extern bool Beep(UInt32 frequency, UInt32 duration);
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode nNome = e.Node;
            if (nNome.Name == "0001")
            {
                FormModificarSituacaoPedido frm = new FormModificarSituacaoPedido();
                frm.ShowDialog();
            }
            if (nNome.Name == "0002")
            {
                FormMapaSeparacao frm = new FormMapaSeparacao();
                frm.ShowDialog();
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Finalizar a aplicação ?", "Finalizar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void desenvolvedor_Click(object sender, EventArgs e)
        {

        }

        private void VisitLink()
        {
            // Change the color of the link text by setting LinkVisited
            // to true.
            linkLabel_Autor.LinkVisited = true;
            //Call the Process.Start method to open the default browser
            //with a URL:
            System.Diagnostics.Process.Start("https://www.linkedin.com/in/marcosmoraisjr/");
        }

        private void linkLabel_Autor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                VisitLink();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link that was clicked.\n"+ex.ToString());
            }
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }
    }
}
