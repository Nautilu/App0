using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App0.Models;
using System.Data.SqlClient;

namespace App0.DataAccess
{
    class FormDataAccess : BaseDataAccess
    {
        public FormDataAccess(string connectionString)
        : base(connectionString)
        {
        }

        public List<EForm> GetForms()
        {
            List<EForm> result = new List<EForm>();
            string sql = @"SELECT id_вида , Вид  
                           FROM Вид";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new EForm()
                            {
                                ID = (int)reader["id_вида"],
                                Name = reader["Вид"].ToString()
                            });
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return result;
        }

        public void InsertForm(EForm Form)
        {
            string sql = @"INSERT INTO Вид(id_вида, Вид) 
                           VALUES (@Form_id, @Form_Name)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Form_id", Form.ID));
                    command.Parameters.Add(new SqlParameter("@Form_Name", Form.Name));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }


        public void UpdateForm(EForm Form)
        {
            string sql = @"UPDATE Вид SET Вид=@Form_Name
                           WHERE id_вида=@id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Form_Name", Form.Name));
                    command.Parameters.Add(new SqlParameter("@id",Form.ID));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

        }

        public void UpdateForm(EForm Form, int oldID)
        {
            string sql = @"UPDATE Мероприятие SET id_мероприятия=NULL
                           WHERE id_вида=@oldID
                           UPDATE Отдел SET Вид=@Form_Name, id_вида=@id
                           WHERE id_вида=@oldID
                           UPDATE Мероприятие SET id_мероприятия=@id
                           WHERE id_вида=NULL ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@id", Form.ID));
                    command.Parameters.Add(new SqlParameter("@Department_Name", Form.Name));
                    command.Parameters.Add(new SqlParameter("@oldID", oldID));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

        }

        public bool CheckID(int ID)
        {
            string sql = @"SELECT id_вида
                           FROM Вид
                           WHERE id_вида=@id";
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
            string sql = @"SELECT Вид
                           FROM Вид
                           WHERE Вид=@Name";
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

        public void DeleteForm(int id)
        {
            string sql = @"DELETE Мероприятия_Сотрудники WHERE id_мероприятия=
                           ANY( SELECT id_мероприятия FROM Мероприятие WHERE id_вида=@id)
                           DELETE Мероприятия_Участники WHERE id_мероприятия=
                           ANY( SELECT id_мероприятия FROM Мероприятие WHERE id_вида=@id)
                           DELETE Мероприятие WHERE id_вида=@id
                           DELETE Вид WHERE id_вида=@id";
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
        public List<EForm> SearchForm(EForm Form)
        {
            List<EForm> result = new List<EForm>();
            string sql = @"SELECT id_вида, Вид 
                           FROM Вид
                           WHERE";
            bool one = true;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    if (Form.ID != 0)
                    {
                        one = false;
                        command.CommandText = command.CommandText + " id_вида=@id ";
                        command.Parameters.Add(new SqlParameter("@id", Form.ID));
                    }
                    if (String.IsNullOrEmpty(Form.Name) == false)
                    {
                        if (one == false)
                        {
                            command.CommandText = command.CommandText + " AND ";
                        }
                        command.CommandText = command.CommandText + " Вид=@name";
                        command.Parameters.Add(new SqlParameter("@name", Form.Name));
                    }
                    command.ExecuteNonQuery();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new EForm()
                            {
                                ID = (int)reader["id_вида"],
                                Name = reader["Вид"].ToString()
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
