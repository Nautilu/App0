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
    public partial class MemberAddEditDialog : Form
    {
        public Member Member { get; private set; }
        public bool Search { get; set; }
        MemberDataAccess MemberDataAccess;
        public MemberAddEditDialog(string connectionString)
        {
            InitializeComponent();
            Member = new Member();
            MemberDataAccess = new MemberDataAccess(connectionString);
            Text = "Добавить участника";
        }

        public MemberAddEditDialog(string connectionString, Member Member)
        {
            InitializeComponent();
            this.Member = Member;
            MemberDataAccess = new MemberDataAccess(connectionString);
            FillMembers();
            Text = "Редактировать участника";
        }

        private void FillMembers()
        {
            tbID.Text = Member.ID.ToString();
            tbName.Text = Member.FIO;
            tbEmail.Text = Member.Email;
            tbPhone.Text = Member.PhoneNumber;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbID.Text))
            {
                MessageBox.Show("ID не введено", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Convert.ToInt32(tbID.Text) == 0)
            {
                MessageBox.Show("ID не введено", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("ФИО не введено", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(tbPhone.Text))
            {
                MessageBox.Show("Номер телефона не введён", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(tbEmail.Text))
            {
                MessageBox.Show("Email не введён", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MemberDataAccess.CheckID(Convert.ToInt32(tbID.Text)))
            {
                MessageBox.Show("Участник с таким ID уже существует", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Member.ID != Convert.ToInt32(tbID.Text) && Member.ID !=0)
            {
                if (MessageBox.Show("ID участника было изменено, " +
                    "это действие может привести к удалению данных из смежных таблиц. " +
                    "Хотите продолжить?",
                    "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No)
                {
                    return;
                }
            }
            Member.ID = Convert.ToInt32(tbID.Text);
            Member.FIO = tbName.Text;
            Member.Email = tbEmail.Text;
            Member.PhoneNumber = tbPhone.Text;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }

    }
}
