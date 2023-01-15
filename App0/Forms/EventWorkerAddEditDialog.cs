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
    public partial class EventWorkerAddEditDialog : Form
    {
        public EventWorker EventWorker { get; private set; }
        private readonly List<Event> Event;
        private readonly List<Worker> Worker;
        EventWorkerDataAccess EventWorkerDataAccess;
        public EventWorkerAddEditDialog(string connectionString, List<Event> Event, List<Worker> Worker)
        {
            InitializeComponent();
            this.Event = Event;
            this.Worker = Worker;
            EventWorker = new EventWorker();
            EventWorkerDataAccess = new EventWorkerDataAccess(connectionString);
            Text = "Добавить сотрудника, ответственного за мероприятие";
            FillEvents();
            FillWorkers();
        }

        public EventWorkerAddEditDialog(string connectionString, EventWorker EventWorker, List<Event> Event, List<Worker> Worker)
            : this(connectionString, Event, Worker)
        {
            this.EventWorker = EventWorker;
            Text = "Редактировать сотрудника, ответственного за мероприятие";
            FillEventsWorkers();
        }

        private void FillEventsWorkers()
        {
            cbWorker.SelectedItem = (EventWorker.Worker != null) ? Worker.Where(t => t.ID == EventWorker.Worker.ID).FirstOrDefault() : null;
            cbWorker.SelectedItem = (EventWorker.Event != null) ? Event.Where(t => t.ID == EventWorker.Event.ID).FirstOrDefault() : null;
        }

        private void FillEvents()
        {
            cbEvent.ValueMember = "ID";
            cbEvent.DisplayMember = "Name";
            List<Event> cbEventDataSource = new List<Event>();
            cbEventDataSource.AddRange(Event);
            cbEvent.DataSource = cbEventDataSource;
        }

        private void FillWorkers()
        {
            cbWorker.ValueMember = "ID";
            cbWorker.DisplayMember = "FIO";
            List<Worker> cbWorkerDataSource = new List<Worker>();
            cbWorkerDataSource.AddRange(Worker);
            cbWorker.DataSource = cbWorkerDataSource;
        }

        private Event GetEventFromComboBox() 
        {
            Event Event = cbEvent.SelectedItem as Event;
            return Event;
        }

        private Worker GetWorkerFromComboBx()
        {
            Worker Worker = cbWorker.SelectedItem as Worker;
            return Worker;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (GetEventFromComboBox() == null) 
            {
                MessageBox.Show("Мероприятие не выбрано", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (GetWorkerFromComboBx() == null)
            {
                MessageBox.Show("Сотрудник не выбран", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(EventWorkerDataAccess.CheckID(GetEventFromComboBox().ID, GetWorkerFromComboBx().ID))
            {
                MessageBox.Show("Такая строка уже существует", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            EventWorker.Event = GetEventFromComboBox();
            EventWorker.Worker = GetWorkerFromComboBx();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
