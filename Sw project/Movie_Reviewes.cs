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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using Sw_project.Movies;

namespace Sw_project
{
    public partial class Movie_Reviewes : Form
    {
        int m_id;
        int U_id;
        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet ds;
        public Movie_Reviewes(int id,int U_id)
        {
            InitializeComponent();
            m_id = id;
            this.U_id = U_id;
        }

        private void Movie_Reviewes_Load(object sender, EventArgs e)
        {

            string constr = "Data source=orcl;User Id=hr;Password=hr;";
            string cmdstr = "select * from Reviews  where MOVIE_ID=:m1_id";

            adapter = new OracleDataAdapter(cmdstr, constr);
            adapter.SelectCommand.Parameters.Add("m1_id", m_id);
            ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns["IS_BAD"].Visible = false;
            dataGridView1.Columns["v_count"].Visible = false;



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void R_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Report_Review r = new Report_Review(U_id);
            this.Hide();
            r.FormClosed += R_FormClosed;
            r.Show();

        }
    }
}
