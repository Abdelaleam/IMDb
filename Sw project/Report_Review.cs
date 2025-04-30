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
namespace Sw_project
{
    public partial class Report_Review : Form
    {
        string ordb = "Data source=orcl;User Id=hr;Password=hr;";
        protected OracleConnection conn;
        public Movie movie;
        public User user;
        Users.UserOP us = new UserOP();
        public Report_Review( int id)
        {
            InitializeComponent();
            user = us.GetUserByID(id);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int reviewId = Convert.ToInt32(textBox1.Text); 
                int id = 0;
                conn = new OracleConnection(ordb);
                conn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT USER_ID FROM Reviews WHERE REVIEW_ID = :r_id";
                cmd.Parameters.Add("r_id", OracleDbType.Int32).Value = reviewId;

                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    id = Convert.ToInt32(reader[0]);
                }
                else
                {
                    MessageBox.Show("No review found with that ID.");
                    reader.Close();
                    conn.Close();
                    return;
                }
                reader.Close();
                cmd.Parameters.Clear();
                cmd.CommandText = "submit_Report";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_user_id", OracleDbType.Int32).Value = id;
                cmd.Parameters.Add("p_rating", OracleDbType.Int32).Value = reviewId;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Report submitted successfully!");
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number.");
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }

        }

        private void Report_Review_Load(object sender, EventArgs e)
        {

        }
    }
}
