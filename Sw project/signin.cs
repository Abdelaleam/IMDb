using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sw_project.Users;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
namespace Sw_project
{
    public partial class signin : Form
    { 
        UserOP userOp = new UserOP();
        public signin()
        {
            InitializeComponent();
        }

        private void signin_Load(object sender, EventArgs e)
        {
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            string Email = email_in.Text;
            string Password = pass_in.Text;
           
            User user = userOp.SignIn(Email, Password);

            if (user != null )
            {
                if (!userOp.is_banned(user.Id))
                {
                    MessageBox.Show($"Welcome {user.UserName}!");
                    MessageBox.Show(user.Role);
                    if (user.Role.Equals("ADMIN"))
                    {
                        AdminForm form = new AdminForm(user.Id);
                        this.Hide();
                        form.FormClosed += AdminFormClosed;
                        form.Show();
                    }
                    else if (user.Role.Equals("USER"))
                    {
                        UserForm form = new UserForm(user.Id);
                        this.Hide();
                        form.FormClosed += UserFormClosed;
                        form.Show();
                    }
                }
                else if (userOp.is_banned(user.Id))
                    MessageBox.Show("This User is Banned");
                else
                {
                    MessageBox.Show("Login Failed");
                }
               
            }
            else
            {
                MessageBox.Show("Invalid email or password.");
            }

           
        }
        private void AdminFormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
        private void UserFormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
    }
}
