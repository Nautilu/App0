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
    public partial class EventWorkerUserControl : UserControl
    {
        EventWorkerDataAccess EventWorkerDataAccess;
        EventDataAccess EventDataAccess;
        WorkerDataAccess WorkerDataAccess;
        string connectionString;
        public EventWorkerUserControl()
        {
            InitializeComponent();
        }

        public EventWorkerUserControl(string connectionString)
        {
            InitializeComponent();
            BoundControl(connectionString);
   
        }
        public void BoundControl(string connectionString)
        {
            EventDataAccess = new EventDataAccess(connectionString);
            WorkerDataAccess = new WorkerDataAccess(connectionString);
            EventWorkerDataAccess = new EventWorkerDataAccess(connectionString);
            dgvEventWorker.AutoGenerateColumns = false;
            dgvEventWorker.DataSource = EventWorkerDataAccess.GetEventsWorkers();
            this.connectionString = connectionString;
        }
        private EventWorker GetEventWorker()
        {
            if (dgvEventWorker.SelectedRows == null || dgvEventWorker.SelectedRows.Count == 0)
                return null;
            return (dgvEventWorker.SelectedRows[0].DataBoundItem as EventWorker);
        }

        private List<EventWorker> GetEventWorkers()
        {
            if (dgvEventWorker.SelectedRows == null || dgvEventWorker.SelectedRows.Count == 0)
                return null;
            List<EventWorker> result = new List<EventWorker>();
            foreach (DataGridViewRow row in dgvEventWorker.SelectedRows)
                result.Add(row.DataBoundItem as EventWorker);
            return result;
        }


        private void Add_Click(object sender, EventArgs e)
        {
            var Worker = WorkerDataAccess.GetWorkers();
            var Event = EventDataAccess.GetEvents();
            EventWorkerAddEditDialog EventWorkerAddDialog = new EventWorkerAddEditDialog(connectionString, Event, Worker);
            if (EventWorkerAddDialog.ShowDialog() == DialogResult.OK)
            {
                EventWorkerDataAccess.InsertEventsWorkers(EventWorkerAddDialog.EventWorker);
                dgvEventWorker.DataSource = EventWorkerDataAccess.GetEventsWorkers();
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            var Worker = WorkerDataAccess.GetWorkers();
            var Event = EventDataAccess.GetEvents();
            EventWorker selectedEventWorker = GetEventWorker();
            int WID = selectedEventWorker.Worker.ID;
            int EID = selectedEventWorker.Event.ID;
            if (selectedEventWorker == null)
            {
                MessageBox.Show("Строка не выбрана", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            EventWorkerAddEditDialog EditDialog = new EventWorkerAddEditDialog(connectionString, selectedEventWorker, Event, Worker);
            if (EditDialog.ShowDialog() == DialogResult.OK)
            {
                EventWorkerDataAccess.UpdateEventsWorkers(EditDialog.EventWorker, EID, WID);
                dgvEventWorker.DataSource = EventWorkerDataAccess.GetEventsWorkers();
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            List<EventWorker> selectedEventWorker = GetEventWorkers();
            if (selectedEventWorker == null)
            {
                MessageBox.Show("Строка не выбрана", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var msg = MessageBox.Show("Хотите удалить?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msg == DialogResult.Yes)
            {
                foreach (EventWorker EventWorker in selectedEventWorker)
                { EventWorkerDataAccess.DeleteEventWorker(EventWorker.Event.ID, EventWorker.Worker.ID); }
                dgvEventWorker.DataSource = EventWorkerDataAccess.GetEventsWorkers();
            }
        }

        private void scbtn_Click(object sender, EventArgs e)
        {
            EventWorkerSearchDialog EWDialog = new EventWorkerSearchDialog(connectionString);
            if (EWDialog.ShowDialog() != DialogResult.OK)
            {
                dgvEventWorker.DataSource = EventWorkerDataAccess.GetEventsWorkers();
            }
        }
        public void Renew()
        {
            dgvEventWorker.DataSource = EventWorkerDataAccess.GetEventsWorkers();
        }
    }
}
