using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Npgsql;
using System.Collections;
using System.IO;
using System.Diagnostics;


namespace Учет_газового_оборудования
{
    public partial class Form1_main : Form
    {
        public Form1_main()
        {
            InitializeComponent();
        }

        public void SetStatus(string status)
        {
            toolStripStatus.Text = status;
        }

        Form add_new_abonent = new Form2_add_abonent(false);
        Form add_new_oborudovanie = new Form3_add_oborudovanie(false);
        Form find_f = new find_form();
        Form oborud = new oborudovanie();

        db_con pgsql_obj = new db_con();

        List<abonent> abonents = new List<abonent>(); 
        


        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripButton2.Enabled = false;

            Program.tp.cid = 0;
            if(dataGridViewAbonenti.Rows.Count > 0)
            {
                Program.tp.cid = (Int32)dataGridViewAbonenti.SelectedRows[0].Cells["Идентификатор"].Value;
            }
            SetStatus("Подключение к базе данных...");

            get_abonents();

 
            SetStatus("База данных загружена");


            add_new_abonent.VisibleChanged += new EventHandler(Add_new_abonent_Refresh);
            oborud.VisibleChanged += new EventHandler(lockme);
            find_f.VisibleChanged += new EventHandler(find_f_VisibleChanged);

        }

        private void find_f_VisibleChanged(object sender, EventArgs e)
        {
            if(!find_f.Visible)
            {
                find();
            }
        }

        void lockme(object sender, EventArgs e)
        {
            this.Enabled = !oborud.Visible;
        }

        void get_abonents()
        {
            //получаем абонентов
            NpgsqlDataAdapter pgs_adapter = pgsql_obj.Query("select cid, imya, familiya, otchestvo, naselen_punkt, ulica, dom, primechanie from abonents;", null);
            DataSet data_set_abonents = new DataSet();
            pgs_adapter.Fill(data_set_abonents);

            data_set_abonents.Tables[0].Columns[0].ColumnName = "Идентификатор";
            data_set_abonents.Tables[0].Columns[1].ColumnName = "Имя";
            data_set_abonents.Tables[0].Columns[2].ColumnName = "Фамилия";
            data_set_abonents.Tables[0].Columns[3].ColumnName = "Отчество";
            data_set_abonents.Tables[0].Columns[4].ColumnName = "Населенный пункт";
            data_set_abonents.Tables[0].Columns[5].ColumnName = "Улица";
            data_set_abonents.Tables[0].Columns[6].ColumnName = "Дом";
            data_set_abonents.Tables[0].Columns[7].ColumnName = "Примечание";
            dataGridViewAbonenti.DataSource = data_set_abonents.Tables[0];

        }


        //Удобное появление окна добавления нового абонента
        void Add_new_abonent()
        {
            if (add_new_abonent != null)
            {
                add_new_abonent.Show();
                add_new_abonent.Focus();
            }
        }

        //обновляем список абонентов на главной форме, при закрытии окна добавления абонента
        private void Add_new_abonent_Refresh(object sender, EventArgs e)
        {
            if(!add_new_abonent.Visible)
            {
                get_abonents(); 
            }
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Add_new_abonent();
        }

        private void dataGridViewAbonenti_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0  || e.RowIndex < 0)
            {
                Program.tp.cid = 0;
            }
            else
            {
                Program.tp.cid = (Int32)dataGridViewAbonenti[0, e.RowIndex].Value;
            }

            SetStatus("Выбран абонент: №"+Program.tp.cid.ToString());
            toolStripButton2.Enabled = true;

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Add_new_oborudovanie();
        }


        void Add_new_oborudovanie()
        {
            if (add_new_oborudovanie != null)
            {
                add_new_oborudovanie.Show();
                add_new_oborudovanie.Focus();
            }

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            get_abonents();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (find_f != null)
            {
                find_f.Show();
                find_f.Focus();
            }
        }

        public void find()
        {
            if (Program.tp.find_query != null)
            {
                //find query
                NpgsqlDataAdapter pgs_adapter = pgsql_obj.Query(Program.tp.find_query, null);
                DataSet data_set_abonents = new DataSet();
                pgs_adapter.Fill(data_set_abonents);

                dataGridViewAbonenti.DataSource = data_set_abonents.Tables[0];

            }
        }

        private void dataGridViewAbonenti_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 && e.ColumnIndex < 0)
            {
                Program.tp.cid = 0;
            }
            else
            {
                Program.tp.cid = (Int32)dataGridViewAbonenti[0, e.RowIndex].Value;
            }

            oborud.Show();

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Form add_new_abonent_update = new Form2_add_abonent(true);
            add_new_abonent_update.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить из базы данных абонента " + dataGridViewAbonenti.SelectedRows[0].Cells["Фамилия"].Value.ToString().Trim() + " " + dataGridViewAbonenti.SelectedRows[0].Cells["Имя"].Value.ToString().Trim() + " с номером " + dataGridViewAbonenti.SelectedRows[0].Cells["Идентификатор"].Value.ToString().Trim()
            ,"Удаление абонента", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ArrayList arr = new ArrayList();
                arr.Add(new NpgsqlParameter("customer_id", Program.tp.cid.ToString()));

                pgsql_obj.Query("delete from abonents where cid=:customer_id;", (Object)arr);
                pgsql_obj.Query("delete from equipment where customer_id=:customer_id;", (Object)arr);

                get_abonents();
            }

            
        }


        private void InformationAbouteAbonents_Click(object sender, EventArgs e)
        {
            //очищаем список абонентов
            abonents.Clear();

            List<int> ids = new List<int>();
            ids.InsertRange(0,getIdFromDataGrid());


            for(int i =0; i<ids.Count; i++)
            {
                ArrayList arr_param = new ArrayList();
                arr_param.Add(new NpgsqlParameter("customer_id", ids[i].ToString()));
                //информация об абоненте
                NpgsqlDataAdapter da = pgsql_obj.Query("select imya, familiya, otchestvo, naselen_punkt, ulica, dom, primechanie from abonents where cid=:customer_id;", (Object)arr_param);
                DataSet abonent_info_dataset = new DataSet();
                da.Fill(abonent_info_dataset);

                //заполняем структуру абонент, вместе с привязанным к нему оборудованием
                abonent ab = new abonent(ids[i],
                                         abonent_info_dataset.Tables[0].Rows[0]["familiya"].ToString().Trim(),
                                         abonent_info_dataset.Tables[0].Rows[0]["imya"].ToString().Trim(),
                                         abonent_info_dataset.Tables[0].Rows[0]["otchestvo"].ToString().Trim(),
                                         abonent_info_dataset.Tables[0].Rows[0]["naselen_punkt"].ToString().Trim(),
                                         abonent_info_dataset.Tables[0].Rows[0]["ulica"].ToString().Trim(),
                                         abonent_info_dataset.Tables[0].Rows[0]["dom"].ToString().Trim());

                //получаем все оборудования, числящиеся за абонентом
                NpgsqlDataAdapter pgs_adapter =
                    pgsql_obj.Query(
                        "select name, type, date_of_production, last_to, next_to, eq_id from equipment where customer_id=:customer_id;",
                        (Object)arr_param);

                DataSet data_set_oborudovanie = new DataSet();
                pgs_adapter.Fill(data_set_oborudovanie);

                if(data_set_oborudovanie.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in data_set_oborudovanie.Tables[0].Rows)
                    {
                        ab.addOborudovanie(new abonent.oborud((int)dr["eq_id"], ids[i], dr["name"].ToString().ToUpper().Trim(),
                            dr["type"].ToString().ToUpper().Trim(),
                            dr["date_of_production"].ToString().ToUpper().Trim(),
                            dr["last_to"].ToString().ToUpper().Trim(),
                            dr["next_to"].ToString().ToUpper().Trim()));
                    }
                }

                abonents.Add(ab);
            }

            get_otchet_information(abonents);
        }

        private void get_otchet_information(List<abonent> abonents_for_prints)
        {
            String generation_html = String.Empty;

            foreach (var abonent in abonents_for_prints)
            {
                generation_html += "<tr class=\"unit\">" + abonent.genHtml() + "</tr>";
            }

            if(abonents_for_prints.Count > 0)
            {
                String s = "<!doctype html><html><head><meta http-equiv=\"content-type\" content=\"text/html; charset=utf-8\" /><link rel=\"stylesheet\" type=\"text/css\" href=\"style.css\"/><title>Информация об абонентах</title></head><body><table>" + generation_html + "</table></body></html>";
                File.WriteAllText("report.html", s);
                Process.Start(Directory.GetCurrentDirectory() + "\\report.html");
            }


        }


        private int[] getIdFromDataGrid()
        {
            int[] arr = new int[this.dataGridViewAbonenti.Rows.Count];

            if(arr.Length > 0)
            {
                for(int i =0; i< arr.Length; i++)
                {
                    arr[i] = (int)dataGridViewAbonenti.Rows[i].Cells[0].Value;
                }

            }
            return arr;
        }

        private void FindFireDateTo_Click(object sender, EventArgs e)
        {
            //очищаем список абонентов
            abonents.Clear();

            //получаем абонентов, которые должны пройти ТО в течении 2(задается) месяцев
            NpgsqlDataAdapter da = pgsql_obj.Query("select cid, imya, familiya, otchestvo, naselen_punkt, ulica, dom, primechanie from abonents where cid in (Select customer_id from equipment where next_to < CURRENT_DATE+61)", (object)null);
            DataSet abonent_must_have_to = new DataSet();
            da.Fill(abonent_must_have_to);
            dataGridViewAbonenti.DataSource = abonent_must_have_to.Tables[0];

            List<int> ids = new List<int>();
            ids.InsertRange(0, getIdFromDataGrid());

            

            for (int i = 0; i < ids.Count; i++)
            {
                ArrayList arr_param = new ArrayList();
                arr_param.Add(new NpgsqlParameter("customer_id", ids[i].ToString()));
                //информация об абоненте
                da = pgsql_obj.Query("select imya, familiya, otchestvo, naselen_punkt, ulica, dom, primechanie from abonents where cid=:customer_id;", (Object)arr_param);
                DataSet abonent_info_dataset = new DataSet();
                da.Fill(abonent_info_dataset);

                //заполняем структуру абонент, вместе с привязанным к нему оборудованием
                abonent ab = new abonent(ids[i],
                                         abonent_info_dataset.Tables[0].Rows[0]["familiya"].ToString().Trim(),
                                         abonent_info_dataset.Tables[0].Rows[0]["imya"].ToString().Trim(),
                                         abonent_info_dataset.Tables[0].Rows[0]["otchestvo"].ToString().Trim(),
                                         abonent_info_dataset.Tables[0].Rows[0]["naselen_punkt"].ToString().Trim(),
                                         abonent_info_dataset.Tables[0].Rows[0]["ulica"].ToString().Trim(),
                                         abonent_info_dataset.Tables[0].Rows[0]["dom"].ToString().Trim());

                //получаем все оборудования, числящиеся за абонентом
                NpgsqlDataAdapter pgs_adapter =
                    pgsql_obj.Query(
                        "select name, type, date_of_production, last_to, next_to, eq_id from equipment where customer_id=:customer_id;",
                        (Object)arr_param);

                DataSet data_set_oborudovanie = new DataSet();
                pgs_adapter.Fill(data_set_oborudovanie);

                if (data_set_oborudovanie.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in data_set_oborudovanie.Tables[0].Rows)
                    {
                        ab.addOborudovanie(new abonent.oborud((int)dr["eq_id"], ids[i], dr["name"].ToString().ToUpper().Trim(),
                            dr["type"].ToString().ToUpper().Trim(),
                            dr["date_of_production"].ToString().ToUpper().Trim(),
                            dr["last_to"].ToString().ToUpper().Trim(),
                            dr["next_to"].ToString().ToUpper().Trim()));
                    }
                }

                abonents.Add(ab);
            }

            get_otchet_information(abonents);
        }

        //навигация по датагриду с помощью кнопок

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if(dataGridViewAbonenti.Rows.Count > 0)
            {
                dataGridViewAbonenti.Rows[0].Selected = true;
            }
            
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            for(int i=0;i<dataGridViewAbonenti.Rows.Count;i++)
            {
                if(dataGridViewAbonenti.Rows[i].Selected == true && i > 0)
                {
                    dataGridViewAbonenti.Rows[i - 1].Selected = true;
                    return;
                }
            }
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewAbonenti.Rows.Count; i++)
            {
                if (dataGridViewAbonenti.Rows[i].Selected == true && i < dataGridViewAbonenti.Rows.Count-1)
                {
                    dataGridViewAbonenti.Rows[i + 1].Selected = true;
                    return;
                }
            }
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            if (dataGridViewAbonenti.Rows.Count > 0)
            {
                dataGridViewAbonenti.Rows[dataGridViewAbonenti.Rows.Count-1].Selected = true;
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


    }
}
