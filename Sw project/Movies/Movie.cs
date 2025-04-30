using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Sw_project.Movies
{
    public class Movie
    {
        public int id;
        public string title;
        public string description;
        public string genre;
        public DateTime released_date;
    }
    public class SearchOP:ordbCon
    {
        public List<Movie> SearchM(string title)
        {
            List<Movie> list = new List<Movie>();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = this.conn;
            cmd.CommandText = "search_movies_by_title";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("Title", title);
            cmd.Parameters.Add("result", OracleDbType.RefCursor, ParameterDirection.Output);
            OracleDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                Movie movie = new Movie();
                movie.id = Convert.ToInt32(dr[0]);
                movie.title = dr[1].ToString();
                movie.genre = dr[2].ToString();
                movie.released_date = Convert.ToDateTime(dr[3]);
                movie.description = dr[4].ToString();
                list.Add(movie);
            }
            dr.Close();
            return list;
        }

        public int Get_Movie_id(string title)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = this.conn;
            cmd.CommandText = "SELECT movie_id FROM Movies WHERE title =:Title";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("Title", title);
            OracleDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                return -1;
            }
            reader.Read();
            int id = Convert.ToInt32(reader[0]);
            return id;
            
        }
        public int Get_Act_id(string name)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = this.conn;
            cmd.CommandText = "SELECT actor_id FROM Actors WHERE actor_name=:act";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("act", name);
            OracleDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                return -1;
            }
            reader.Read();
            int id = Convert.ToInt32(reader[0]);
            return id;
        }
        public void Update_Actors(string names, int movie_id)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = this.conn;
            cmd.CommandText = "DELETE FROM Movie_Actors WHERE movie_id = :id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("id", movie_id);
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO Movie_Actors (movie_id, actor_id) VALUES (:id, :act_id)";
            string[] actorNames = names.Split(',');
            foreach (string rawName in actorNames)
            {
                string name = rawName.Trim();
                int actor_id = Get_Act_id(name);   
                if (actor_id != -1) 
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("id", movie_id);
                    cmd.Parameters.Add("act_id", actor_id);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    OracleCommand new_actor = new OracleCommand();
                    new_actor.Connection = this.conn;
                    new_actor.CommandText = "INSERT INTO Actors(actor_name) VALUES(:act_name)";
                    new_actor.CommandType = CommandType.Text;
                    new_actor.Parameters.Add("act_name", name);
                    new_actor.ExecuteNonQuery();
                    new_actor.CommandText = "SELECT actor_id FROM Actors WHERE actor_name = :act_name";
                    OracleDataReader reader = new_actor.ExecuteReader();
                    reader.Read();
                    int newActorId = Convert.ToInt32(reader[0]);
                    reader.Close();
                    cmd.Parameters.Clear();
                    cmd.CommandText = "INSERT INTO Movie_Actors (movie_id, actor_id) VALUES (:id, :act_id)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("id", movie_id);
                    cmd.Parameters.Add("act_id", newActorId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Update_Movie(Movie movie)
        {
            movie.id=Get_Movie_id(movie.title);
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = this.conn;
            cmd.CommandText = "update Movies set title=:Title, genre=:Gen, released_date=:r_date, description=:Des where movie_id=:id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("Title",movie.title);
            cmd.Parameters.Add("Gen", movie.genre);
            cmd.Parameters.Add("released_date", movie.released_date);
            cmd.Parameters.Add("Des", movie.description);
            cmd.Parameters.Add("id",movie.id);
            int r=cmd.ExecuteNonQuery();
            if(r != -1)
            {
                MessageBox.Show("Movie Updated successfully");
            }
        }
        public List<string> GetMovieActors(int movieId)
        {
            List<string> actors = new List<string>();
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = this.conn;
                cmd.CommandText = "ACT_NAMES";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("id", movieId);
                cmd.Parameters.Add("P_RESULTSET", OracleDbType.RefCursor, ParameterDirection.Output);
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                        string actorName = dr[0].ToString();
                        actors.Add(actorName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting actors: " + ex.Message);
            }
            return actors;
        }
        public string Insert_to_watchlist(int movieId, int userid, string title)
        {
            string Message = "";
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = this.conn;
            cmd.CommandText = "add_to_watchlist";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_movie_id", movieId);
            cmd.Parameters.Add("p_user_id", userid);
            cmd.Parameters.Add("P_user_title", title);
            cmd.Parameters.Add("p_message", OracleDbType.Varchar2, 4000).Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();
            Message = cmd.Parameters["p_message"].Value.ToString();
            return Message;
        }
        public void insert_movie(Movie movie)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = this.conn;
                cmd.CommandText = "INSERT INTO Movies (title, genre, released_date, description) VALUES (:Title, :Gen, :r_date, :Des)";
                cmd.CommandType = CommandType.Text;
                
                cmd.Parameters.Add("Title", movie.title);
                cmd.Parameters.Add("Gen", movie.genre);
                cmd.Parameters.Add("r_date", movie.released_date);
                cmd.Parameters.Add("Des", movie.description);
                
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Movie Inserted successfully");
                }
                else
                {
                    MessageBox.Show("Failed to insert movie");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting movie: " + ex.Message);
            }
        }
    }
    
}
