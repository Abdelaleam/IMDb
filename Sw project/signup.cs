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
using Oracle.DataAccess.Types;
using Sw_project.Users;
namespace Sw_project
{
    public partial class signup : Form
    {
       
        public signup()
        {
            InitializeComponent();
        }
        UserOP userOp = new UserOP();
        private void Form1_Load(object sender, EventArgs e)
        {
          
            //OracleCommand cmd = new OracleCommand();
            //cmd.Connection = conn;
            //cmd.CommandText = "select * from Movies";
            //cmd.CommandType = CommandType.Text;
            //OracleDataReader dr = cmd.ExecuteReader();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username=user.Text;
            string Email=email.Text;
            string Pass = pass.Text;
            User us=new User(Email,Pass,username);
            int id = userOp.register(us);
            MessageBox.Show($"ID: {id}");
            user.Text = "";
            email.Text = "";
            pass.Text = "";

        }
    }
}
