using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App0.Models;
using System.Data.SqlClient;

namespace App0.DataAccess
{
    class DepartmentDataAccess : BaseDataAccess
    {
        public DepartmentDataAccess(string connectionString)
        : base(connectionString)
        {
        }

        public List<Department> GetDeps()
        {
            List<Department> result = new List<Department>();
            string sql = @"SELECT id_отдела, Отдел 
                           FROM Отдел";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Department()
                            {
                                ID = (int)reader["id_отдела"],
                                Name = reader["Отдел"].ToString()
                            });
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return result;
        }

        public void InsertDepartment(Department Department)
        {
            string sql = @"INSERT INTO Отдел(id_отдела, Отдел)
                           VALUES(@Department_id, @Department_Name)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Department_id", Department.ID));
                    command.Parameters.Add(new SqlParameter("@Department_Name", Department.Name));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }


        public void UpdateDepartment(Department Department)
        {
            string sql = @"UPDATE Отдел SET Отдел=@Department_Name
                           WHERE id_отдела=@id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@id", Department.ID));
                    command.Parameters.Add(new SqlParameter("@Department_Name", Department.Name));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

        }

        public void UpdateDepartment(Department Department, int oldID)
        {
            string sql = @"UPDATE Сотрудник SET id_отдела=NULL
                           WHERE id_отдела=@oldID
                           UPDATE Отдел SET Отдел=@Department_Name, id_отдела=@id
                           WHERE id_отдела=@oldID
                           UPDATE Сотрудник SET id_отдела=@id
                           WHERE id_отдела=NULL";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@id", Department.ID));
                    command.Parameters.Add(new SqlParameter("@Department_Name", Department.Name));
                    command.Parameters.Add(new SqlParameter("@oldID", oldID));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

        }
        public bool CheckID(int ID)
        {
            string sql = @"SELECT id_отдела
                           FROM Отдел
                           WHERE id_отдела=@id";
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

        public bool CheckName(string Name)
        {
            string sql = @"SELECT Отдел
                           FROM Отдел
                           WHERE Отдел=@Name";
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

        public void DeleteDepartment(int id)
        {
            string sql = @"DELETE Мероприятия_Сотрудники WHERE id_сотрудника=
                           ANY(SELECT id_сотрудника FROM Сотрудник WHERE id_отдела=@id)
                           DELETE Сотрудник WHERE id_отдела=@id
                           DELETE Отдел WHERE id_отдела=@id";
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

        public List<Department> SearchDep(Department department)
        {
            List<Department> result = new List<Department>();
            string sql = @"SELECT id_отдела, Отдел 
                           FROM Отдел
                           WHERE";
            bool one = true;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    if (department.ID != 0)
                    {
                       one = false;
                       command.CommandText = command.CommandText + " id_отдела=@id ";
                       command.Parameters.Add(new SqlParameter("@id", department.ID));
                    }
                    if (String.IsNullOrEmpty(department.Name) == false)
                    {
                       if (one == false)
                       {
                           command.CommandText = command.CommandText + " AND ";
                       }
                       command.CommandText = command.CommandText + " Отдел=@name";
                       command.Parameters.Add(new SqlParameter("@name", department.Name));
                    }
                    command.ExecuteNonQuery();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                           result.Add(new Department()
                           {
                                  ID = (int)reader["id_отдела"],
                                  Name = reader["Отдел"].ToString()
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
