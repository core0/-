using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Npgsql;

namespace Учет_газового_оборудования
{
    public partial class Form3_add_oborudovanie : Form
    {
        public Form3_add_oborudovanie(bool edit_oborud)
        {
            InitializeComponent();

            is_update_oborud = edit_oborud;
        }

        public bool is_update_oborud;
        db_con pgsql_c = new db_con();

        private void Form3_add_oborudovanie_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            db_con cn = new db_con();

            ArrayList arr = new ArrayList();
            arr.Add(new NpgsqlParameter("cid", Program.tp.cid));
            arr.Add(new NpgsqlParameter("txtNameEq", txtNameEq.Text.ToUpper()));
            arr.Add(new NpgsqlParameter("txtTypeEq", txtTypeEq.Text.ToUpper()));
            arr.Add(new NpgsqlParameter("dtpDateOfProduction", dtpDateOfProduction.Text.ToUpper()));
            arr.Add(new NpgsqlParameter("dtpDateOfLastTO", dtpDateOfLastTO.Text.ToUpper()));
            arr.Add(new NpgsqlParameter("dtpDateOfNextTO", dtpDateOfNextTO.Text.ToUpper()));

            if (is_update_oborud)
            {
                arr.Add(new NpgsqlParameter("equip_id", Program.tp.eqid));
                pgsql_c.Query("update equipment set customer_id=:cid, name=:txtNameEq, type=:txtTypeEq, date_of_production=:dtpDateOfProduction, last_to=:dtpDateOfLastTO, next_to=:dtpDateOfNextTO where eq_id=:equip_id;", (Object)arr);
            }
            else
            {
                pgsql_c.Query("Insert into equipment(customer_id, name, type, date_of_production, last_to, next_to) values (:cid, :txtNameEq, :txtTypeEq, :dtpDateOfProduction, :dtpDateOfLastTO, :dtpDateOfNextTO);", (Object)arr);
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_add_oborudovanie_VisibleChanged(object sender, EventArgs e)
        {
            for (byte i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i] is TextBox)
                {
                    this.Controls[i].Text = "";
                }
                if (this.Controls[i] is DateTimePicker)
                {
                    this.Controls[i].Text = DateTime.Now.ToString();
                }
            }

            if (is_update_oborud)
            {
                get_information_about_equipment();
            }
        }

        private void get_information_about_equipment()
        {
            db_con cn = new db_con();

            ArrayList arr = new ArrayList();
            arr.Add(new NpgsqlParameter("equipment_id", Program.tp.eqid.ToString()));
            NpgsqlDataAdapter da = pgsql_c.Query("select name, type, date_of_production, last_to, next_to  from equipment where eq_id=:equipment_id;", (Object)arr);
            DataSet oborud_info_dataset = new DataSet();
            da.Fill(oborud_info_dataset);

            txtNameEq.Text = oborud_info_dataset.Tables[0].Rows[0]["name"].ToString().Trim().ToUpper();
            txtTypeEq.Text = oborud_info_dataset.Tables[0].Rows[0]["type"].ToString().Trim().ToUpper();
            dtpDateOfProduction.Text = oborud_info_dataset.Tables[0].Rows[0]["date_of_production"].ToString().Trim().ToUpper();
            dtpDateOfLastTO.Text = oborud_info_dataset.Tables[0].Rows[0]["last_to"].ToString().Trim().ToUpper();
            dtpDateOfNextTO.Text = oborud_info_dataset.Tables[0].Rows[0]["next_to"].ToString().Trim().ToUpper();
        }

        private void dtpDateOfLastTO_CloseUp(object sender, EventArgs e)
        {
            DateTime dt = new DateTime();
            dt = DateTime.Parse(dtpDateOfLastTO.Text);
            dt = dt.AddYears(1);
            dtpDateOfNextTO.Text = dt.ToString();
        }



        
    }
}
