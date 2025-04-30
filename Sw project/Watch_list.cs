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
using Sw_project.Users;

namespace Sw_project
{
    public partial class Watch_list : Form
    {
        int u_id;
        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet ds;
        string constr = "Data source=orcl;User Id=hr;Password=hr;";
        public Watch_list(int id)
        {
            InitializeComponent();
            u_id = id;
        }

        private void Watch_list_Load(object sender, EventArgs e)
        {

            string cmdstr = "Select * from Watchlist where USER_ID=:U_id";
            adapter = new OracleDataAdapter(cmdstr, constr);
            adapter.SelectCommand.Parameters.Add("U_id", u_id);
            ds = new DataSet();
            adapter.Fill(ds);
            ds.Tables[0].PrimaryKey = new DataColumn[]
            {
        ds.Tables[0].Columns["USER_ID"],
        ds.Tables[0].Columns["MOVIE_ID"]
            };
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns["USER_ID"].Visible = false;
            dataGridView1.Columns["MOVIE_ID"].Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            builder = new OracleCommandBuilder(adapter);
            MessageBox.Show("Changes saved successfully!");
            adapter.Update(ds.Tables[0]);
        }

        private void dataGridView1_AutoSizeColumnsModeChanged(object sender, DataGridViewAutoSizeColumnsModeEventArgs e)
        {

        }
    }
}
