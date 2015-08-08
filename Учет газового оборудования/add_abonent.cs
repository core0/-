using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Npgsql;
using System.Collections;

namespace Учет_газового_оборудования
{
    public partial class Form2_add_abonent : Form
    {
        public Form2_add_abonent(bool edit_abonent)
        {
            InitializeComponent();
            is_update_abonent = edit_abonent;
        }

        public bool is_update_abonent;
        db_con pgsql_c = new db_con();


        private void Form2_add_abonent_Load(object sender, EventArgs e)
        {
           
        }

        private void Form2_add_abonent_VisibleChanged(object sender, EventArgs e)
        {
            for (byte i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i] is TextBox )
                {
                    this.Controls[i].Text = "";
                }
            }

            if(is_update_abonent)
            {
                get_information_about_abonent();
            }
        }


        private void get_information_about_abonent()
        {
            ////////////////////////////////////////////////////s pgsql_c na cn
            db_con cn = new db_con();

            ArrayList arr = new ArrayList();
            arr.Add(new NpgsqlParameter("customer_id", Program.tp.cid.ToString()));
            NpgsqlDataAdapter da = cn.Query("select imya, familiya, otchestvo, naselen_punkt, ulica, dom, primechanie from abonents where cid=:customer_id;", (Object)arr);
            DataSet abonent_info_dataset = new DataSet();
            da.Fill(abonent_info_dataset);

            txtName.Text = abonent_info_dataset.Tables[0].Rows[0]["imya"].ToString().Trim();
            txtFamiliya.Text = abonent_info_dataset.Tables[0].Rows[0]["familiya"].ToString().Trim();
            txtOtchestvo.Text = abonent_info_dataset.Tables[0].Rows[0]["otchestvo"].ToString().Trim();
            txtNaselenPunkt.Text = abonent_info_dataset.Tables[0].Rows[0]["naselen_punkt"].ToString().Trim();
            txtUlica.Text = abonent_info_dataset.Tables[0].Rows[0]["ulica"].ToString().Trim();
            txtDom.Text = abonent_info_dataset.Tables[0].Rows[0]["dom"].ToString().Trim();
            txtPrimechanie.Text = abonent_info_dataset.Tables[0].Rows[0]["primechanie"].ToString().Trim();


        }

        private void Form2_add_abonent_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            db_con cn = new db_con();

            ArrayList arr = new ArrayList();
            arr.Add(new NpgsqlParameter("txtName", txtName.Text));
            arr.Add(new NpgsqlParameter("txtFamiliya", txtFamiliya.Text));
            arr.Add(new NpgsqlParameter("txtOtchestvo", txtOtchestvo.Text));
            arr.Add(new NpgsqlParameter("txtNaselenPunkt", txtNaselenPunkt.Text));
            arr.Add(new NpgsqlParameter("txtUlica", txtUlica.Text));
            arr.Add(new NpgsqlParameter("txtDom", txtDom.Text));
            arr.Add(new NpgsqlParameter("txtPrimechanie", txtPrimechanie.Text));
            arr.Add(new NpgsqlParameter("customer_id", Program.tp.cid.ToString()));

            if(is_update_abonent)
            {
                pgsql_c.Query("update abonents set imya=:txtName, familiya=:txtFamiliya, otchestvo=:txtOtchestvo, naselen_punkt=:txtNaselenPunkt, ulica=:txtUlica, dom=:txtDom, primechanie= :txtPrimechanie where cid=:customer_id;", (Object)arr);
            }
            else
            {
                pgsql_c.Query("Insert into abonents(imya, familiya, otchestvo, naselen_punkt, ulica, dom, primechanie) values (:txtName, :txtFamiliya, :txtOtchestvo, :txtNaselenPunkt, :txtUlica, :txtDom, :txtPrimechanie);", (Object) arr);
            }
            
            this.Close();    

        }
    }
}
