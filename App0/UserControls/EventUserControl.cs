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
    public partial class EventUserControl : UserControl
    {
        EventDataAccess EventDataAccess;
        FormDataAccess FormDataAccess;
        StatusDataAccess StatusDataAccess;
        string connectionString;
        public EventUserControl()
        {
            InitializeComponent();
        }

        public EventUserControl(string connectionString)
        {
            InitializeComponent();
            BoundControl(connectionString);
        }

        public void BoundControl(string connectionString)
        {
            EventDataAccess = new EventDataAccess(connectionString);
            FormDataAccess = new FormDataAccess(connectionString);
            StatusDataAccess = new StatusDataAccess(connectionString);
            dgvEvent.AutoGenerateColumns = false;
            dgvEvent.DataSource = EventDataAccess.GetEvents();
            this.connectionString = connectionString;
        }

        private Event GetSelectedEvent()
        {
            if (dgvEvent.SelectedRows == null || dgvEvent.SelectedRows.Count == 0)
                return null;
            return (dgvEvent.SelectedRows[0].DataBoundItem as Event);
        }

        private List<Event> GetSelectedEvents()
        {
            if (dgvEvent.SelectedRows == null || dgvEvent.SelectedRows.Count == 0)
                return null;
            List<Event> result = new List<Event>();
            foreach(DataGridViewRow row in dgvEvent.SelectedRows)
            {
                result.Add(row.DataBoundItem as Event);
            }
            return result;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            var Status = StatusDataAccess.GetStatuses();
            var Form = FormDataAccess.GetForms();
            EventAddEditDialog SoulAddDialog = new EventAddEditDialog(connectionString,Form, Status);
            if (SoulAddDialog.ShowDialog() == DialogResult.OK)
            {
                EventDataAccess.InsertEvent(SoulAddDialog.Event);
                dgvEvent.DataSource = EventDataAccess.GetEvents();
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            var Status = StatusDataAccess.GetStatuses();
            var Form = FormDataAccess.GetForms();
            Event selectedEvent = GetSelectedEvent();
            int oldID = selectedEvent.ID;
            if (selectedEvent == null)
            {
                MessageBox.Show("Вид не выбран", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            EventAddEditDialog editDialog = new EventAddEditDialog(connectionString, selectedEvent, Form, Status);
            if (editDialog.ShowDialog() == DialogResult.OK)
            {
                if (editDialog.Event.ID == oldID)
                {
                    EventDataAccess.UpdateEvent(editDialog.Event);
                }
                else 
                {
                    EventDataAccess.UpdateEvent(editDialog.Event, oldID);
                }
                dgvEvent.DataSource = EventDataAccess.GetEvents();
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            List<Event> selectedEvent = GetSelectedEvents();
            if (selectedEvent == null)
            {
                MessageBox.Show("Мероприятие не выбрано", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var msg = MessageBox.Show("Хотите удалить?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msg == DialogResult.Yes)
            {
                foreach (Event i in selectedEvent)
                {
                    EventDataAccess.DeleteEvent(i.ID);
                }
                dgvEvent.DataSource = EventDataAccess.GetEvents();
            }
        }

        private void scbtn_Click(object sender, EventArgs e)
        {
            EventSearchDialog EventAddDialog = new EventSearchDialog(connectionString);
            if (EventAddDialog.ShowDialog() != DialogResult.OK)
            {
                dgvEvent.DataSource = EventDataAccess.GetEvents();
            }
        }

        public void Renew()
        {
            dgvEvent.DataSource = EventDataAccess.GetEvents();
        }
    }
}
