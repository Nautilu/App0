using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App0.Models;
using System.Data.SqlClient;

namespace App0.DataAccess
{
    class EventDataAccess : BaseDataAccess
    {
        public EventDataAccess(string connectionString)
       : base(connectionString)
        {
        }

        public List<Event> GetEvents()
        {
            List<Event> result = new List<Event>();
            string sql = @" SELECT М.id_мероприятия, М.Название, М.Информация,
                            В.id_вида , В.Вид, С.id_статуса, С.Статус,
                            М.Результат, М.Дата_начала, М.Дата_завершения
                            FROM Мероприятие М 
                            JOIN Вид В ON В.id_вида=М.id_вида
                            JOIN Статус С ON С.id_статуса=М.id_статуса";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                                result.Add(new Event()
                                {
                                    ID = (int)reader["id_мероприятия"],
                                    Name = reader["Название"].ToString(),
                                    Info = reader["Информация"].ToString(),
                                    StartTime = reader["Дата_начала"].ToString(),
                                    EndTime = reader["Дата_завершения"].ToString(),
                                    Result = reader["Результат"].ToString(),
                                    Form = reader["id_вида"] != DBNull.Value ?
                                    new EForm()
                                    {
                                        ID = (int)reader["id_вида"],
                                        Name = reader["Вид"].ToString()
                                    } : null,
                                    Status = reader["id_статуса"] != DBNull.Value ?
                                    new Status()
                                    {
                                        ID = (int)reader["id_статуса"],
                                        Name = reader["Статус"].ToString()
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

        public List<Event> GetEventsForEMSearch()
        {
            List<Event> result = new List<Event>();
            string sql = @"SELECT DISTINCT М.id_мероприятия, М.Название
                           FROM Мероприятие М
                           JOIN Мероприятия_Участники МУ ON М.id_мероприятия=МУ.id_мероприятия";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            result.Add(new Event()
                            {
                                ID = (int)reader["id_мероприятия"],
                                Name = reader["Название"].ToString(),
                            });
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return result;
        }
        public List<Event> GetEventsForEWSearch()
        {
            List<Event> result = new List<Event>();
            string sql = @"SELECT DISTINCT М.id_мероприятия, М.Название
                           FROM Мероприятие М
                           JOIN Мероприятия_Сотрудники МС ON М.id_мероприятия=МС.id_мероприятия";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            result.Add(new Event()
                            {
                                ID = (int)reader["id_мероприятия"],
                                Name = reader["Название"].ToString(),
                            });
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return result;
        }
        public void InsertEvent(Event Event)
        {
            string sql = @"INSERT INTO Мероприятие(id_мероприятия,Название, Информация, Дата_начала, 
                           Дата_завершения, id_вида, id_статуса, Результат)
                           VALUES(@id, @Name, @Info, @StartTime, @EndTime, @Form_id, @Status_id,
                           @Result)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@id", Event.ID));
                    command.Parameters.Add(new SqlParameter("@Name", Event.Name));
                    if (string.IsNullOrEmpty(Event.Info))
                        command.Parameters.Add(new SqlParameter("@Info", DBNull.Value));
                    else
                        command.Parameters.Add(new SqlParameter("@Info", Event.Info));
                    command.Parameters.Add(new SqlParameter("@StartTime", Event.StartTime));
                    if (string.IsNullOrEmpty(Event.EndTime))
                        command.Parameters.Add(new SqlParameter("@EndTime", DBNull.Value));
                    else
                        command.Parameters.Add(new SqlParameter("@EndTime", Event.EndTime));
                    command.Parameters.Add(new SqlParameter("@Form_id", Event.Form.ID));
                    command.Parameters.Add(new SqlParameter("@Status_id", Event.Status.ID));
                    command.Parameters.Add(new SqlParameter("@Result", Event.Result));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }


        public void UpdateEvent(Event Event)
        {
            string sql = @"UPDATE Мероприятие SET Название=@Name,
                           @Info=Информация,
                           Дата_начала=@StartTime, Дата_завершения=@EndTime,
                           id_вида=@Form_id,id_статуса=@Status_id,Результат=@Result
                           WHERE id_мероприятия=@id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@id", Event.ID));
                    command.Parameters.Add(new SqlParameter("@Name", Event.Name));
                    if (string.IsNullOrEmpty(Event.Info))
                        command.Parameters.Add(new SqlParameter("@Info", DBNull.Value));
                    else
                        command.Parameters.Add(new SqlParameter("@Info", Event.Info));
                    command.Parameters.Add(new SqlParameter("@StartTime", Event.StartTime));
                    if (string.IsNullOrEmpty(Event.EndTime))
                        command.Parameters.Add(new SqlParameter("@EndTime", DBNull.Value));
                    else
                        command.Parameters.Add(new SqlParameter("@EndTime", Event.EndTime));
                    command.Parameters.Add(new SqlParameter("@Form_id", Event.Form.ID));
                    command.Parameters.Add(new SqlParameter("@Status_id", Event.Status.ID));
                    command.Parameters.Add(new SqlParameter("@Result", Event.Result));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void UpdateEvent(Event Event, int oldID)
        {
            string sql = @"DELETE FROM Мероприятия_Сотрудники
                           WHERE id_мероприятия=@oldID
                           DELETE FROM Мероприятия_Участники
                           WHERE id_мероприятия=@oldID
                           UPDATE Мероприятие SET Название=@Name,
                           @Info=Информация,
                           Дата_начала=@StartTime, Дата_завершения=@EndTime,
                           id_вида=@Form_id,id_статуса=@Status_id,Результат=@Result,
                           id_мероприятия=@id
                           WHERE id_мероприятия=@oldID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@id", Event.ID));
                    command.Parameters.Add(new SqlParameter("@oldID", oldID));
                    command.Parameters.Add(new SqlParameter("@Name", Event.Name));
                    if (string.IsNullOrEmpty(Event.Info))
                        command.Parameters.Add(new SqlParameter("@Info", DBNull.Value));
                    else
                        command.Parameters.Add(new SqlParameter("@Info", Event.Info));
                    command.Parameters.Add(new SqlParameter("@StartTime", Event.StartTime));
                    if (string.IsNullOrEmpty(Event.EndTime))
                        command.Parameters.Add(new SqlParameter("@EndTime", DBNull.Value));
                    else
                        command.Parameters.Add(new SqlParameter("@EndTime", Event.EndTime));
                    command.Parameters.Add(new SqlParameter("@Form_id", Event.Form.ID));
                    command.Parameters.Add(new SqlParameter("@Status_id", Event.Status.ID));
                    command.Parameters.Add(new SqlParameter("@Result", Event.Result));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

        }

        public void DeleteEvent(int id)
        {
            string sql = @"DELETE Мероприятия_Сотрудники WHERE id_мероприятия=@id
                           DELETE Мероприятия_Участники WHERE id_мероприятия=@id
                           DELETE Мероприятие WHERE id_мероприятия=@id";
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

        public bool CheckID(int ID)
        {
            string sql = @"SELECT id_мероприятия
                           FROM Мероприятие
                           WHERE id_мероприятия=@id";
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

        public List<Event> SearchEvent(Event Event)
        {
            List<Event> result = new List<Event>();
            string sql = @"SELECT М.id_мероприятия, М.Название, М.Информация,
                           В.id_вида , В.Вид, С.id_статуса , С.Статус,
                           М.Результат, М.Дата_начала, М.Дата_завершения
                           FROM Мероприятие М 
                           JOIN Вид В ON В.id_вида=М.id_вида
                           JOIN Статус С ON С.id_статуса=М.id_статуса 
                           WHERE ";
            bool one = true;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    if (Event.ID != 0)
                    {
                        one = false;
                        command.CommandText = command.CommandText + " id_мероприятия=@id";
                        command.Parameters.Add(new SqlParameter("@id", Event.ID));
                    }
                    if (String.IsNullOrEmpty(Event.Name) == false)
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
                        command.CommandText = command.CommandText + " Название=@Name";
                        command.Parameters.Add(new SqlParameter("@Name", Event.Name)); 
                    }
                    if (String.IsNullOrEmpty(Event.Info) == false)
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
                        command.CommandText = command.CommandText + " Информация=@Info";
                        command.Parameters.Add(new SqlParameter("@Info", Event.Info));
                    }
                    if (String.IsNullOrEmpty(Event.StartTime) == false)
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
                        command.CommandText = command.CommandText + " Дата_начала=@StartTime";
                        command.Parameters.Add(new SqlParameter("@StartTime", Event.StartTime)); 
                    }
                    if (String.IsNullOrEmpty(Event.EndTime) == false)
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
                        command.CommandText = command.CommandText + " Дата_завершения=@EndTime";
                        command.Parameters.Add(new SqlParameter("@EndTime", Event.EndTime));
                    }
                    if (Event.Form != null)
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
                        command.CommandText = command.CommandText + " В.id_вида=@Form_id";
                        command.Parameters.Add(new SqlParameter("@Form_id", Event.Form.ID)); 
                    }
                    if (Event.Status != null)
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
                        command.CommandText = command.CommandText + " В.id_статуса=@Status_id";
                        command.Parameters.Add(new SqlParameter("@Status_id", Event.Status.ID));
                    }
                    if (String.IsNullOrEmpty(Event.Result) == false)
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
                        command.CommandText = command.CommandText + " Результат=@Result";
                        command.Parameters.Add(new SqlParameter("@Result", Event.Result));
                    }
                    command.ExecuteNonQuery();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Event()
                            {
                                ID = (int)reader["id_мероприятия"],
                                Name = reader["Название"].ToString(),
                                Info = reader["Информация"].ToString(),
                                StartTime = reader["Дата_начала"].ToString(),
                                EndTime = reader["Дата_завершения"].ToString(),
                                Result = reader["Результат"].ToString(),
                                Form = reader["id_вида"] != DBNull.Value ?
                                new EForm()
                                {
                                    ID = (int)reader["id_вида"],
                                    Name = reader["Вид"].ToString()
                                } : null,
                                Status = reader["id_статуса"] != DBNull.Value ?
                                new Status()
                                {
                                    ID = (int)reader["id_статуса"],
                                    Name = reader["Статус"].ToString()
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
