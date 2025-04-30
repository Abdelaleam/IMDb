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
    public partial class MAIN : Form
    {
      public List<Movie> movies;
      public User user=new User();
        public MAIN()
        {
            InitializeComponent();
        }
        Movies.SearchOP SearchOP = new Movies.SearchOP();
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            signin signin = new signin();
            this.Hide();
            signin.FormClosed += Signin_FormClosed;
            signin.Show();
        }
        private void Signin_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            signup signup = new signup();
            this.Hide();
            signup.FormClosed += Signup_FormClosed;
            signup.Show();
        }
        private void Signup_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void button1_CursorChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

               
              
        }

        public void comboBox1_TextChanged(object sender, EventArgs e)
        {
            string currentText = comboBox1.Text;
            movies = SearchOP.SearchM(currentText);
            //comboBox1.TextChanged -= comboBox1_TextChanged;
            //comboBox1.Items.Clear(); 
            comboBox1.TextChanged -= comboBox1_TextChanged; // Detach first
            comboBox1.Items.Clear(); // Clear old suggestions

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

            comboBox1.TextChanged += comboBox1_TextChanged; // Reattach after all changes
        }
        private void Search_cloased(object sender, FormClosedEventArgs e)
        {
            this.Show();
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
                    MessageBox.Show("Please choose a movie.");
                }
            }
            else
            {
                MessageBox.Show("Please choose a movie.");
            }


        }
    }
}
