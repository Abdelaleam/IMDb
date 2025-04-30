using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sw_project
{
    public partial class AdminForm : Form
    {
        int AdminID;
        public AdminForm(int id)
        {
            InitializeComponent();
            this.AdminID = id;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManageMovies m = new ManageMovies();
            this.Hide();
            m.FormClosed += M_FormClosed;
            m.Show();
        }
        private void M_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManageUsers m = new ManageUsers();
            this.Hide();
            m.FormClosed += M_FormClosed;
            m.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ManageReviews m = new ManageReviews();
            this.Hide();
            m.FormClosed += M_FormClosed;
            m.Show();
        }
    }
}
