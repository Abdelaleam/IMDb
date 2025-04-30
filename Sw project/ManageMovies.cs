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
namespace Sw_project
{
    public partial class ManageMovies : Form
    {
        public List<Movie> movies;
        Movie m = new Movie();
        Movies.SearchOP SearchOP=new Movies.SearchOP();
        public ManageMovies()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null) return;
            
            string t = comboBox1.SelectedItem.ToString();
            foreach (Movie s in movies)
            {
                if (s.title.Equals(t))
                {
                    m = s;
                  
                  
                    break;
                }
            }
            MessageBox.Show($"Selected Movie: iddddddddd, ID: {m.id}");
            textBox2.Text = m.genre;
            textBox3.Text = m.released_date.ToString();
            textBox4.Text = m.description;
            List<string> actors = SearchOP.GetMovieActors(m.id);
            textBox1.Text = string.Join(",", actors);
        }

        private bool IsValidDateTimeFormat(string input)
        {
            try
            {
                
                string[] formats = {
                    "M/d/yyyy h:mm:ss tt",   
                    "MM/dd/yyyy h:mm:ss tt",  
                    "M/d/yyyy hh:mm:ss tt",  
                    "MM/dd/yyyy hh:mm:ss tt"  
                };

                return DateTime.TryParseExact(
                    input,
                    formats,
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out DateTime result
                );
            }
            catch
            {
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValidDateTimeFormat(textBox3.Text))
                {
                    MessageBox.Show("Please enter date in format: Month/Day/Year Hour:Minute:Second AM/PM\n" +
                                  "Examples:\n" +
                                  "12/8/2025 12:00:00 AM\n" +
                                  "12/08/2025 12:00:00 AM");
                    return;
                }

                m.title = comboBox1.Text;
                m.genre = textBox2.Text;
                m.released_date = DateTime.Parse(textBox3.Text);
                m.description = textBox4.Text;
                string s = textBox1.Text;
                SearchOP.insert_movie(m);
                m.id = SearchOP.Get_Movie_id(m.title);
                SearchOP.Update_Actors(s, m.id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValidDateTimeFormat(textBox3.Text))
                {
                    MessageBox.Show("Please enter date in format: Month/Day/Year Hour:Minute:Second AM/PM\n" +
                                  "Examples:\n" +
                                  "12/8/2025 12:00:00 AM\n" +
                                  "12/08/2025 12:00:00 AM");
                    return;
                }

                m.genre = textBox2.Text;
                m.released_date = DateTime.Parse(textBox3.Text);
                m.description = textBox4.Text;
                string s = textBox1.Text;
                SearchOP.Update_Movie(m);
                SearchOP.Update_Actors(s, m.id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button2_TextChanged(object sender, EventArgs e)
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
        private void ManageMovies_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
