using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App0.Models;
using System.Data.SqlClient;

namespace App0.DataAccess
{
    class JobDataAccess : BaseDataAccess
    {
        public JobDataAccess(string connectionString)
        : base(connectionString)
        {
        }

        public List<Job> GetJobs()
        {
            List<Job> result = new List<Job>();
            string sql = @"Select id_должности, Должность
                           From Должность
                          ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Job()
                            {
                                ID = (int)reader["id_должности"],
                                Name = reader["Должность"].ToString()
                            });
                        }
                        reader.Close();
                    }

                }
                connection.Close();
            }

            return result;
        }

        public void InsertJob(Job Job)
        {
            string sql = @"INSERT INTO Должность(id_должности, Должность) VALUES(@Job_id, @Job_Name)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Job_id", Job.ID));
                    command.Parameters.Add(new SqlParameter("@Job_Name", Job.Name));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }


        public void UpdateJob(Job Job)
        {
            string sql = @"UPDATE Должность SET Должность=@Job_Name
                           WHERE id_должности=@id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {

                    command.Parameters.Add(new SqlParameter("@Job_Name", Job.Name));
                    command.Parameters.Add(new SqlParameter("@id", Job.ID));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

        }


        public void UpdateJob(Job Job, int oldID)
        {
            string sql = @"UPDATE Сотрудник SET id_должности=NULL
                           WHERE id_должности=@oldID
                           UPDATE Должность SET Должность=@Job_Name, id_должности=@id
                           WHERE id_должности=@oldID
                           UPDATE Сотрудник SET id_должности=@id
                           WHERE id_должности=NULL";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@id", Job.ID));
                    command.Parameters.Add(new SqlParameter("@Job_Name", Job.Name));
                    command.Parameters.Add(new SqlParameter("@oldID", oldID));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

        }

        public bool CheckID(int ID)
        {
            string sql = @"SELECT id_должности
                           FROM Должность
                           WHERE id_должности=@id";
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
            string sql = @"SELECT Должность
                           FROM Должность
                           WHERE Должность=@Name";
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
        public void DeleteJob(int id)
        {
            string sql = @"DELETE Мероприятия_Сотрудники WHERE id_сотрудника=
                           ANY(SELECT id_сотрудника FROM Сотрудник WHERE id_должности=@id)
                           DELETE Сотрудник WHERE id_должности=@id
                           DELETE Должность WHERE id_должности=@id";
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

        public List<Job> SearchJob(Job Job)
        {
            List<Job> result = new List<Job>();
            string sql = @"SELECT id_должности, Должность 
                           FROM Должность
                           WHERE";
            bool one = true;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    if (Job.ID != -1)
                    {
                        one = false;
                        command.CommandText = command.CommandText + " id_должности=@id ";
                        command.Parameters.Add(new SqlParameter("@id", Job.ID));
                    }
                    if (String.IsNullOrEmpty(Job.Name) == false)
                    {
                        if (one == false)
                        {
                            command.CommandText = command.CommandText + " AND ";
                        }
                        command.CommandText = command.CommandText + " Должность=@name";
                        command.Parameters.Add(new SqlParameter("@name", Job.Name));
                    }
                    command.ExecuteNonQuery();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Job()
                            {
                                ID = (int)reader["id_должности"],
                                Name = reader["Должность"].ToString()
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
