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


namespace App0.Forms
{
    public partial class MemberSearchDialog : Form
    {
        MemberDataAccess MemberDataAccess;
        public Member Member { get; private set; }
        string connectionString;
        public MemberSearchDialog()
        {
            InitializeComponent();
        }

        public MemberSearchDialog(string connectionString)
        {
            InitializeComponent();
            BoundControl(connectionString);
            Member = new Member();
        }

        public void BoundControl(string connectionString)
        {
            MemberDataAccess = new MemberDataAccess(connectionString);
            dgvMember.AutoGenerateColumns = false;
            dgvMember.DataSource = MemberDataAccess.GetMembers();
            this.connectionString = connectionString;
        }

        public Member GetSelectedMember()
        {
            if (dgvMember.SelectedRows == null || dgvMember.SelectedRows.Count == 0)
                return null;
            return (dgvMember.SelectedRows[0].DataBoundItem as Member);
        }

        public List<Member> GetSelectedMembers()
        {
            if (dgvMember.SelectedRows == null || dgvMember.SelectedRows.Count == 0)
                return null;
            List<Member> result = new List<Member>();
            foreach(DataGridViewRow row in dgvMember.SelectedRows)
            {
                result.Add(row.DataBoundItem as Member);
            }
            return result;
        }

        private bool CheckEmpty()
        {
            if (Member.ID == 0 && String.IsNullOrEmpty(Member.FIO)
                && String.IsNullOrEmpty(Member.PhoneNumber) && String.IsNullOrEmpty(Member.Email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void scbtn_Click(object sender, EventArgs e)
        {
            int i;
            if (Int32.TryParse(tbID.Text, out i) && (i == 0))
            {
                MessageBox.Show("Id участника должно отличаться от 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!String.IsNullOrEmpty(tbID.Text))
                Member.ID = Convert.ToInt32(tbID.Text);
            else
                Member.ID = 0;
            Member.FIO = tbFIO.Text;
            Member.PhoneNumber = tbFIO.Text;
            Member.Email = tbemail.Text;
            if (CheckEmpty())
            {
                MessageBox.Show("Данные для поиска не введены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgvMember.DataSource = MemberDataAccess.SearchMember(Member);
        }

        private void edtbtn_Click(object sender, EventArgs e)
        {
            Member selectedMember = GetSelectedMember();
            int oldID = selectedMember.ID;
            if (selectedMember == null)
            {
                MessageBox.Show("Участник не выбран", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MemberAddEditDialog editDialog = new MemberAddEditDialog(connectionString, selectedMember);
            if (editDialog.ShowDialog() == DialogResult.OK)
            {
                if (editDialog.Member.ID == oldID)
                {
                    MemberDataAccess.UpdateMember(editDialog.Member);
                }
                else
                {
                    MemberDataAccess.UpdateMember(editDialog.Member, oldID);
                }
                if (CheckEmpty())
                {
                    dgvMember.DataSource = MemberDataAccess.GetMembers();
                }
                else
                {
                    dgvMember.DataSource = MemberDataAccess.SearchMember(Member);
                }
            }
        }

        private void dtbtn_Click(object sender, EventArgs e)
        {
            List<Member> selectedMember = GetSelectedMembers();
            if (selectedMember == null)
            {
                MessageBox.Show("Участник не выбран", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var msg = MessageBox.Show("Хотите удалить участника?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msg == DialogResult.Yes)
            {
                foreach (Member member in selectedMember)
                { 
                    MemberDataAccess.DeleteMember(member.ID); 
                }
                if (CheckEmpty())
                {
                    dgvMember.DataSource = MemberDataAccess.GetMembers();
                }
                else
                {
                    dgvMember.DataSource = MemberDataAccess.SearchMember(Member);
                }
            }
        }

        private void dpbtn_Click(object sender, EventArgs e)
        {
            dgvMember.DataSource = MemberDataAccess.GetMembers();
            Member.ID = 0;
            Member.PhoneNumber = "";
            Member.FIO = "";
            Member.Email = "";
            tbemail.Text = "";
            tbFIO.Text = "";
            tbID.Text = "";
            tbPhone.Text = "";
        }

        private void tbID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void tbPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }
    }
}
