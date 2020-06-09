using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCep.Contracts;
using Dapper;
using System.Configuration;
using System.Data.SqlClient;
using WpfCep.Entities;

namespace WpfCep.Repositories
{
    public class BaseRepository : ICepRepository
    {
        private string connectionString;
        public BaseRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["BancoCep"].ConnectionString;
        }
       
        public void Insert(Cep obj)
        {
            var query = "insert into Cep (NumCep, Logradouro, Complemento, Bairro, Localidade, Uf) " +
                "values (@NumCep, @Logradouro, @Complemento, @Bairro, @Localidade, @Uf)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }

        public List<Cep> SelectAll()
        {
            var query = "select * from Cep";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Cep>(query).ToList();
            }
        }

        
        public Cep SelectCep(string numCep)
        {
            var query = "select * from Cep where NumCep = @NumCep";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Cep>(query, new { NumCep = numCep }).SingleOrDefault();
            }
        }
    }
}
