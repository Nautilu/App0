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
    public partial class EventMemberAddEditDialog : Form
    {
        public EventMember EventMember { get; private set; }
        private readonly List<Event> Event;
        private readonly List<Member> Member;
        EventMemberDataAccess EventMemberDataAccess;
        public EventMemberAddEditDialog(string connectionString, List<Event> Event, List<Member> Member)
        {
            InitializeComponent();
            this.Event = Event;
            this.Member = Member;
            EventMember = new EventMember();
            EventMemberDataAccess = new EventMemberDataAccess(connectionString);
            Text = "Добавить участника мероприятия";
            FillEvents();
            FillMembers();
        }

        public EventMemberAddEditDialog(string connectionString, EventMember EventMember, List<Event> Event, List<Member> Member)
            : this(connectionString, Event, Member)
        {
            this.EventMember = EventMember;
            Text = "Редактировать участника мероприятия";
            FillEventsMembers();
        }

        public EventMemberAddEditDialog(EventMember EventMember)
        {
            this.EventMember = EventMember;
            FillEventsMembers();
        }

        private void FillEventsMembers()
        {
            cbEvent.SelectedItem = (EventMember.Event != null) ? Event.Where(t => t.ID == EventMember.Event.ID).FirstOrDefault() : null;
            cbMember.SelectedItem = (EventMember.Member != null) ? Member.Where(t => t.ID == EventMember.Member.ID).FirstOrDefault() : null;
        }

        private void FillEvents()
        {
            cbEvent.ValueMember = "ID";
            cbEvent.DisplayMember = "Name";
            List<Event> cbEventDataSource = new List<Event>();
            cbEventDataSource.AddRange(Event);
            cbEvent.DataSource = cbEventDataSource;
        }

        private void FillMembers()
        {
            cbMember.ValueMember = "ID";
            cbMember.DisplayMember = "FIO";
            List<Member> cbMemberDataSource = new List<Member>();
            cbMemberDataSource.AddRange(Member);
            cbMember.DataSource = cbMemberDataSource;
        }

        private Event GetEventFromComboBox()
        {
            Event Event = cbEvent.SelectedItem as Event;
            return Event;
        }

        private Member GetMemberFromComboBox()
        {
            Member Member = cbMember.SelectedItem as Member;
            return Member;
        }


        private void OK_Click(object sender, EventArgs e)
        {
            if (GetEventFromComboBox() == null)
            {
                MessageBox.Show("Мероприятие не выбрано", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(GetMemberFromComboBox() == null)
            {
                MessageBox.Show("Участник не выбран", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (EventMemberDataAccess.CheckID(GetEventFromComboBox().ID, GetMemberFromComboBox().ID))
            {
                MessageBox.Show("Такая строка уже существует", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            EventMember.Event = GetEventFromComboBox();
            EventMember.Member = GetMemberFromComboBox();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
