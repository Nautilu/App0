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
    public partial class EventMemberUserControl : UserControl
    {
        EventMemberDataAccess EventMemberDataAccess;
        EventDataAccess EventDataAccess;
        MemberDataAccess MemberDataAccess;
        string connectionString;
        public EventMemberUserControl()
        {
            InitializeComponent();
        }
        public EventMemberUserControl(string connectionString)
        {
            InitializeComponent();
            BoundControl(connectionString);
        }

        public void BoundControl(string connectionString)
        {
            EventDataAccess = new EventDataAccess(connectionString);
            MemberDataAccess = new MemberDataAccess(connectionString);
            EventMemberDataAccess = new EventMemberDataAccess(connectionString);
            dgvEventMember.AutoGenerateColumns = false;
            dgvEventMember.DataSource = EventMemberDataAccess.GetEventsMembers();
            this.connectionString = connectionString;
        }

        private EventMember GetEventMember()
        {
            if (dgvEventMember.SelectedRows == null || dgvEventMember.SelectedRows.Count == 0)
                return null;
            return (dgvEventMember.SelectedRows[0].DataBoundItem as EventMember);
        }

        private List<EventMember> GetEventMembers()
        {
            if (dgvEventMember.SelectedRows == null || dgvEventMember.SelectedRows.Count == 0)
                return null;
            List<EventMember> result= new List<EventMember>();
            foreach(DataGridViewRow row in dgvEventMember.SelectedRows)
            {
                result.Add(row.DataBoundItem as EventMember);
            }
            return result;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            var Member = MemberDataAccess.GetMembers();
            var Event = EventDataAccess.GetEvents();
            EventMemberAddEditDialog EventMemberAddDialog = new EventMemberAddEditDialog(connectionString, Event, Member);
            if (EventMemberAddDialog.ShowDialog() == DialogResult.OK)
            {
                EventMemberDataAccess.InsertEventsMembers(EventMemberAddDialog.EventMember);
                dgvEventMember.DataSource = EventMemberDataAccess.GetEventsMembers();
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            var Member = MemberDataAccess.GetMembers();
            var Event = EventDataAccess.GetEvents();
            EventMember selectedEventMember = GetEventMember();
            if (selectedEventMember == null)
            {
                MessageBox.Show("Строка не выбрана", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int EID = selectedEventMember.Event.ID;
            int MID = selectedEventMember.Member.ID;
            EventMemberAddEditDialog EditDialog = new EventMemberAddEditDialog(connectionString, selectedEventMember, Event, Member);
            if (EditDialog.ShowDialog() == DialogResult.OK)
            {
                EventMemberDataAccess.UpdateEventsMemebers(EditDialog.EventMember, EID, MID);
                dgvEventMember.DataSource = EventMemberDataAccess.GetEventsMembers();
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            List<EventMember> selectedEventMember = GetEventMembers();
            if (selectedEventMember == null)
            {
                MessageBox.Show("Строка не выбрана", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var msg = MessageBox.Show("Хотите удалить?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msg == DialogResult.Yes)
            {
                foreach (EventMember EventMember in selectedEventMember)
                {
                    EventMemberDataAccess.DeleteEventMember(EventMember.Event.ID,
                      EventMember.Member.ID);
                }
                dgvEventMember.DataSource = EventMemberDataAccess.GetEventsMembers();
            }
        }

        private void scbtn_Click(object sender, EventArgs e)
        {
            EventMemberSearchDialog EMDialog = new EventMemberSearchDialog(connectionString);
            if (EMDialog.ShowDialog() != DialogResult.OK)
            {
                dgvEventMember.DataSource = EventMemberDataAccess.GetEventsMembers();
            }
        }
        public void Renew()
        {
            dgvEventMember.DataSource = EventMemberDataAccess.GetEventsMembers();
        }

    }
}
