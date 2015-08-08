using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;


namespace Учет_газового_оборудования
{
    class abonent
    {
        private Int32 cid;
        private String Familiya;
        private String Imya;
        private String Otchestvo;
        private String Naselen_punkt;
        private String Ulica;
        private String nomer_doma;
        public List<oborud> oborud_list = new List<oborud>();

        public abonent(Int32 customerid, String fam, String imya, String otchestvo, String naselen_p, String ulica, String num_dom)
        {
            this.cid = customerid;
            this.Familiya = fam;
            this.Imya = imya;
            this.Otchestvo = otchestvo;
            this.Naselen_punkt = naselen_p;
            this.Ulica = ulica;
            this.nomer_doma = num_dom;
        }

        public  Int32 getCid()
        {
            return this.cid;
        }

        public String getFamiliya()
        {
            return this.Familiya;
        }

        public String getImya()
        {
            return this.Imya;
        }

        public String getOtchestvo()
        {
            return this.Otchestvo;
        }

        public String getNaselen_punkt()
        {
            return this.Naselen_punkt;
        }

        public String getUlica()
        {
            return this.Ulica;
        }

        public String getnomer_doma()
        {
            return this.nomer_doma;
        }

        ////////////////////////////////////////////

        public void addOborudovanie(oborud OneOborud)
        {
            oborud ob = OneOborud;
            this.oborud_list.Add(ob);
        }

        public struct oborud
        {
            public String name_oborud;
            public String type_oborud;
            public String date_of_production;
            public String last_to;
            public String next_to;
            public Int32 eq_id;
            public Int32 cid;

            public oborud(Int32 equpmetid, Int32 customerid, String nm_oborud, String tp_oborud, String dp_of_prod, String ls_to, String nx_to)
            {
                this.eq_id = equpmetid;
                this.cid = customerid;
                this.name_oborud = nm_oborud;
                this.type_oborud = tp_oborud;
                this.date_of_production = dp_of_prod;
                this.last_to = ls_to;
                this.next_to = nx_to;
            }

        }


        public string genHtml()
        {
            string abonent_html = string.Empty;

            abonent_html += "<td class=\"number\">" + this.cid + "</td>";
            abonent_html += "<td  colspan=\"2\" class=\"fio\">" +this.Familiya + " " + this.Imya + " " + this.Otchestvo +"</td>";
            abonent_html += "<td  colspan=\"2\" class=\"adres\" >" + this.Naselen_punkt + " " + this.Ulica + " " + this.nomer_doma + "</td>";


            foreach (oborud oborud_unit in oborud_list)
            {
                abonent_html += "<tr class=\"oborudovanie\">";
                abonent_html += "<td class=\"null\"></td>";
                abonent_html += "<td class=\"eqid\">" + oborud_unit.eq_id + "</td>";
                abonent_html += "<td class=\"eq_name\">" + oborud_unit.name_oborud + "</td>";
                abonent_html += "<td class=\"eq_type\">" + oborud_unit.type_oborud + "</td>";
                abonent_html += "<td class=\"eq_date\">дата производства: " + oborud_unit.date_of_production.Substring(0, 10) + "<br />";
                abonent_html += "последнее ТО: " + oborud_unit.last_to.Substring(0,10) + "<br />";
                abonent_html += "следующее ТО: " + oborud_unit.next_to.Substring(0, 10) + "</td>";
                abonent_html += "</tr>";
            }


            
            return abonent_html;
        }
    }


}
