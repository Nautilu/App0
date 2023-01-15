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
using App0.Forms;

namespace App0.Forms
{
    public partial class EventWorkerSearchDialog : Form
    {
        EventWorkerDataAccess EventWorkerDataAccess;
        EventDataAccess EventDataAccess;
        WorkerDataAccess WorkerDataAccess;
        string connectionString;
        private readonly List<Event> EventList;
        private readonly List<Worker> WorkerList;
        public EventWorker EventWorker { get; private set; }
        public EventWorkerSearchDialog()
        {
            InitializeComponent();
        }

        public EventWorkerSearchDialog(string connectionString)
        {
            InitializeComponent();
            BoundControl(connectionString);
            EventList = EventDataAccess.GetEvents();
            WorkerList = WorkerDataAccess.GetWorkers();
            this.connectionString = connectionString;
            EventWorker = new EventWorker();
            FillEvents();
            FillWorkers();
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

        private void FillEvents()
        {
            cbEvent.ValueMember = "ID";
            cbEvent.DisplayMember = "Name";
            List<Event> cbEventDataSource = new List<Event>();
            cbEventDataSource.AddRange(EventDataAccess.GetEventsForEWSearch());
            cbEventDataSource.Insert(0, new Event() { ID = -1, Name = "Любое мероприятие" });
            cbEvent.DataSource = cbEventDataSource;
        }
        private void FillWorkers()
        {
            cbWorker.ValueMember = "ID";
            cbWorker.DisplayMember = "FIO";
            List<Worker> cbWorkerDataSource = new List<Worker>();
            cbWorkerDataSource.AddRange(WorkerDataAccess.GetWorkersForEWSearch());
            cbWorkerDataSource.Insert(0, new Worker() { ID = -1, FIO = "Любой сотрудник" });
            cbWorker.DataSource = cbWorkerDataSource;
        }

        private bool CheckEmpty()
        {
            if (EventWorker.Event == null && EventWorker.Worker == null)
                return true;
            else
                return false;
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

        private Event GetEventFromComboBox()
        {
            Event Event = cbEvent.SelectedItem as Event;
            if (Event.ID == -1)
                return null; 
            return Event;
        }

        private Worker GetWorkerFromComboBox()
        {
            Worker Worker = cbWorker.SelectedItem as Worker;
            if (Worker.ID == -1)
                return null;
            return Worker;
        }

        private void scbtn_Click(object sender, EventArgs e)
        {
            EventWorker.Event = GetEventFromComboBox();
            EventWorker.Worker = GetWorkerFromComboBox();
            if (CheckEmpty())
            {
                MessageBox.Show("Данные для поиска не введены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgvEventWorker.DataSource = EventWorkerDataAccess.SearchEventWorker(EventWorker);
        }

        private void edtbtn_Click(object sender, EventArgs e)
        {
            EventWorker selectedEventWorker = GetEventWorker();
            if (selectedEventWorker == null)
            {
                MessageBox.Show("Строка не выбрана", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            EventWorkerAddEditDialog EditDialog = new EventWorkerAddEditDialog(connectionString, selectedEventWorker, EventList, WorkerList);
            if (EditDialog.ShowDialog() == DialogResult.OK)
            {
                EventWorkerDataAccess.UpdateEventsWorkers(EditDialog.EventWorker, selectedEventWorker.Event.ID,
                selectedEventWorker.Worker.ID);
                if (CheckEmpty())
                    dgvEventWorker.DataSource = EventWorkerDataAccess.GetEventsWorkers();
                else
                    dgvEventWorker.DataSource = EventWorkerDataAccess.SearchEventWorker(EventWorker);
            }
        }

        private void dtbtn_Click(object sender, EventArgs e)
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
                if (CheckEmpty())
                    dgvEventWorker.DataSource = EventWorkerDataAccess.GetEventsWorkers();
                else
                    dgvEventWorker.DataSource = EventWorkerDataAccess.SearchEventWorker(EventWorker);
            }
        }

        private void dpbtn_Click(object sender, EventArgs e)
        {
            dgvEventWorker.DataSource = EventWorkerDataAccess.GetEventsWorkers();
            FillEvents();
            FillWorkers();
            EventWorker.Event = null;
            EventWorker.Worker = null;
        }
    }
}
