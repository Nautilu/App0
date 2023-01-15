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
using App0.Forms;
using App0.Models;

namespace App0.UserControls
{
    public partial class DepartmentUserControl : UserControl
    {
        DepartmentDataAccess DepartmentDataAccess;
        string connectionString;
        public DepartmentUserControl()
        {
            InitializeComponent();
        }

        public DepartmentUserControl(string connectionString)
        {
            InitializeComponent();
            BoundControl(connectionString);
        }

        public void BoundControl(string connectionString)
        {
            DepartmentDataAccess = new DepartmentDataAccess(connectionString);
            dgvDep.AutoGenerateColumns = false;
            dgvDep.DataSource = DepartmentDataAccess.GetDeps();
            this.connectionString = connectionString;
        }

        private Department GetSelectedDepartment()
        {
            if (dgvDep.SelectedRows == null || dgvDep.SelectedRows.Count == 0)
                return null;
            return (dgvDep.SelectedRows[0].DataBoundItem as Department);
        }

        private List<Department> GetSelectedDepartments()
        {
            if (dgvDep.SelectedRows == null || dgvDep.SelectedRows.Count == 0)
                return null;
            List<Department> result = new List<Department>();
            foreach(DataGridViewRow row in dgvDep.SelectedRows)
            {
                result.Add(row.DataBoundItem as Department);
            }
            return result;
        }


        private void addbtn_Click(object sender, EventArgs e)
        {
            DepartmentAddEdtDialog DepartmentAddDialog = new DepartmentAddEdtDialog(connectionString);
            if (DepartmentAddDialog.ShowDialog() == DialogResult.OK)
            {
                DepartmentDataAccess.InsertDepartment(DepartmentAddDialog.Department);
                dgvDep.DataSource = DepartmentDataAccess.GetDeps();
            }
        }

        private void edtbtn_Click(object sender, EventArgs e)
        {
            Department selectedDepartment = GetSelectedDepartment();
            if (selectedDepartment == null)
            {
                MessageBox.Show("Отдел не выбран", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int oldID = selectedDepartment.ID;
            DepartmentAddEdtDialog editDialog = new DepartmentAddEdtDialog(connectionString,selectedDepartment);
            if (editDialog.ShowDialog() == DialogResult.OK)
            {
                if (editDialog.Department.ID == oldID)
                { 
                    DepartmentDataAccess.UpdateDepartment(editDialog.Department);
                }
                else
                {
                    DepartmentDataAccess.UpdateDepartment(editDialog.Department, oldID);
                }
                dgvDep.DataSource = DepartmentDataAccess.GetDeps();
            }
        }

        private void dtbtn_Click(object sender, EventArgs e)
        {
            List<Department> selectedDepartment = GetSelectedDepartments();
            if (selectedDepartment == null)
            {
                MessageBox.Show("Отдел не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var msg = MessageBox.Show(
                    " В отделе который вы хотите удалить" +
                    " могут быть сотрудники, " +
                    " в случае удаления этого отдела данные о них " +
                    " будут также удалены" +
                    " вы уверены, что хотите удалить отдел?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (msg == DialogResult.Yes)
            {
                foreach (Department dep in selectedDepartment)
                { 
                    DepartmentDataAccess.DeleteDepartment(dep.ID);
                }
                dgvDep.DataSource = DepartmentDataAccess.GetDeps();
            }
        }

        private void scbtn_Click(object sender, EventArgs e)
        {
            DepartmentAddEdtDialog DepartmentDialog = new DepartmentAddEdtDialog(true);
            if (DepartmentDialog.ShowDialog() == DialogResult.OK)
            {
                dgvDep.DataSource = DepartmentDataAccess.SearchDep(DepartmentDialog.Department);
            }
        }

        private void dpbtn_Click(object sender, EventArgs e)
        {
            dgvDep.DataSource = DepartmentDataAccess.GetDeps();
        }

    }
}
