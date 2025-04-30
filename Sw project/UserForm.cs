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
namespace Sw_project
{
    
    public partial class UserForm : Form
    {
        bool tst=false; 
        public List<Movie> movies;
        Users.UserOP us= new Users.UserOP();
        Movies.SearchOP SearchOP = new Movies.SearchOP();
        User user=new User(); 
        public UserForm(int id)
        {
            InitializeComponent();
            user = us.GetUserByID(id);
        }

        private void UserForm_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           
          

        }
        private void Search_cloased(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            string currentText = comboBox1.Text;
            movies = SearchOP.SearchM(currentText);
            comboBox1.TextChanged -= comboBox1_TextChanged; 
            comboBox1.Items.Clear(); 
            if (movies.Count > 0)
            {
                foreach (Movie movie in movies)
                {
                    comboBox1.Items.Add(movie.title);
                }
            }
            comboBox1.Text = currentText;
            comboBox1.SelectionStart = currentText.Length;
            comboBox1.SelectionLength = 0;
            comboBox1.TextChanged += comboBox1_TextChanged; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                
                string t = comboBox1.SelectedItem.ToString();
                if (!string.IsNullOrWhiteSpace(t))
                {
                    foreach (Movie s in movies)
                    {
                        if (s.title.Equals(t))
                        {
                            MovieDetailes mo = new MovieDetailes(s, user.Id);
                            this.Hide();
                            mo.FormClosed += Search_cloased;
                            mo.Show();
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please choose a movie:)");
                }
            }
            else
            {
                MessageBox.Show("Please choose a movie:)");
            }

        }

        private void watch_Click(object sender, EventArgs e)
        {
            Watch_list mo = new Watch_list(user.Id);
            this.Hide();
            mo.FormClosed += W_cloased;
            mo.Show();
        }
        private void W_cloased(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
    }
}
