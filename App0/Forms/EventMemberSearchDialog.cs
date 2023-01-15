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
    public partial class EventMemberSearchDialog : Form
    {
        EventMemberDataAccess EventMemberDataAccess;
        EventDataAccess EventDataAccess;
        MemberDataAccess MemberDataAccess;
        private readonly List<Event> EventList;
        private readonly List<Member> MemberList;
        public EventMember EventMember { get; private set; }
        string connectionString;
        
        public EventMemberSearchDialog()
        {
            InitializeComponent();
        }
        public EventMemberSearchDialog(string connectionString)
        {
            InitializeComponent();
            BoundControl(connectionString);
            EventMember = new EventMember();
            EventList = EventDataAccess.GetEvents();
            MemberList = MemberDataAccess.GetMembers();
            FillEvents();
            FillMembers();
            Text = "Найти участника мероприятия";
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

        private void FillEvents()
        {
            cbEvent.ValueMember = "ID";
            cbEvent.DisplayMember = "Name";
            List<Event> cbEventDataSource = new List<Event>();
            cbEventDataSource.AddRange(EventDataAccess.GetEventsForEMSearch());
            cbEventDataSource.Insert(0, new Event() { ID = -1, Name = "Любое мероприятие" });
            cbEvent.DataSource = cbEventDataSource;
        }

        private void FillMembers()
        {
            cbMember.ValueMember = "ID";
            cbMember.DisplayMember = "FIO";
            List<Member> cbMemberDataSource = new List<Member>();
            cbMemberDataSource.AddRange(MemberDataAccess.GetMembersForSearch());
            cbMemberDataSource.Insert(0, new Member() { ID = -1, FIO = "Любой участник" });
            cbMember.DataSource = cbMemberDataSource;
        }

        private Event GetEventFromComboBox()
        {
            Event Event = cbEvent.SelectedItem as Event;
            if (Event.ID == -1)
                return null;
            return Event;
        }

        private Member GetMemberFromComboBox()
        {
            Member Member = cbMember.SelectedItem as Member;
            if (Member.ID == -1)
                return null;
            return Member;
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
            List<EventMember> result = new List<EventMember>();
            foreach (DataGridViewRow row in dgvEventMember.SelectedRows)
            {
                result.Add(row.DataBoundItem as EventMember);
            }
            return result;
        }

        private bool CheckEmpty()
        {
            if(EventMember.Member == null && EventMember.Event == null)
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
            EventMember.Member = GetMemberFromComboBox();
            EventMember.Event = GetEventFromComboBox();
            if (CheckEmpty())
            {
                MessageBox.Show("Данные для поиска не введены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvEventMember.DataSource = EventMemberDataAccess.SearchEventMember(EventMember);
        }

        private void edtbtn_Click(object sender, EventArgs e)
        {
            EventMember selectedEventMember = GetEventMember();
            if (selectedEventMember == null)
            {
                MessageBox.Show("Строка не выбрана", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            EventMemberAddEditDialog EditDialog = new EventMemberAddEditDialog(connectionString, selectedEventMember, EventList, MemberList);
            if (EditDialog.ShowDialog() == DialogResult.OK)
            {
                EventMemberDataAccess.UpdateEventsMemebers(EditDialog.EventMember, selectedEventMember.Event.ID,
                selectedEventMember.Member.ID);
                if (CheckEmpty())
                { 
                    dgvEventMember.DataSource = EventMemberDataAccess.GetEventsMembers(); 
                }
                else
                {
                    EventMember EventMember = new EventMember();
                    EventMember.Event = GetEventFromComboBox();
                    EventMember.Member = GetMemberFromComboBox();
                    dgvEventMember.DataSource = EventMemberDataAccess.SearchEventMember(EventMember);
                }
            }
        }

        private void dtbtn_Click(object sender, EventArgs e)
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
                if (CheckEmpty())
                { 
                    dgvEventMember.DataSource = EventMemberDataAccess.GetEventsMembers(); 
                }
                else 
                {
                    EventMember EventMember = new EventMember();
                    EventMember.Event = GetEventFromComboBox();
                    EventMember.Member = GetMemberFromComboBox();
                    dgvEventMember.DataSource = EventMemberDataAccess.SearchEventMember(EventMember);
                }
            }
        }

        private void dpbtn_Click(object sender, EventArgs e)
        {
            dgvEventMember.DataSource = EventMemberDataAccess.GetEventsMembers();
            FillMembers();
            FillEvents();
            EventMember.Event = null;
            EventMember.Member = null;
        }
    }
}
