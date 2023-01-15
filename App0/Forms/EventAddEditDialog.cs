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
    public partial class EventAddEditDialog : Form
    { 
        public Event Event { get; private set; } 
        private readonly List<EForm> Form;
        private readonly List<Status> Status;
        EventDataAccess EventDataAccess;
        public EventAddEditDialog(string connectionString, List<EForm> Form, List<Status> Status)
        {
            InitializeComponent();
            this.Form = Form;
            this.Status = Status;
            Event = new Event();
            EventDataAccess = new EventDataAccess(connectionString);
            FillForms();
            FillStatuses();
            Text = "Добавить мероприятие";
        }
        public EventAddEditDialog(string connectionString, Event Event, List<EForm> Form, List<Status> Status) : this(connectionString, Form, Status)
        {
            this.Event = Event;
            FillEvents();
            Text = "Редактировать мероприятие";
        }

        private void FillEvents()
        {
            tbID.Text = Event.ID.ToString();
            tbName.Text = Event.Name;
            tbStartDT.Text = Event.StartTime;
            tbEndDT.Text = Event.EndTime;
            tbInfo.Text = Event.Info;
            cbForm.SelectedItem = (Event.Form != null) ? Form.Where(t => t.ID == Event.Form.ID).FirstOrDefault() : null;
            cbStatus.SelectedItem = (Event.Status != null) ? Status.Where(t => t.ID == Event.Status.ID).FirstOrDefault() : null;
            tbResult.Text = Event.Result;
        }

        private void FillForms()
        {
            cbForm.ValueMember = "ID";
            cbForm.DisplayMember = "Name";
            List<EForm> cbFormDataSource = new List<EForm>();
            cbFormDataSource.AddRange(Form);
            cbForm.DataSource = cbFormDataSource;
        }

        private void FillStatuses()
        {
            cbStatus.ValueMember = "ID";
            cbStatus.DisplayMember = "Name";
            List<Status> cbFormDataSource = new List<Status>();
            cbFormDataSource.AddRange(Status);
            cbStatus.DataSource = cbFormDataSource;
        }
        private EForm GetFormComboBox()
        {
            EForm Form = cbForm.SelectedItem as EForm;
            return Form;
        }

        private Status GetStatusComboBox()
        {
            Status Status = cbStatus.SelectedItem as Status;
            return Status;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (GetFormComboBox() == null)
            {
                MessageBox.Show("Вид не выбран", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (GetStatusComboBox() == null)
            {
                MessageBox.Show("Статус не выбран", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime d = new DateTime();
            if (string.IsNullOrEmpty(tbStartDT.Text))
            {
               MessageBox.Show("Дата и время начала не введены", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return;
            }
            else
            {
               if (DateTime.TryParse(tbStartDT.Text, out d) == false)
               {
                   MessageBox.Show("Дата и время начала введены неверно", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   return;
               }
            }
            if (string.IsNullOrEmpty(tbEndDT.Text))
            {
                MessageBox.Show("Дата и время завершения не введены", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (DateTime.TryParse(tbEndDT.Text, out d) == false)
                {
                    MessageBox.Show("Дата и время завершения введены неверно", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (string.IsNullOrEmpty(tbID.Text))
            {
                MessageBox.Show("ID не введён", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
               
            }
            if (Convert.ToInt32(tbID.Text) == 0)
            {
                MessageBox.Show("Id отдела должно отличаться от 0", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (EventDataAccess.CheckID(Convert.ToInt32(tbID.Text)) && Convert.ToInt32(tbID.Text) != Event.ID)
            {
                MessageBox.Show("Мероприятие с таким ID уже существует", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Event.ID != Convert.ToInt32(tbID.Text) && Event.ID != 0)
            {
                if (MessageBox.Show("ID отдела было изменено, " +
                   "это действие может привести к удалению данных из других таблиц. " +
                   "Хотите продолжить?",
                   "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No)
                {
                    return;
                }
            }
            Event.ID = Convert.ToInt32(tbID.Text);
            Event.Name = tbName.Text;
            Event.StartTime = tbStartDT.Text;
            Event.EndTime = tbEndDT.Text;
            Event.Info = tbInfo.Text;
            Event.Form = GetFormComboBox();
            Event.Status = GetStatusComboBox();
            Event.Result = tbResult.Text;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void tbID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void tbDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 59) && e.KeyChar != 8 && (e.KeyChar != '.') 
                && e.KeyChar != ' ')
                e.Handled = true;
        }
    }
}
