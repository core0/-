using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using System.Collections;

namespace Учет_газового_оборудования
{
    public class db_con
    {
        public NpgsqlConnection pgsql_conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User=user;Password=1;Database=gaz_uchet;Timeout=3;");

        public void Open()
        {
            pgsql_conn.Open();
        }

        public void Close()
        {
            pgsql_conn.Close();
        }

        public NpgsqlDataAdapter Query(string query, Object parameters)
        {
            this.Open();
            NpgsqlDataAdapter da;
            ArrayList arr = (ArrayList)parameters;
            query = query.ToUpper();

            if (parameters != null)
            {
                da = new NpgsqlDataAdapter();
                if (query.StartsWith("SELECT"))
                {
                    da.SelectCommand = new NpgsqlCommand(query, pgsql_conn);
                    for (int i = 0; i < arr.Count; i++)
                    {
                        da.SelectCommand.Parameters.Add((NpgsqlParameter) arr[i]);

                    }
                    da.SelectCommand.ExecuteReader();
                }
                else
                {
                    da.InsertCommand = new NpgsqlCommand(query, pgsql_conn);
                    for (int i = 0; i < arr.Count; i++)
                    {
                        da.InsertCommand.Parameters.Add((NpgsqlParameter)arr[i]);
                    }
                    da.InsertCommand.ExecuteNonQuery();
                }
               

            }
            else
            {
                da = new NpgsqlDataAdapter(query, pgsql_conn);
            }

            this.Close();
            return da;

        }



    }
}
