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
    public partial class oborudovanie : Form
    {
        public oborudovanie()
        {
            InitializeComponent();
        }

        Form add_oborud = new Form3_add_oborudovanie(false);
        Form add_oborud_update = new Form3_add_oborudovanie(true);
        db_con pgsql_obj = new db_con();

        private void oborudovanie_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            add_oborud.Show();
        }
        
        private void oborudovanie_Load(object sender, EventArgs e)
        {

            get_oborudovanie((Object)null, new EventArgs());
            add_oborud.VisibleChanged += new EventHandler(get_oborudovanie);
            add_oborud_update.VisibleChanged += new EventHandler(add_oborud_update_VisibleChanged);



        }

        void get_oborudovanie(object sender, EventArgs e)
        {
            if (!add_oborud.Visible)
            {
                //получаем список оборудования
                ArrayList arr = new ArrayList();
                arr.Add(new NpgsqlParameter("customerid", Program.tp.cid.ToString()));

                NpgsqlDataAdapter pgs_adapter =
                    pgsql_obj.Query(
                        "select customer_id, name, type, date_of_production, last_to, next_to, eq_id from equipment where customer_id=:customerid;",
                        (Object) arr);
                DataSet data_set_oborudovanie = new DataSet();
                pgs_adapter.Fill(data_set_oborudovanie);

                data_set_oborudovanie.Tables[0].Columns[0].ColumnName = "Идентификатор владельца";
                data_set_oborudovanie.Tables[0].Columns[1].ColumnName = "Название";
                data_set_oborudovanie.Tables[0].Columns[2].ColumnName = "Тип";
                data_set_oborudovanie.Tables[0].Columns[3].ColumnName = "Дата производства";
                data_set_oborudovanie.Tables[0].Columns[4].ColumnName = "Дата последнего ТО";
                data_set_oborudovanie.Tables[0].Columns[5].ColumnName = "Дата следующего ТО";
                data_set_oborudovanie.Tables[0].Columns[6].ColumnName = "Идентификатор оборудования";
                dataGridView_oborudovanie.DataSource = data_set_oborudovanie.Tables[0];

                SetStatus("Выберите оборудование из списка");
                Program.tp.eqid = 0;
            }
        }

        private void oborudovanie_VisibleChanged(object sender, EventArgs e)
        {
            if(!this.Visible)
            {
                if(dataGridView_oborudovanie.Rows.Count>0)
                {
                    dataGridView_oborudovanie.DataSource = null;
                }
            }
            else
            {
                get_oborudovanie(null, new EventArgs());
            }
            toolStripButton3.Enabled = false;
        }

        private void dataGridView_oborudovanie_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                Program.tp.eqid = 0;
                return;
            }
            else
            {
                Program.tp.eqid = (Int32)dataGridView_oborudovanie[dataGridView_oborudovanie.ColumnCount-1, e.RowIndex].Value;
            }

            SetStatus("Выбрано оборудование: №" + Program.tp.eqid.ToString());
            toolStripButton3.Enabled = true;
        }

        private void SetStatus(string s)
        {
            toolStripStatusLabel1.Text = s;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            add_oborud_update.Show();
        }

        void add_oborud_update_VisibleChanged(object sender, EventArgs e)
        {
            this.Enabled = !add_oborud_update.Visible;
        }
    }
}
