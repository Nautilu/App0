using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App0.Models;
using System.Data.SqlClient;

namespace App0.DataAccess
{
    public class WorkerDataAccess : BaseDataAccess
    {
        public WorkerDataAccess(string connectionString)
        : base(connectionString)
        {
        }

        public List<Worker> GetWorkers()
        {
            List<Worker> result = new List<Worker>();
            string sql = @"SELECT С.id_сотрудника, С.ФИО, С.Телефон,
                           О.id_отдела, О.Отдел, Д.id_должности, Д.Должность 
                           FROM Сотрудник С 
                           LEFT JOIN Отдел О ON О.id_отдела=С.id_отдела
                           LEFT JOIN Должность Д ON Д.id_должности=С.id_должности";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Worker()
                            {
                                ID = (int)reader["id_сотрудника"],
                                FIO = reader["ФИО"].ToString(),
                                PhoneNumber = reader["Телефон"].ToString(),
                                Department = reader["id_отдела"] != DBNull.Value ?
                                new Department
                                {
                                    ID = (int)reader["id_отдела"],
                                    Name = reader["Отдел"].ToString()
                                } : null,
                                Job = reader["id_должности"] != DBNull.Value ?
                                new Job
                                {
                                    ID = (int)reader["id_должности"],
                                    Name = reader["Должность"].ToString()
                                } : null
                            });
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return result;
        }

        public List<Worker> GetWorkersForEWSearch()
        {
            List<Worker> result = new List<Worker>();
            string sql = @"SELECT DISTINCT С.id_сотрудника, С.ФИО
                           FROM Сотрудник С
                           JOIN Мероприятия_Сотрудники МС ON МС.id_сотрудника=С.id_сотрудника";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Worker()
                            {
                                ID = (int)reader["id_сотрудника"],
                                FIO = reader["ФИО"].ToString(),
                            });
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return result;
        }

        public void InsertWorker(Worker Worker)
        {
            string sql = @"INSERT INTO Сотрудник(id_сотрудника, ФИО, 
                           id_должности, id_отдела, Телефон)
                           VALUES(@id, @FIO, @Job_id, @Dep_id, @PhoneNumber)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@id", Worker.ID));
                    command.Parameters.Add(new SqlParameter("@FIO", Worker.FIO));
                    if (Worker.Job != null)
                        command.Parameters.Add(new SqlParameter("@Job_id", Worker.Job.ID));
                    else
                        command.Parameters.Add(new SqlParameter("@Job_id", DBNull.Value));
                    if (Worker.Department != null)
                        command.Parameters.Add(new SqlParameter("@Dep_id", Worker.Department.ID));
                    else
                        command.Parameters.Add(new SqlParameter("@Dep_id", DBNull.Value));
                    if(string.IsNullOrEmpty(Worker.PhoneNumber))
                        command.Parameters.Add(new SqlParameter("@PhoneNumber", DBNull.Value));
                    else
                        command.Parameters.Add(new SqlParameter("@PhoneNumber", Worker.PhoneNumber));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }


        public void UpdateWorker(Worker Worker)
        {
            string sql = @"UPDATE Сотрудник SET 
                           ФИО=@FIO, Телефон=@PhoneNumber,
                           id_отдела=@Dep_id, id_должности=@Job_id
                           WHERE id_сотрудника=@id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@FIO", Worker.FIO));
                    if (string.IsNullOrEmpty(Worker.PhoneNumber))
                        command.Parameters.Add(new SqlParameter("@PhoneNumber", DBNull.Value));
                    else
                        command.Parameters.Add(new SqlParameter("@PhoneNumber", Worker.PhoneNumber));
                    if (Worker.Job != null)
                        command.Parameters.Add(new SqlParameter("@Job_id", Worker.Job.ID));
                    else
                        command.Parameters.Add(new SqlParameter("@Job_id", DBNull.Value));
                    if (Worker.Department != null)
                        command.Parameters.Add(new SqlParameter("@Dep_id", Worker.Department.ID));
                    else
                        command.Parameters.Add(new SqlParameter("@Dep_id", DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@id", Worker.ID));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

        }

        public bool CheckID(int ID)
        {
            string sql = @"SELECT С.id_сотрудника
                           FROM Сотрудник С
                           WHERE С.id_сотрудника=@id";
            Worker worker = new Worker();
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

        public void UpdateWorker(Worker Worker, int oldID)
        {
            string sql = @"DELETE FROM Мероприятия_Сотрудники
                           WHERE id_сотрудника=@oldID
                           UPDATE Сотрудник SET ФИО=@Name, Телефон=@Phone, 
                           id_отдела=@Dep_id, id_должности=@Job_id, id_сотрудника=@id
                           WHERE id_сотрудника=@oldID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@id", Worker.ID));
                    command.Parameters.Add(new SqlParameter("@Phone", Worker.PhoneNumber));
                    command.Parameters.Add(new SqlParameter("@Name", Worker.FIO));
                    command.Parameters.Add(new SqlParameter("@Job_id", Worker.Job.ID));
                    command.Parameters.Add(new SqlParameter("@Dep_id", Worker.Department.ID));
                    command.Parameters.Add(new SqlParameter("@oldID", oldID));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

        }

        public void DeleteWorker(int id)
        {
            string sql = @"DELETE Мероприятия_Сотрудники WHERE id_сотрудника=
                           ANY(SELECT id_сотрудника FROM Сотрудник WHERE id_сотрудника=@id)
                           DELETE Сотрудник WHERE id_сотрудника=@id";
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

        public List<Worker> SearchWorker(Worker Worker)
        {
            List<Worker> result = new List<Worker>();
            string sql = @"SELECT С.id_сотрудника, С.ФИО, С.Телефон,
                           О.id_отдела, О.Отдел, Д.id_должности, Д.Должность 
                           FROM Сотрудник С 
                           JOIN Отдел О ON О.id_отдела=С.id_отдела
                           JOIN Должность Д ON Д.id_должности=С.id_должности
                           WHERE";
            bool one = true;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    if (Worker.ID != 0)
                    {
                        one = false;
                        command.CommandText = command.CommandText + " С.id_сотрудника=@id";
                        command.Parameters.Add(new SqlParameter("@id", Worker.ID)); 
                    }
                    if (String.IsNullOrEmpty(Worker.FIO) == false)
                    {
                        if (one == false)
                        {
                            command.CommandText = command.CommandText + " AND ";
                        }
                        else 
                        {
                            one = false;
                        }
                        command.CommandText = command.CommandText + " С.ФИО=@Name";
                        command.Parameters.Add(new SqlParameter("@Name", Worker.FIO)); 
                    }
                    if (Worker.Job != null)
                    {
                        if (one == false)
                        {
                            command.CommandText = command.CommandText + " AND ";
                        }
                        else
                        {
                            one = false;
                        }
                        command.CommandText = command.CommandText + " С.id_должности=@Job_id";
                        command.Parameters.Add(new SqlParameter("@Job_id", Worker.Job.ID));
                    }
                    if (Worker.Department != null)
                    {
                        if (one == false)
                        {
                            command.CommandText = command.CommandText + " AND ";
                        }
                        else
                        {
                            one = false;
                        }
                        command.CommandText = command.CommandText + " С.id_отдела=@Dep_id";
                        command.Parameters.Add(new SqlParameter("@Dep_id", Worker.Department.ID)); 
                    }
                    if (String.IsNullOrEmpty(Worker.PhoneNumber) == false)
                    {
                        if (one == false)
                        {
                            command.CommandText = command.CommandText + " AND ";
                        }
                        else
                        {
                            one = false;
                        }
                        command.CommandText = command.CommandText + " С.Телефон=@Phone";
                        command.Parameters.Add(new SqlParameter("@Phone", Worker.PhoneNumber));
                    }
                    command.ExecuteNonQuery();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Worker()
                            {
                                ID = (int)reader["id_сотрудника"],
                                FIO = reader["ФИО"].ToString(),
                                PhoneNumber = reader["Телефон"].ToString(),
                                Department = reader["id_отдела"] != DBNull.Value ?
                                new Department
                                {
                                    ID = (int)reader["id_отдела"],
                                    Name = reader["Отдел"].ToString()
                                } : null,
                                Job = reader["id_должности"] != DBNull.Value ?
                                new Job
                                {
                                    ID = (int)reader["id_должности"],
                                    Name = reader["Должность"].ToString()
                                } : null
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
