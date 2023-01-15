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
    public partial class FormAddEdtDialog : Form
    {
        public EForm EForm { get; private set; }
        FormDataAccess FormDataAccess;
        bool Search = false;
        public FormAddEdtDialog(string connectionSring)
        {
            InitializeComponent();
            EForm = new EForm();
            FormDataAccess = new FormDataAccess(connectionSring);
            Text = "Добавить Вид";
        }

        public FormAddEdtDialog(string connectionSring, EForm EForm)
        {
            InitializeComponent();
            this.EForm = EForm;
            FormDataAccess = new FormDataAccess(connectionSring);
            FillForms();
            Text = "Изменить Вид";
        }

        public FormAddEdtDialog(bool Search)
        {
            InitializeComponent();
            EForm = new EForm();
            this.Search = Search;
            Text = "Найти Вид";
        }
        private void FillForms()
        {
            tbID.Text = EForm.ID.ToString();
            tbName.Text = EForm.Name;
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
                MessageBox.Show("Id вида должно отличаться от 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Search)
            {
                if (string.IsNullOrEmpty(tbID.Text))
                {
                    MessageBox.Show("Id вида не введено", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrEmpty(tbName.Text))
                {
                    MessageBox.Show("Название не введёно", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (FormDataAccess.CheckID(Convert.ToInt32(tbID.Text)) && EForm.ID != Convert.ToInt32(tbID.Text))
                {
                    MessageBox.Show("Отдел с таким номером уже существует", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (FormDataAccess.CheckName(tbName.Text) && EForm.Name != tbName.Text)
                {
                    MessageBox.Show("Отдел с таким названием уже существует", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                EForm.ID = Convert.ToInt32(tbID.Text);
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
                   EForm.ID = Convert.ToInt32(tbID.Text);
                }
            }
            EForm.Name = tbName.Text;
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
