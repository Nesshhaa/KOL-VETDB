using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class VetRepository
    {
        public List<Vet> GetAllVets()
        {
            List<Vet> vets = new List<Vet>();
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Vets";
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Vet s = new Vet();
                    s.Id = sqlDataReader.GetInt32(0);
                    s.FullName = sqlDataReader.GetString(1);
                    s.Specialty = sqlDataReader.GetString(2);
                    s.YearsExperience = sqlDataReader.GetInt32(3);
                    vets.Add(s);
                }
                return vets;
            }
        }

        public int InsertVet(Vet s)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = String.Format("INSERT INTO Vets VALUES('{0}','{1}',{2})", s.FullName, s.Specialty, s.YearsExperience);

                return sqlCommand.ExecuteNonQuery();


            }
        }
    }
}
