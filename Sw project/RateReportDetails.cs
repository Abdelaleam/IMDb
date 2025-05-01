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
    public partial class RateReportDetails : Form
    {
        CrystalReport2 CR2;
        public RateReportDetails()
        {
            InitializeComponent();
        }

        private void RateReportDetails_Load(object sender, EventArgs e)
        {

            CR2 = new CrystalReport2(); 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = CR2;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
