using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App0.Models;
using System.Data.SqlClient;

namespace App0.DataAccess
{
    class StatusDataAccess : BaseDataAccess
    {
        public StatusDataAccess(string connectionString)
        : base(connectionString)
        {
        }

        public List<Status> GetStatuses()
        {
            List<Status> result = new List<Status>();
            string sql = @"SELECT id_статуса , Статус  
                           FROM Статус";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Status()
                            {
                                ID = (int)reader["id_статуса"],
                                Name = reader["Статус"].ToString()
                            });
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return result;
        }

        public void InsertStatus(Status Status)
        {
            string sql = @"INSERT INTO Статус(id_статуса, Статус) VALUES(@Status_id, @Status_Name)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Status_id", Status.ID));
                    command.Parameters.Add(new SqlParameter("@Status_Name", Status.Name));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }


        public void UpdateStatus(Status Status)
        {
            string sql = @"UPDATE Статус SET Статус=@Status_Name
                           WHERE id_статуса=@id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                { 
                    command.Parameters.Add(new SqlParameter("@Status_Name", Status.Name));
                    command.Parameters.Add(new SqlParameter("@id", Status.ID));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

        }

        public void UpdateStatus(Status Status, int oldID)
        {
            string sql = @"UPDATE Мероприятия SET id_статуса=NULL
                           WHERE id_статуса=@oldID
                           UPDATE Отдел SET Статус=@Status_Name, id_статуса=@id
                           WHERE id_статуса=@oldID
                           UPDATE Мероприятия SET id_статуса=@id
                           WHERE id_статуса=NULL";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@id", Status.ID));
                    command.Parameters.Add(new SqlParameter("@Status_Name", Status.Name));
                    command.Parameters.Add(new SqlParameter("@oldID", oldID));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

        }

        public bool CheckID(int ID)
        {
            string sql = @"SELECT id_статуса
                           FROM Статус
                           WHERE id_статуса=@id";
            bool result = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@id", ID));
                    command.ExecuteNonQuery();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                            result = true;
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return result;
        }

        public bool CheckName(string Name)
        {
            string sql = @"SELECT Статус
                           FROM Статус
                           WHERE Статус=@Name";
            Worker worker = new Worker();
            bool result = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Name", Name));
                    command.ExecuteNonQuery();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                            result = true;
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return result;
        }

        public void DeleteStatus(int id)
        {
            string sql = @"DELETE Мероприятия_Сотрудники WHERE id_мероприятия=
                           ANY( SELECT id_мероприятия FROM Мероприятие WHERE id_статуса=@id)
                           DELETE Мероприятие WHERE id_статуса=@id
                           DELETE Статус WHERE id_статуса=@id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@id", id));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

        }

        public List<Status> SearchStatus(Status Status)
        {
            List<Status> result = new List<Status>();
            string sql = @"SELECT id_статуса, Статус 
                           FROM Статус
                           WHERE";
            bool one = true;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    if (Status.ID != 0)
                    {
                        one = false;
                        command.CommandText = command.CommandText + " id_статуса=@id ";
                        command.Parameters.Add(new SqlParameter("@id", Status.ID));
                    }
                    if (String.IsNullOrEmpty(Status.Name) == false)
                    {
                        if (one == false)
                        {
                            command.CommandText = command.CommandText + " AND ";
                        }
                        command.CommandText = command.CommandText + " Статус=@name";
                        command.Parameters.Add(new SqlParameter("@name", Status.Name));
                    }
                    command.ExecuteNonQuery();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Status()
                            {
                                ID = (int)reader["id_статуса"],
                                Name = reader["Статус"].ToString()
                            });
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return result;
        }
    }
}
