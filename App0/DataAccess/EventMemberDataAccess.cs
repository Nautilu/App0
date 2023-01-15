using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App0.Models;
using System.Data.SqlClient;

namespace App0.DataAccess
{
    public class EventMemberDataAccess : BaseDataAccess
    {
        public EventMemberDataAccess(string connectionString)
        : base(connectionString)
        {
        }

        public List<EventMember> GetEventsMembers()
        {
            List<EventMember> result = new List<EventMember>();
            string sql = @"SELECT МУ.id_участника, МУ.id_мероприятия, У.ФИО, М.Название
                           FROM Мероприятия_Участники МУ
                           JOIN Мероприятие М ON М.id_мероприятия=МУ.id_мероприятия
                           JOIN Участник У ON У.id_участника=МУ.id_участника";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new EventMember()
                            {
                                Member = reader["id_участника"] != DBNull.Value ?
                                new Member()
                                {
                                    ID = (int)reader["id_участника"],
                                    FIO = reader["ФИО"].ToString()
                                } : null,
                                Event = reader["id_мероприятия"] != DBNull.Value ?
                                new Event()
                                {
                                    ID = (int)reader["id_мероприятия"],
                                    Name = reader["Название"].ToString()
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

        public void InsertEventsMembers(EventMember EventMember)
        {
            string sql = @"INSERT INTO Мероприятия_Участники(id_мероприятия, id_участника)
                           VALUES(@Event_id, @Member_id)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Event_id", EventMember.Event.ID));
                    command.Parameters.Add(new SqlParameter("@Member_id", EventMember.Member.ID));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }


        public void UpdateEventsMemebers(EventMember EventWorker, int i, int j)
        {
            string sql = @"UPDATE Мероприятия_Участники SET id_мероприятия=@Event_id,
                           id_участника=@Member_id
                           WHERE id_мероприятия=@id AND id_участника=@wid";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Member_id", EventWorker.Member.ID));
                    command.Parameters.Add(new SqlParameter("@Event_id", EventWorker.Event.ID));
                    command.Parameters.Add(new SqlParameter("@id", i));
                    command.Parameters.Add(new SqlParameter("@wid", j));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

        }

        public void DeleteEventMember(int e, int w)
        {
            string sql = @"Мероприятия_Участники WHERE id_мероприятия=@Event_id
                           AND id_участника=@Member_id  
                           ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Event_id", e));
                    command.Parameters.Add(new SqlParameter("@Member_id", w));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

        }
        public bool CheckID(int ide, int idm)
        {
            string sql = @"SELECT id_мероприятия, id_участника
                           FROM Мероприятия_Участники
                           WHERE id_мероприятия=@ide AND id_участника=@idm";
            bool result = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@ide", ide));
                    command.Parameters.Add(new SqlParameter("@idm", idm));
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

        public List<EventMember> SearchEventMember(EventMember EventMember)
        {
            List<EventMember> result = new List<EventMember>();
            string sql = @"SELECT МУ.id_участника, МУ.id_мероприятия, У.ФИО, М.Название
                           FROM Мероприятия_Участники МУ
                           JOIN Мероприятие М ON М.id_мероприятия=МУ.id_мероприятия
                           JOIN Участник У ON У.id_участника=МУ.id_участника
                           WHERE ";
            bool one = true;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    if (EventMember.Event != null)
                    {
                        one = false;
                        command.CommandText = command.CommandText + " МУ.id_участника=@Event_id ";
                        command.Parameters.Add(new SqlParameter("@Event_id", EventMember.Event.ID));
                    }
                    if (EventMember.Member != null)
                    {
                        if (one == false)
                        {
                            command.CommandText = command.CommandText + " AND ";
                        }
                        command.CommandText = command.CommandText + " МУ.id_мероприятия=@Member_id";
                        command.Parameters.Add(new SqlParameter("@Member_id", EventMember.Member.ID));
                    }
                    command.ExecuteNonQuery();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new EventMember()
                            {
                                Member = reader["id_участника"] != DBNull.Value ?
                                new Member()
                                {
                                    ID = (int)reader["id_участника"],
                                    FIO = reader["ФИО"].ToString()
                                } : null,
                                Event = reader["id_мероприятия"] != DBNull.Value ?
                                new Event()
                                {
                                    ID = (int)reader["id_мероприятия"],
                                    Name = reader["Название"].ToString()
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
