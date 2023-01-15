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
    public partial class EventSearchDialog : Form
    {
        private readonly List<EForm> Form;
        private readonly List<Status> Status;
        EventDataAccess EventDataAccess;
        FormDataAccess FormDataAccess;
        StatusDataAccess StatusDataAccess;
        string connectionString;
        public Event Event1 { get; private set; }
        public EventSearchDialog()
        {
            InitializeComponent();
        }

        public EventSearchDialog(string connectionString)
        {
            InitializeComponent();
            BoundControl(connectionString);
            Form = FormDataAccess.GetForms();
            Status = StatusDataAccess.GetStatuses();
            Event1 = new Event();
            FillForms();
            FillStatuses();
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
        private void FillForms()
        {
            cbForm.ValueMember = "ID";
            cbForm.DisplayMember = "Name";
            List<EForm> cbFormDataSource = new List<EForm>();
            cbFormDataSource.AddRange(Form);
            cbFormDataSource.Insert(0, new EForm() { ID = -1, Name = "Любой вид" });
            cbForm.DataSource = cbFormDataSource;
        }

        private void FillStatuses()
        {
            cbStatus.ValueMember = "ID";
            cbStatus.DisplayMember = "Name";
            List<Status> cbFormDataSource = new List<Status>();
            cbFormDataSource.AddRange(Status);
            cbFormDataSource.Insert(0, new Status() { ID = -1, Name = "Любой Статус" });
            cbStatus.DataSource = cbFormDataSource;
        }

        private EForm GetFormComboBox()
        {
            EForm Form = cbForm.SelectedItem as EForm;
            if (Form.ID == -1)
                return null;
            return Form;
        }

        private Status GetStatusComboBox()
        {
            Status Status = cbStatus.SelectedItem as Status;
            if (Status.ID == -1)
                return null;
            return Status;
        }

        private List<Event> GetSelectedEvents()
        {
            if (dgvEvent.SelectedRows == null || dgvEvent.SelectedRows.Count == 0)
                return null;
            List<Event> result = new List<Event>();
            foreach (DataGridViewRow row in dgvEvent.SelectedRows)
            {
                result.Add(dgvEvent.SelectedRows[0].DataBoundItem as Event);
            }
            return result;
        }
        private Event GetSelectedEvent()
        {
            if (dgvEvent.SelectedRows == null || dgvEvent.SelectedRows.Count == 0)
                return null;
            return (dgvEvent.SelectedRows[0].DataBoundItem as Event);
        }

        private bool CheckEmpty()
        {
            if (Event1.ID == 0 && String.IsNullOrEmpty(Event1.Name) &&
                    String.IsNullOrEmpty(Event1.StartTime) && (Event1.Form == null) &&
                    (Event1.Status == null) && String.IsNullOrEmpty(Event1.EndTime)
                    && String.IsNullOrEmpty(Event1.Info) && String.IsNullOrEmpty(Event1.Result))

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
                MessageBox.Show("Id мероприятия должно отличаться от 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime d = new DateTime();
            if (DateTime.TryParse(tbStartDT.Text, out d) == false && !String.IsNullOrEmpty(tbStartDT.Text))
            {
                MessageBox.Show("Дата и время начала введены неверно", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DateTime.TryParse(tbEndDT.Text, out d) == false && !String.IsNullOrEmpty(tbEndDT.Text))
            {
                MessageBox.Show("Дата и время завершения введены неверно", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!String.IsNullOrEmpty(tbID.Text))
                Event1.ID = Convert.ToInt32(tbID.Text);
            else
                Event1.ID = 0;
            Event1.Name = tbName.Text;
            Event1.StartTime = tbStartDT.Text;
            Event1.EndTime = tbEndDT.Text;
            Event1.Info = tbInfo.Text;
            Event1.Result = tbResult.Text;
            Event1.Status = GetStatusComboBox();
            Event1.Form = GetFormComboBox();
            if (CheckEmpty())
            {
                MessageBox.Show("Данные для поиска не введены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgvEvent.DataSource = EventDataAccess.SearchEvent(Event1);
        }

        private void edtbtn_Click(object sender, EventArgs e)
        {
            var Status = StatusDataAccess.GetStatuses();
            var Form = FormDataAccess.GetForms();
            Event selectedEvent = GetSelectedEvent();
            int oldID = selectedEvent.ID;
            if (selectedEvent == null)
            {
                MessageBox.Show("Мероприятие не выбрано", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (CheckEmpty())
                { dgvEvent.DataSource = EventDataAccess.GetEvents(); }
                else
                { 
                    dgvEvent.DataSource = EventDataAccess.SearchEvent(Event1);
                }
            }
        }

        private void dtbtn_Click(object sender, EventArgs e)
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
                if (CheckEmpty())
                { dgvEvent.DataSource = EventDataAccess.GetEvents(); }
                else
                {
                    dgvEvent.DataSource = EventDataAccess.SearchEvent(Event1);
                }
            }
        }

        private void dpbtn_Click(object sender, EventArgs e)
        {
            dgvEvent.DataSource = EventDataAccess.GetEvents();
            Event1 = new Event();
            Event1.ID = 0;
            tbID.Text = "";
            tbName.Text = "";
            tbResult.Text = "";
            tbInfo.Text = "";
            tbStartDT.Text = "";
            tbEndDT.Text = "";
            FillForms();
            FillStatuses();
        }

        private void tbID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }
    }
}
