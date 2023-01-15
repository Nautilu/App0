using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App0.Models;
using App0.DataAccess;

namespace App0.Forms
{
    public partial class JobAddEdtDialog : Form
    {
        public Job Job{ get; private set; }
        JobDataAccess JobDataAccess;
        bool Search = false;
        public JobAddEdtDialog(string connectionString)
        {
            InitializeComponent();
            Job = new Job();
            JobDataAccess = new JobDataAccess(connectionString);
            Text = "Добавить должность";
        }

        public JobAddEdtDialog(string connectionString, Job Job)
        {
            InitializeComponent();
            this.Job = Job;
            JobDataAccess = new JobDataAccess(connectionString);
            FillJobs();
            Text = "Редактировать должность";
        }

        public JobAddEdtDialog(bool search)
        {
            InitializeComponent();
            Text = "Найти должность";
            Job = new Job();
            Search = search;
        }

        private void FillJobs()
        {
            tbID.Text = Job.ID.ToString();
            tbName.Text = Job.Name.ToString();
        }
        public bool CheckEmpty()
        {
            if (String.IsNullOrEmpty(tbID.Text) && String.IsNullOrEmpty(tbName.Text))
                return true;
            else
                return false;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            int i;
            if (Int32.TryParse(tbID.Text, out i) && (i == 0))
            {
                MessageBox.Show("Id должности должно отличаться от 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Search)
            {
                if (string.IsNullOrEmpty(tbID.Text))
                {
                    MessageBox.Show("Id отдела не введено", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrEmpty(tbName.Text))
                {
                    MessageBox.Show("Должность не введена", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (JobDataAccess.CheckID(Convert.ToInt32(tbID.Text)) && Job.ID != Convert.ToInt32(tbID.Text))
                {
                    MessageBox.Show("Отдел с таким номером уже существует", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (JobDataAccess.CheckName(tbName.Text) && Job.Name != tbName.Text)
                {
                    MessageBox.Show("Отдел с таким названием уже существует", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (Job.ID != Convert.ToInt32(tbID.Text) && Job.ID != 0)
                {
                    if (MessageBox.Show("ID должности было изменено, " +
                       "это действие может привести к удалению данных из других таблиц. " +
                        "Хотите продолжить?",
                        "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No)
                    {
                        return;
                    }
                }
                Job.ID = Convert.ToInt32(tbID.Text);
            }
            else
            {
                if (CheckEmpty())
                {
                    MessageBox.Show("Данные для поиска не введены", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!String.IsNullOrEmpty(tbID.Text))
                {
                    Job.ID = Convert.ToInt32(tbID.Text);
                }
            }
            Job.Name = tbName.Text;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void tbID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }
    }
}
