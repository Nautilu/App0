
namespace App0.Forms
{
    partial class EventSearchDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbInfo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.cbForm = new System.Windows.Forms.ComboBox();
            this.tbEndDT = new System.Windows.Forms.TextBox();
            this.tbStartDT = new System.Windows.Forms.TextBox();
            this.lbStatus = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ebdLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvEvent = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Event = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Info = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EventForm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EventStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scbtn = new System.Windows.Forms.Button();
            this.edtbtn = new System.Windows.Forms.Button();
            this.dpbtn = new System.Windows.Forms.Button();
            this.dtbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvent)).BeginInit();
            this.SuspendLayout();
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(89, 6);
            this.tbID.MaxLength = 50;
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(299, 20);
            this.tbID.TabIndex = 39;
            this.tbID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbID_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "ID";
            // 
            // tbInfo
            // 
            this.tbInfo.Location = new System.Drawing.Point(89, 79);
            this.tbInfo.MaxLength = 150;
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.Size = new System.Drawing.Size(299, 20);
            this.tbInfo.TabIndex = 37;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Информация";
            // 
            // tbResult
            // 
            this.tbResult.Location = new System.Drawing.Point(474, 115);
            this.tbResult.MaxLength = 100;
            this.tbResult.Name = "tbResult";
            this.tbResult.Size = new System.Drawing.Size(299, 20);
            this.tbResult.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(401, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Результат";
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(474, 74);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(299, 21);
            this.cbStatus.TabIndex = 33;
            // 
            // cbForm
            // 
            this.cbForm.FormattingEnabled = true;
            this.cbForm.Location = new System.Drawing.Point(89, 116);
            this.cbForm.Name = "cbForm";
            this.cbForm.Size = new System.Drawing.Size(299, 21);
            this.cbForm.TabIndex = 32;
            // 
            // tbEndDT
            // 
            this.tbEndDT.Location = new System.Drawing.Point(474, 41);
            this.tbEndDT.MaxLength = 50;
            this.tbEndDT.Name = "tbEndDT";
            this.tbEndDT.Size = new System.Drawing.Size(299, 20);
            this.tbEndDT.TabIndex = 31;
            // 
            // tbStartDT
            // 
            this.tbStartDT.Location = new System.Drawing.Point(474, 6);
            this.tbStartDT.MaxLength = 50;
            this.tbStartDT.Name = "tbStartDT";
            this.tbStartDT.Size = new System.Drawing.Size(299, 20);
            this.tbStartDT.TabIndex = 30;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(401, 82);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(41, 13);
            this.lbStatus.TabIndex = 29;
            this.lbStatus.Text = "Статус";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Вид";
            // 
            // ebdLabel
            // 
            this.ebdLabel.AutoSize = true;
            this.ebdLabel.Location = new System.Drawing.Point(398, 44);
            this.ebdLabel.Name = "ebdLabel";
            this.ebdLabel.Size = new System.Drawing.Size(70, 13);
            this.ebdLabel.TabIndex = 27;
            this.ebdLabel.Text = "Завершение";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(398, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Начало";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(89, 41);
            this.tbName.MaxLength = 50;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(299, 20);
            this.tbName.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Название";
            // 
            // dgvEvent
            // 
            this.dgvEvent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEvent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Event,
            this.Info,
            this.StartTime,
            this.EndTime,
            this.EventForm,
            this.EventStatus,
            this.Result});
            this.dgvEvent.Location = new System.Drawing.Point(0, 198);
            this.dgvEvent.Name = "dgvEvent";
            this.dgvEvent.Size = new System.Drawing.Size(782, 200);
            this.dgvEvent.TabIndex = 40;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Width = 40;
            // 
            // Event
            // 
            this.Event.DataPropertyName = "Name";
            this.Event.HeaderText = "Название";
            this.Event.Name = "Event";
            this.Event.Width = 125;
            // 
            // Info
            // 
            this.Info.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Info.DataPropertyName = "Info";
            this.Info.HeaderText = "Информация";
            this.Info.Name = "Info";
            // 
            // StartTime
            // 
            this.StartTime.DataPropertyName = "StartTime";
            this.StartTime.HeaderText = "Дата и время начала";
            this.StartTime.Name = "StartTime";
            this.StartTime.Width = 101;
            // 
            // EndTime
            // 
            this.EndTime.DataPropertyName = "EndTime";
            this.EndTime.HeaderText = "Дата и время завершения";
            this.EndTime.Name = "EndTime";
            this.EndTime.Width = 101;
            // 
            // EventForm
            // 
            this.EventForm.DataPropertyName = "FormName";
            this.EventForm.HeaderText = "Вид";
            this.EventForm.Name = "EventForm";
            // 
            // EventStatus
            // 
            this.EventStatus.DataPropertyName = "StatusName";
            this.EventStatus.HeaderText = "Статус";
            this.EventStatus.Name = "EventStatus";
            // 
            // Result
            // 
            this.Result.DataPropertyName = "Result";
            this.Result.HeaderText = "Результат";
            this.Result.Name = "Result";
            // 
            // scbtn
            // 
            this.scbtn.Location = new System.Drawing.Point(15, 146);
            this.scbtn.Name = "scbtn";
            this.scbtn.Size = new System.Drawing.Size(125, 46);
            this.scbtn.TabIndex = 41;
            this.scbtn.Text = "Найти";
            this.scbtn.UseVisualStyleBackColor = true;
            this.scbtn.Click += new System.EventHandler(this.scbtn_Click);
            // 
            // edtbtn
            // 
            this.edtbtn.Location = new System.Drawing.Point(263, 146);
            this.edtbtn.Name = "edtbtn";
            this.edtbtn.Size = new System.Drawing.Size(125, 46);
            this.edtbtn.TabIndex = 42;
            this.edtbtn.Text = "Изменить";
            this.edtbtn.UseVisualStyleBackColor = true;
            this.edtbtn.Click += new System.EventHandler(this.edtbtn_Click);
            // 
            // dpbtn
            // 
            this.dpbtn.Location = new System.Drawing.Point(648, 146);
            this.dpbtn.Name = "dpbtn";
            this.dpbtn.Size = new System.Drawing.Size(125, 46);
            this.dpbtn.TabIndex = 43;
            this.dpbtn.Text = "Сброс";
            this.dpbtn.UseVisualStyleBackColor = true;
            this.dpbtn.Click += new System.EventHandler(this.dpbtn_Click);
            // 
            // dtbtn
            // 
            this.dtbtn.Location = new System.Drawing.Point(474, 146);
            this.dtbtn.Name = "dtbtn";
            this.dtbtn.Size = new System.Drawing.Size(125, 46);
            this.dtbtn.TabIndex = 44;
            this.dtbtn.Text = "Удалить";
            this.dtbtn.UseVisualStyleBackColor = true;
            this.dtbtn.Click += new System.EventHandler(this.dtbtn_Click);
            // 
            // EventSearchDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 397);
            this.Controls.Add(this.dtbtn);
            this.Controls.Add(this.dpbtn);
            this.Controls.Add(this.edtbtn);
            this.Controls.Add(this.scbtn);
            this.Controls.Add(this.dgvEvent);
            this.Controls.Add(this.tbID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbInfo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbResult);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.cbForm);
            this.Controls.Add(this.tbEndDT);
            this.Controls.Add(this.tbStartDT);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ebdLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label2);
            this.Name = "EventSearchDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Найти мероприятие";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbResult;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.ComboBox cbForm;
        private System.Windows.Forms.TextBox tbEndDT;
        private System.Windows.Forms.TextBox tbStartDT;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label ebdLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvEvent;
        private System.Windows.Forms.Button scbtn;
        private System.Windows.Forms.Button edtbtn;
        private System.Windows.Forms.Button dpbtn;
        private System.Windows.Forms.Button dtbtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Event;
        private System.Windows.Forms.DataGridViewTextBoxColumn Info;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn EventForm;
        private System.Windows.Forms.DataGridViewTextBoxColumn EventStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Result;
    }
}