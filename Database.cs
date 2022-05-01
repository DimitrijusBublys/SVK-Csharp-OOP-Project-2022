using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
namespace projektasSlaptazodziai
{
    internal class Database
    {
        public static int CheckEmptyTable(string connectionString)
        {
            string sqlQuery = "SELECT COUNT (*) FROM masterpw";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(sqlQuery, connection);
            int result = int.Parse(cmd.ExecuteScalar().ToString());
            connection.Close();

            return result; // Jeigu 0, tai duomenu bazes lentele su master slaptazodziu tuscia
        }

        public static bool CheckCorrectPassword(string connectionString, string password)
        {
            bool result;
            string sqlQuery = "SELECT master_password FROM masterpw";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(sqlQuery, connection);
            string passwordCheck = cmd.ExecuteScalar().ToString();
            if (password == passwordCheck)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public static void GenerateMasterPassword(string connectionString, string password)
        {
            // Datos ir laiko kintamuju gavimas
            string date = DateTime.Today.ToShortDateString();
            string time = DateTime.Now.ToString("h:mm:ss");

            // Ivedimas i duomenu baze
            string sqlQuery = "INSERT INTO masterpw (master_password, date_created, time_created) " +
                    "VALUES (@master_password, @date_created, @time_created)";
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            SqlCommand cmd = new SqlCommand(sqlQuery, connection);
            cmd.Parameters.AddWithValue("@master_password", password);
            cmd.Parameters.AddWithValue("@date_created", date);
            cmd.Parameters.AddWithValue("@time_created", time);
            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public static void AddDataToDB(string connectionString, string namePw, string genPw)
        {
            // Datos ir laiko kintamuju gavimas
            string date = DateTime.Today.ToShortDateString();
            string time = DateTime.Now.ToString("h:mm:ss");

            // Ivedimas i duomenu baze
            string sqlQuery = "INSERT INTO generated_password (pw_name, generated_pw, date_created, time_created) " +
                    "VALUES (@pw_name, @generated_pw, @date_created, @time_created)";
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            SqlCommand cmd = new SqlCommand(sqlQuery, connection);
            cmd.Parameters.AddWithValue("@pw_name", namePw);
            cmd.Parameters.AddWithValue("@generated_pw", genPw);
            cmd.Parameters.AddWithValue("@date_created", date);
            cmd.Parameters.AddWithValue("@time_created", time);
            cmd.ExecuteNonQuery();

            connection.Close();
        }
    }
}
