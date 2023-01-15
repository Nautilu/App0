using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App0.DataAccess;
using System.Configuration;

namespace App0
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["3.Properties.Settings.3ConnectionString"].ConnectionString;
            departmentUserControl1.BoundControl(connectionString);
            statusUserControl1.BoundControl(connectionString);
            eventUserControl1.BoundControl(connectionString);
            eventWorkerUserControl1.BoundControl(connectionString);
            jobUserControl1.BoundControl(connectionString);
            formUserControl1.BoundControl(connectionString);
            workerUserControl1.BoundControl(connectionString);
            memberUserControl1.BoundControl(connectionString);
            eventMemberUserControl1.BoundControl(connectionString);
        }

        private void departmentUserControl1_Load(object sender, EventArgs e)
        {

        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
             workerUserControl1.Renew();
        }


        private void tabPage4_Enter(object sender, EventArgs e)
        {
            eventUserControl1.Renew();
        }


        private void tabPage7_Enter(object sender, EventArgs e)
        {
            eventWorkerUserControl1.Renew();
        }

        private void tabPage8_Enter(object sender, EventArgs e)
        {
            memberUserControl1.Renew();
        }

        private void tabPage9_Enter(object sender, EventArgs e)
        {
            eventMemberUserControl1.Renew();
        }
    }
}
