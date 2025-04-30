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

namespace Sw_project
{
    public partial class Browse_by_Genre : Form
    {
        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet ds;
        string constr = "Data source=orcl;User Id=hr;Password=hr;";
        OracleConnection con;
        string gen = "";


        public Browse_by_Genre()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GetActorMovies_Load(object sender, EventArgs e)
        {
            con = new OracleConnection(constr);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select distinct(GENRE) From Movies";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                comboBox1.Items.Add(dataReader[0].ToString());
            }
            dataReader.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gen = comboBox1.Text.ToString();
            if (gen != "")
            {
                string cmdstr = "Select * from Movies where GENRE=:GEN";
                adapter = new OracleDataAdapter(cmdstr, constr);
                adapter.SelectCommand.Parameters.Add("GEN", gen);
                ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Please select Genre");
            }
        }
    }
}
