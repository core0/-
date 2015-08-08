using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Учет_газового_оборудования
{
    public partial class find_form : Form
    {
        public find_form()
        {
            InitializeComponent();
        }

        String findq;
        

        private void button1_Click(object sender, EventArgs e)
        {
            findq = "select cid, imya, familiya, otchestvo, naselen_punkt, ulica, dom, primechanie from abonents where ";

            if (chF.Checked)
            {
                findq += " familiya='" + txtFamiliyaF.Text.Trim().ToUpper() + "'";

                if (chN.Checked || chO.Checked || chNasele.Checked || chUlica.Checked)
                {
                    findq += " and ";
                }
            }
            if(chN.Checked)
            {
                findq += " imya='" + txtNameF.Text.Trim().ToUpper() + "'";

                if (chO.Checked || chNasele.Checked || chUlica.Checked)
                {
                    findq += " and ";
                }
            }
            if(chO.Checked)
            {
                findq += " otchestvo='" + txtOtchestvoF.Text.Trim().ToUpper() + "'";

                if (chNasele.Checked || chUlica.Checked)
                {
                    findq += " and ";
                }
            }
            if (chNasele.Checked)
            {
                findq += " naselen_punkt='" + txtNaselenPunktF.Text.Trim().ToUpper() + "'";

                if (chUlica.Checked)
                {
                    findq += " and ";
                }
            }
            if (chUlica.Checked)
            {
                findq += " ulica='" + txtUlicaF.Text.Trim().ToUpper() + "'";
            }

            findq += ";";

            Program.tp.find_query = findq;

            this.Close();
        }

        private void find_form_Load(object sender, EventArgs e)
        {
            
        }

        private void find_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void txtFamiliyaF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\'' || e.KeyChar == '"')
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }

        }

    }
}
