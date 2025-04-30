using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Sw_project.Movies;
using Sw_project.Users;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sw_project
{
    public partial class Review : Form
    {

        string ordb = "Data source=orcl;User Id=hr;Password=hr;";
        protected OracleConnection conn;
        public Movie movie;
        public User user;
        Users.UserOP us = new UserOP();
        public Review(Movie movie, int id)
        {
            InitializeComponent();
            this.movie = movie;
            user = us.GetUserByID(id);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void submit_Click(object sender, EventArgs e)
        {
            try
            {
                string reviewText = Review_text.Text.Trim();

                if (string.IsNullOrWhiteSpace(reviewText))
                {
                    MessageBox.Show("Please enter a review.");
                    return;
                }

                conn = new OracleConnection(ordb);
                conn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "submit_review";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("p_user_id", OracleDbType.Int32).Value = user.Id;
                cmd.Parameters.Add("p_movie_id", OracleDbType.Int32).Value = movie.id;
                cmd.Parameters.Add("p_review_text", OracleDbType.Varchar2).Value = reviewText;

                cmd.ExecuteNonQuery();
                MessageBox.Show("Review submitted successfully!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error submitting review: " + ex.Message);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void Review_Load(object sender, EventArgs e)
        {

        }
    }
}
