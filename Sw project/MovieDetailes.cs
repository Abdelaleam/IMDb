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
    public partial class MovieDetailes : Form
    {
        public Movie movie;
        Movies.SearchOP s=new SearchOP();
        Users.UserOP us= new Users.UserOP();
        public User user;
        public MovieDetailes(Movie movie, int id)
        {
            InitializeComponent();
            this.movie = movie;
            user = us.GetUserByID(id);
        }

        private void MovieDetailes_Load(object sender, EventArgs e)
        {
            textBox1.Text = movie.title;
            textBox2.Text = movie.genre;
            textBox3.Text = movie.released_date.ToString();
            textBox4.Text = movie.description;
            List<string> actors = s.GetMovieActors(movie.id);
            textBox5.Text = string.Join(",", actors);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Rt_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
        private void Rv_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                Rate r = new Rate(movie, user.Id);
                this.Hide();
                r.FormClosed += Rt_FormClosed;
                r.Show();

            }
            else
            {
                MessageBox.Show("Please sign in to your account");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                Review mo = new Review(movie, user.Id);
                this.Hide();
                mo.FormClosed += Rv_FormClosed;
                mo.Show();
            }
            else
            {
                MessageBox.Show("Please sign in to your account");
            }
        }

        private void MR_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                Movie_Reviewes mo = new Movie_Reviewes(movie.id, user.Id);
                this.Hide();
                mo.FormClosed += MR_FormClosed;
                mo.Show();
            }
            else
            {
                MessageBox.Show("Please sign in to your account");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                string msg= s.Insert_to_watchlist(movie.id,user.Id,movie.title);
            MessageBox.Show(msg);
            }
            else
            {
                MessageBox.Show("Please sign in to your account");
            }

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
