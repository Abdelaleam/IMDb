using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
namespace Sw_project
{
    public partial class CR_Report : Form
    {
        CrystalReport1 CR;
        public CR_Report()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime date1, date2;
            if(comboBox1.Text.Length>0)
            {
                CR.SetParameterValue(0, comboBox1.Text);
            }
            else
            {
                MessageBox.Show("Please Choose Genre");
            }
            if (DateTime.TryParse(textBox1.Text, out date1) && DateTime.TryParse(textBox2.Text, out date2))
            {
                CR.SetParameterValue(1, date1);
                CR.SetParameterValue(2, date2);
                crystalReportViewer1.ReportSource = CR;
            }
            else
            {
                MessageBox.Show("Please enter valid dates in both fields.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }      
            
            

        }

        private void CR_Report_Load(object sender, EventArgs e)
        {
            CR = new CrystalReport1();
            foreach(ParameterDiscreteValue gen in CR.ParameterFields[0].DefaultValues)
            {
                comboBox1.Items.Add(gen.Value);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
