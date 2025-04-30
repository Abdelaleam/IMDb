using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sw_project.Movies;
using Sw_project.Users;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
namespace Sw_project
{
    public partial class Rate : Form
    {
        string ordb = "Data source=orcl;User Id=hr;Password=hr;";
        protected OracleConnection conn;
        public Movie movie;
        public User user;
        Users.UserOP us=new UserOP();
        public Rate(Movie movie, int id)
        {
            InitializeComponent();
            this.movie = movie;
            user =us.GetUserByID(id);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void Rate_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!double.TryParse(textBox1.Text, out double rating) || rating < 0.0 || rating > 10.0)
                {
                    MessageBox.Show("Please enter a valid rating between 0.0 and 10.0");
                    return;
                }

                using (OracleConnection conn = new OracleConnection(ordb))
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand("submit_rating", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("p_movie_id", OracleDbType.Int32).Value = movie.id;
                        cmd.Parameters.Add("p_user_id", OracleDbType.Int32).Value = user.Id;
                        cmd.Parameters.Add("p_rating", OracleDbType.Double).Value = rating;

                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Rating submitted successfully!");
                this.Close();
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message);
            }
        }
    }
}