using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App0.Models;
using System.Data.SqlClient;

namespace App0.DataAccess
{
    class EventWorkerDataAccess : BaseDataAccess
    {
        public EventWorkerDataAccess(string connectionString)
       : base(connectionString)
        {
        }

        public List<EventWorker> GetEventsWorkers()
        {
            List<EventWorker> result = new List<EventWorker>();
            string sql = @"SELECT МС.id_сотрудника , МС.id_мероприятия, С.ФИО, М.Название
                           FROM Мероприятия_Сотрудники МС
                           JOIN Мероприятие М ON М.id_мероприятия=МС.id_мероприятия
                           JOIN Сотрудник С ON С.id_сотрудника=МС.id_сотрудника";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new EventWorker()
                            {
                                Worker = reader["id_сотрудника"] != DBNull.Value ?
                                new Worker()
                                {
                                    ID = (int)reader["id_сотрудника"],
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

        public void InsertEventsWorkers(EventWorker EventWorker)
        {
            string sql = @"INSERT INTO Мероприятия_Сотрудники(id_мероприятия, id_сотрудника)
                           VALUES(@Event_id, @Worker_id)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Event_id", EventWorker.Event.ID));
                    command.Parameters.Add(new SqlParameter("@Worker_id", EventWorker.Worker.ID));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }


        public void UpdateEventsWorkers(EventWorker EventWorker, int i, int j)
        {
            string sql = @"UPDATE Мероприятия_Сотрудники SET id_мероприятия=@Event_id,
                           id_сотрудника=@Worker_id
                           WHERE id_мероприятия=@id AND id_сотрудника=@wid";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Worker_id", EventWorker.Worker.ID));
                    command.Parameters.Add(new SqlParameter("@Event_id", EventWorker.Event.ID));
                    command.Parameters.Add(new SqlParameter("@id", i));
                    command.Parameters.Add(new SqlParameter("@wid",j));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

        }

        public void DeleteEventWorker(int e, int w)
        {
            string sql = @"Мероприятия_Сотрудники WHERE id_мероприятия=@Event_id
                           AND id_сотрудника=@Worker_id  
                           ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Event_id", e));
                    command.Parameters.Add(new SqlParameter("@Worker_id", w));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

        }

        public bool CheckID(int ide, int idw)
        {
            string sql = @"SELECT id_мероприятия, id_сотрудника
                           FROM Мероприятия_Сотрудники
                           WHERE id_мероприятия=@ide AND id_сотрудника=@idw";
            bool result = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@ide", ide));
                    command.Parameters.Add(new SqlParameter("@idw", idw));
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

        public List<EventWorker> SearchEventWorker(EventWorker EventWorker)
        {
            List<EventWorker> result = new List<EventWorker>();
            string sql = @"SELECT МС.id_сотрудника , МС.id_мероприятия, С.ФИО, М.Название
                           FROM Мероприятия_Сотрудники МС
                           JOIN Мероприятие М ON М.id_мероприятия=МС.id_мероприятия
                           JOIN Сотрудник С ON С.id_сотрудника=МС.id_сотрудника
                           WHERE";
            bool one = true;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    if (EventWorker.Event != null)
                    {
                        one = false;
                        command.CommandText = command.CommandText + " МС.id_мероприятия=@Event_id ";
                        command.Parameters.Add(new SqlParameter("@Event_id", EventWorker.Event.ID));
                    }
                    if (EventWorker.Worker != null)
                    {
                        if (one == false)
                        {
                            command.CommandText = command.CommandText + " AND ";
                        }
                        command.CommandText = command.CommandText + " МС.id_сотрудника=@Worker_id";
                        command.Parameters.Add(new SqlParameter("@Worker_id", EventWorker.Worker.ID));
                    }
                    command.ExecuteNonQuery();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new EventWorker()
                            {
                                Worker = reader["id_сотрудника"] != DBNull.Value ?
                                new Worker()
                                {
                                    ID = (int)reader["id_сотрудника"],
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
