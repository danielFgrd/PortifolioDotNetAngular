using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data.Odbc;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Reflection;
using projeto_oficina.Models;
using System.Data;

namespace projeto_oficina.Persistence
{
    public abstract class PersistenceUtil
    {

        private MySqlConnection sqlConnection = null;

        private MySqlConnection GetConection()
        {
            
            try
            {
                this.sqlConnection = new MySqlConnection(ProjetoOficina.Properties.Resources.StrConexao);
                this.sqlConnection.Open();
            }
            catch(MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return this.sqlConnection;
        }

        private void CloseConnection()
        {
            this.sqlConnection.Close();
        }


        public  DataTable GetDataTable(string strCommand)
        {
            
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(strCommand, GetConection());

            DataTable dt = new DataTable();

            dataAdapter.Fill(dt);

            return dt;
        }

        public MySqlDataReader GetDataReader(string strCommand)
        {
            
            MySqlDataReader command= new MySqlCommand(strCommand, GetConection()).ExecuteReader();    

            return command;

        }


        public void ExecuteNonQuery(string strCommand)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(strCommand, GetConection());
                command.ExecuteNonQuery();
                command.Dispose();

            }
            catch (MySqlException e)
            {
                throw e;
            }
            finally
            {
                CloseConnection();
            }
        }
        
    }

    public class Persistence<T> : PersistenceUtil
    {
        private string NOME_TABELA= null;
        private Type TIPO_OBJETO= null;
        private PropertyInfo[] CAMPOS_OBJETO= null;

        public Persistence(T tipoPPersistencia)
        {
            this.NOME_TABELA = tipoPPersistencia.GetType().Name;
            this.TIPO_OBJETO = tipoPPersistencia.GetType();
            this.CAMPOS_OBJETO = TIPO_OBJETO.GetProperties();
        }

       

        public T findById(int id)
        {
            DataTable dataTable = GetDataTable("SELECT * FROM " + NOME_TABELA + " WHERE Id =" + id + ";");
            DataRow dataRow = dataTable.Rows[0];

            T obj = (T)Activator.CreateInstance(TIPO_OBJETO);

            for (int c = 0; c < dataTable.Columns.Count; c++)
            {
                string nomeCampo = CAMPOS_OBJETO[c].Name;
                object valorCampo = formataValor(dataRow[nomeCampo]);

                if (null != CAMPOS_OBJETO[c] && CAMPOS_OBJETO[c].CanWrite)
                {
                    CAMPOS_OBJETO[c].SetValue(obj, valorCampo, null);
                }
            }
            return obj;

        }
        public void delete(int id)
        {            
            try
            {
                ExecuteNonQuery("DELETE FROM " + NOME_TABELA + " WHERE Id= " + id + ";");
            }
            catch(MySqlException e)
            {
                throw e;
            }
        }

        public List<T> list()
        {      
            DataTable dataTable = GetDataTable("SELECT * FROM " + NOME_TABELA + ";");
            List<T> list = new List<T>();
            T obj = (T)Activator.CreateInstance(typeof(T));
            
            foreach(DataRow dataRow in dataTable.Rows)
            {

                for( int c = 0; c < dataTable.Columns.Count; c++)
                {
                    string nomeCampo = CAMPOS_OBJETO[c].Name;
                    object valorCampo = formataValor(dataRow[nomeCampo]);

                    if (null != CAMPOS_OBJETO[c] && CAMPOS_OBJETO[c].CanWrite)
                    {
                        CAMPOS_OBJETO[c].SetValue(obj, valorCampo, null);
                    }

                    string teste = obj.ToString();
                }

                list.Add(obj);
            }

            return list;
        }

        public void persit(T obj)
        {
            
            try
            {
                ExecuteNonQuery(geraQueryInsert(obj));
            }
            catch(MySqlException e)
            {
                throw e;
            }

        }

        public void update(T obj)
        {
            try
            {
                ExecuteNonQuery(geraQueryUpdate(obj));
            }
            catch(MySqlException e)
            {
                throw e;
            }

        }


        private string geraQueryUpdate(object obj)
        {
            //cria a query
            string queryGerada = null;

            queryGerada = "UPDATE " + NOME_TABELA + " SET ";

            int c = 0;
            int c1 = 0;

            while (c < CAMPOS_OBJETO.Length)
            {
                //nome do campo
                string nomeCampo = CAMPOS_OBJETO[c].Name;
                //valor do campo
                string valorCampo = valorCampoPorNome(nomeCampo, obj);

                c1 = c;
                queryGerada += nomeCampo;

                if ((Double.TryParse(valorCampo, out double num)) || (Int32.TryParse(valorCampo, out int num1)))
                {
                    if (++c1 < CAMPOS_OBJETO.Length)
                    {
                        queryGerada += "= " + valorCampo + ", ";
                    }
                    else
                    {
                        string queryGerada1 = queryGerada;
                        int caracPos = queryGerada1.Length;
                        queryGerada = queryGerada.Insert(caracPos, "= " + valorCampo + " WHERE Id= " + valorCampoPorNome("Id", obj) + ";");
                    }

                }
                else
                {
                    if (++c1 < CAMPOS_OBJETO.Length)
                    {
                        queryGerada += "= '" + valorCampo + "', ";
                    }
                    else
                    {
                        string queryGerada1 = queryGerada;
                        int caracPos = queryGerada1.Length;
                        queryGerada = queryGerada.Insert(caracPos, "= '" + valorCampo + "' WHERE Id= " + valorCampoPorNome("Id", obj) + ";");
                    }


                }

                c++;
            }

            return queryGerada;

        }

        private string geraQueryInsert(object obj)
        {   

            //cria a query
            string queryGerada = null;

            queryGerada = "INSERT INTO " + NOME_TABELA + "(";
            int c = 0;
            int c1 = 0;


            //indica os campos
            while (c < CAMPOS_OBJETO.Length)
            {
                int c2 = c;
                queryGerada += CAMPOS_OBJETO[c].Name;
                if ((++c2) < CAMPOS_OBJETO.Length)
                {
                    queryGerada += ", ";
                }
                else
                {
                    string queryGerada1 = queryGerada;
                    int caracPos = queryGerada1.Length;
                    queryGerada = queryGerada.Insert(caracPos, ") VALUES (");

                }

                c++;                
            }

            while (c1 < CAMPOS_OBJETO.Length)
            {

                int c2 = c1;

                //seleciona um campo para buscar o valor pelo o nome dinâminico
                PropertyInfo propertyInfo = obj.GetType().GetProperty(CAMPOS_OBJETO[c1].Name);
                string valorCampo = propertyInfo.GetValue(obj, null).ToString();


                if (Int32.TryParse(valorCampo.ToString(), out int integer))
                {
                    queryGerada += valorCampo;
                    if(++c2 < CAMPOS_OBJETO.Length)
                    {
                        queryGerada += ", ";
                    }
                    else
                    {
                        queryGerada += ");";
                    }

                }
                else if(Double.TryParse(valorCampo.ToString(), out double dob))
                {
                    queryGerada += valorCampo;
                    if (++c2 < CAMPOS_OBJETO.Length)
                    {
                        queryGerada += ", ";
                    }
                    else
                    {
                        queryGerada += ");";
                    }
                }
                else
                {
                    queryGerada += "'"+ valorCampo +"'";
                    if (++c2 < CAMPOS_OBJETO.Length)
                    {
                        queryGerada += ", ";
                    }
                    else
                    {
                        queryGerada += ");";
                    }
                }



                c1++;
            }

            

            return queryGerada;
                        
        }

        private object formataValor (object valor)
        {
            if (Int32.TryParse(valor.ToString(), out int num1))
            {
                return Int32.Parse(valor.ToString());
            }
            else if (Double.TryParse(valor.ToString(), out double num))
            {
                return Double.Parse(valor.ToString());
            }
            else
            {
                return valor.ToString();
            }        
            
        }
        
        private string valorCampoPorNome(string nomeCampo, object obj)
        {
            PropertyInfo propertyInfo = obj.GetType().GetProperty(nomeCampo);
            return propertyInfo.GetValue(obj, null).ToString();
        }

    }
}