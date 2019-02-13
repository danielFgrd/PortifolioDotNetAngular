using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using projeto_oficina.Models;

namespace projeto_oficina.Persistence
{
    public class VeiculoPersistence
    {

        public void Cadastrar(Usuario usuario)
        {
            Persistence<Usuario> persistence = new Persistence<Usuario>(new Usuario());

            persistence.persit(usuario);

        }

        public void AtualizarVeiculo(Usuario usuario)
        {
            Persistence<Usuario> persistence = new Persistence<Usuario>(new Usuario());
            Usuario usr = persistence.findById(usuario.Id);

            System.Reflection.PropertyInfo[] propertyInfo = usuario.GetType().GetProperties();

            for (int c = 0; c < propertyInfo.Length; c++)
            {
                if (propertyInfo[c].GetValue(propertyInfo[c].Name) != null) 
                {
                    usr.GetType().GetProperty(propertyInfo[c].Name).SetValue(usr, usuario.GetType().GetProperty(propertyInfo[c].Name).GetValue(usuario));
                }
            }

            persistence.update(usr);

        }


        public List<Veiculo> ListarPorProprietario(int idProprietario)
        {
            List<Veiculo> list = new List<Veiculo>();
            Veiculo veiculo = new Veiculo();

            Persistence<Veiculo> persistence = new Persistence<Veiculo>(new Veiculo());
            if (idProprietario != 0)
            {
                System.Data.DataTable dataTable = persistence.GetDataTable("SELECT * FROM OrdemServico WHERE IdProprietario = " + idProprietario + ";");

                foreach (System.Data.DataRow dataRow in dataTable.Rows)
                {
                    veiculo.Id = Int32.Parse(dataRow["id"].ToString());
                    veiculo.IdProprietario = Int32.Parse(dataRow["IdProprietario"].ToString());
                    veiculo.Tipo = dataRow["Tipo"].ToString();
                    veiculo.Marca = dataRow["Marca"].ToString();
                    veiculo.Modelo = dataRow["Modelo"].ToString();
                }

                list.Add(veiculo);
            }
            else
            {
                throw new ArgumentNullException();
            }

            return list;
        }


    }
}