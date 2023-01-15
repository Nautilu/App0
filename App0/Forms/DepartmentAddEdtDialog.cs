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
    public partial class DepartmentAddEdtDialog : Form
    {
        public Department Department { get; private set; }
        DepartmentDataAccess DepartmentDataAccess;
        bool Search;
        public DepartmentAddEdtDialog(string conncetionString)
        {
            InitializeComponent();
            Text = "Добавить отдел";
            Department = new Department();
            DepartmentDataAccess = new DepartmentDataAccess(conncetionString);
        }

        public DepartmentAddEdtDialog(string conncetionString, Department Department)
        {
            InitializeComponent();
            Text = "Редактировать отдел";
            this.Department = Department;
            FillDepartments();
            DepartmentDataAccess = new DepartmentDataAccess(conncetionString);
        }

        public DepartmentAddEdtDialog(bool search)
        {
            InitializeComponent();
            Text = "Найти отдел";
            Department = new Department();
            Search = search;
        }

        private void FillDepartments()
        {
            tbID.Text = Department.ID.ToString();
            tbName.Text = Department.Name;
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
                MessageBox.Show("Id отдела должно отличаться от 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Название отдела не введено", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (DepartmentDataAccess.CheckID(Convert.ToInt32(tbID.Text)) && Department.ID != Convert.ToInt32(tbID.Text))
                {
                    MessageBox.Show("Отдел с таким номером уже существует", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (DepartmentDataAccess.CheckName(tbName.Text) && Department.Name != tbName.Text)
                {
                    MessageBox.Show("Отдел с таким названием уже существует", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Department.ID = Convert.ToInt32(tbID.Text);
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
                    Department.ID = Convert.ToInt32(tbID.Text);
                }
            }
            Department.Name = tbName.Text;
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
