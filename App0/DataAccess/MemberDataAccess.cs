using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App0.Models;
using System.Data.SqlClient;

namespace App0.DataAccess
{
    public class MemberDataAccess : BaseDataAccess
    {
        public MemberDataAccess(string connectionString)
        : base(connectionString)
        {
        }

        public List<Member> GetMembers()
        {
            List<Member> result = new List<Member>();
            string sql = @"SELECT id_участника, ФИО, Телефон, email
                           FROM Участник";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Member()
                            {
                                ID = (int)reader["id_участника"],
                                FIO = reader["ФИО"].ToString(),
                                PhoneNumber = reader["Телефон"].ToString(),
                                Email = reader["email"].ToString()
                            });
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return result;
        }

        public List<Member> GetMembersForSearch()
        {
            List<Member> result = new List<Member>();
            string sql = @"SELECT DISTINCT У.id_участника, У.ФИО
                           FROM Участник У
                           JOIN Мероприятия_Участники МУ ON У.id_участника=МУ.id_участника";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Member()
                            {
                                ID = (int)reader["id_участника"],
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
        public void InsertMember(Member Member)
        {
            string sql = @"INSERT INTO Участник(id_участника, ФИО, Телефон, email) 
                           VALUES (@id, @Name, @Phone, @email)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@id", Member.ID));
                    command.Parameters.Add(new SqlParameter("@Name", Member.FIO));
                    command.Parameters.Add(new SqlParameter("@Phone", Member.PhoneNumber));
                    command.Parameters.Add(new SqlParameter("@email", Member.Email));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }


        public void UpdateMember(Member Member)
        {
            string sql = @"UPDATE Участник SET ФИО=@Name, @Phone=Телефон, @email=Email, 
                           WHERE id_участника=@id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Phone", Member.PhoneNumber));
                    command.Parameters.Add(new SqlParameter("@Name", Member.FIO));
                    command.Parameters.Add(new SqlParameter("@email", Member.Email));
                    command.Parameters.Add(new SqlParameter("@id", Member.ID));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

        }

        public void UpdateMember(Member Member, int oldID)
        {
            string sql = @"DELETE FROM Мероприятия_Участники
                           WHERE id_участника=@oldID
                           UPDATE Участник SET ФИО=@Name, @Phone=Телефон, @email=Email, 
                           id_участника=@id
                           WHERE id_участника=@oldID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@id", Member.ID));
                    command.Parameters.Add(new SqlParameter("@Phone", Member.PhoneNumber));
                    command.Parameters.Add(new SqlParameter("@Name", Member.FIO));
                    command.Parameters.Add(new SqlParameter("@email", Member.Email));
                    command.Parameters.Add(new SqlParameter("@oldID", oldID));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

        }

        public bool CheckID(int id)
        {
            string sql = @"SELECT id_участника
                           FROM Участник
                           WHERE id_участника=@id";
            bool result = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@id", id));
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


        public void DeleteMember(int id)
        {
            string sql = @"DELETE Мероприятия_Участники WHERE id_участника=@id
                           DELETE Участник WHERE id_участника=@id";
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

        public List<Member> SearchMember(Member Member)
        {
            List<Member> result = new List<Member>();
            string sql = @"SELECT id_участника, ФИО, Телефон,
                           email
                           FROM Отдел
                           WHERE";
            bool one = true;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    if (Member.ID != 0)
                    {
                        one = false;
                        command.CommandText = command.CommandText + " id_участника=@id";
                        command.Parameters.Add(new SqlParameter("@id", Member.ID)); 
                    }
                    if(String.IsNullOrEmpty(Member.FIO)==false)
                    {
                        if (one == false) 
                        {
                            if (one == false)
                            {
                                command.CommandText = command.CommandText + " AND ";
                            }
                            else 
                            {
                                one = false;
                            }
                        }
                        command.CommandText = command.CommandText + " ФИО=@Name";
                        command.Parameters.Add(new SqlParameter("@Name", Member.FIO));
                    }
                    if (String.IsNullOrEmpty(Member.PhoneNumber) == false)
                    {
                        if (one == false)
                        {
                            if (one == false)
                            {
                                command.CommandText = command.CommandText + " AND ";
                            }
                            else
                            {
                                one = false;
                            }
                        }
                        command.CommandText = command.CommandText + " Телефон=@Phone";
                        command.Parameters.Add(new SqlParameter("@Phone", Member.PhoneNumber));
                    }
                    if (String.IsNullOrEmpty(Member.Email) == false)
                    {
                        if (one == false)
                        {
                            if (one == false)
                            {
                                command.CommandText = command.CommandText + " AND ";
                            }
                            else
                            {
                                one = false;
                            }
                        }
                        command.CommandText = command.CommandText + " email=@email";
                        command.Parameters.Add(new SqlParameter("@email", Member.Email));
                    }
                    command.ExecuteNonQuery();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Member()
                            {
                                ID = (int)reader["id_вида"],
                                FIO = reader["ФИО"].ToString(),
                                PhoneNumber = reader["Телефон"].ToString(),
                                Email = reader["email"].ToString()
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
