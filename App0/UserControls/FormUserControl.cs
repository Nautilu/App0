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
    public partial class FormUserControl : UserControl
    {
        FormDataAccess FormDataAccess;
        string connectionString; 
        public FormUserControl()
        {
            InitializeComponent();
        }

        public FormUserControl(string connectionstring)
        {
            InitializeComponent();
            BoundControl(connectionstring);
        }

        public void BoundControl(string connectionstring)
        {
            FormDataAccess = new FormDataAccess(connectionstring);
            dgvForm.AutoGenerateColumns = false;
            dgvForm.DataSource = FormDataAccess.GetForms();
            this.connectionString = connectionstring;
        }

        public EForm GetSelectedForm()
        {
            if (dgvForm.SelectedRows == null || dgvForm.SelectedRows.Count == 0)
                return null;
            return (dgvForm.SelectedRows[0].DataBoundItem as EForm);
        }
        private List<EForm> GetSelectedForms()
        {
            if (dgvForm.SelectedRows == null || dgvForm.SelectedRows.Count == 0)
                return null;
            List<EForm> result = new List<EForm>();
            foreach (DataGridViewRow row in dgvForm.SelectedRows)
            {
                result.Add(row.DataBoundItem as EForm);
            }
            return result;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            FormAddEdtDialog FormAddDialog = new FormAddEdtDialog(connectionString);
            if (FormAddDialog.ShowDialog() == DialogResult.OK)
            {
                FormDataAccess.InsertForm(FormAddDialog.EForm);
                dgvForm.DataSource = FormDataAccess.GetForms();
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            EForm selectedform = GetSelectedForm();
            int oldID = selectedform.ID;
            if (selectedform == null)
            {
                MessageBox.Show("Вид не выбран", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FormAddEdtDialog editDialog = new FormAddEdtDialog(connectionString, selectedform);
            if (editDialog.ShowDialog() == DialogResult.OK)
            {
                if (editDialog.EForm.ID == oldID)
                {
                    FormDataAccess.UpdateForm(editDialog.EForm);
                }
                else 
                {
                    FormDataAccess.UpdateForm(editDialog.EForm, oldID);
                }
                dgvForm.DataSource = FormDataAccess.GetForms();
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            List<EForm> selectedform = GetSelectedForms();
            if (selectedform == null)
            {
                MessageBox.Show("Вид не выбран", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var msg = MessageBox.Show(
                   " Существуют мероприятия" +
                   " относящиеся к этому виду, " +
                   " сначала удалите данные о них " +
                   " или измените данные об их виде.", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msg == DialogResult.Yes)
            {
                foreach (EForm form in selectedform)
                {
                    FormDataAccess.DeleteForm(form.ID);
                }
                dgvForm.DataSource = FormDataAccess.GetForms();
            }
        }

        private void scbtn_Click(object sender, EventArgs e)
        {
            FormAddEdtDialog FormDialog = new FormAddEdtDialog(true);
            if (FormDialog.ShowDialog() == DialogResult.OK)
            {
                dgvForm.DataSource = FormDataAccess.SearchForm(FormDialog.EForm);
            }
        }

        private void dpbtn_Click(object sender, EventArgs e)
        {
            dgvForm.DataSource = FormDataAccess.GetForms();
        }
    }
}
