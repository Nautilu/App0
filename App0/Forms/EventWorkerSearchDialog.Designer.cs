
namespace App0.Forms
{
    partial class EventWorkerSearchDialog
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
            this.dpbtn = new System.Windows.Forms.Button();
            this.dtbtn = new System.Windows.Forms.Button();
            this.edtbtn = new System.Windows.Forms.Button();
            this.scbtn = new System.Windows.Forms.Button();
            this.dgvEventWorker = new System.Windows.Forms.DataGridView();
            this.Event = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Worker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbWorker = new System.Windows.Forms.ComboBox();
            this.cbEvent = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventWorker)).BeginInit();
            this.SuspendLayout();
            // 
            // dpbtn
            // 
            this.dpbtn.Location = new System.Drawing.Point(615, 33);
            this.dpbtn.Name = "dpbtn";
            this.dpbtn.Size = new System.Drawing.Size(125, 46);
            this.dpbtn.TabIndex = 19;
            this.dpbtn.Text = "Сброс";
            this.dpbtn.UseVisualStyleBackColor = true;
            this.dpbtn.Click += new System.EventHandler(this.dpbtn_Click);
            // 
            // dtbtn
            // 
            this.dtbtn.Location = new System.Drawing.Point(441, 33);
            this.dtbtn.Name = "dtbtn";
            this.dtbtn.Size = new System.Drawing.Size(125, 46);
            this.dtbtn.TabIndex = 18;
            this.dtbtn.Text = "Удалить";
            this.dtbtn.UseVisualStyleBackColor = true;
            this.dtbtn.Click += new System.EventHandler(this.dtbtn_Click);
            // 
            // edtbtn
            // 
            this.edtbtn.Location = new System.Drawing.Point(247, 33);
            this.edtbtn.Name = "edtbtn";
            this.edtbtn.Size = new System.Drawing.Size(125, 46);
            this.edtbtn.TabIndex = 17;
            this.edtbtn.Text = "Изменить";
            this.edtbtn.UseVisualStyleBackColor = true;
            this.edtbtn.Click += new System.EventHandler(this.edtbtn_Click);
            // 
            // scbtn
            // 
            this.scbtn.Location = new System.Drawing.Point(82, 33);
            this.scbtn.Name = "scbtn";
            this.scbtn.Size = new System.Drawing.Size(125, 46);
            this.scbtn.TabIndex = 16;
            this.scbtn.Text = "Найти";
            this.scbtn.UseVisualStyleBackColor = true;
            this.scbtn.Click += new System.EventHandler(this.scbtn_Click);
            // 
            // dgvEventWorker
            // 
            this.dgvEventWorker.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEventWorker.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Event,
            this.Worker});
            this.dgvEventWorker.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvEventWorker.Location = new System.Drawing.Point(0, 87);
            this.dgvEventWorker.Name = "dgvEventWorker";
            this.dgvEventWorker.Size = new System.Drawing.Size(752, 241);
            this.dgvEventWorker.TabIndex = 20;
            // 
            // Event
            // 
            this.Event.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Event.DataPropertyName = "EventName";
            this.Event.HeaderText = "Мероприятие";
            this.Event.Name = "Event";
            // 
            // Worker
            // 
            this.Worker.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Worker.DataPropertyName = "WorkerName";
            this.Worker.HeaderText = "Сотрудник";
            this.Worker.Name = "Worker";
            // 
            // cbWorker
            // 
            this.cbWorker.FormattingEnabled = true;
            this.cbWorker.Location = new System.Drawing.Point(441, 6);
            this.cbWorker.Name = "cbWorker";
            this.cbWorker.Size = new System.Drawing.Size(299, 21);
            this.cbWorker.TabIndex = 24;
            // 
            // cbEvent
            // 
            this.cbEvent.FormattingEnabled = true;
            this.cbEvent.Location = new System.Drawing.Point(82, 6);
            this.cbEvent.Name = "cbEvent";
            this.cbEvent.Size = new System.Drawing.Size(290, 21);
            this.cbEvent.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(380, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Сотрудник";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Мероприятие";
            // 
            // EventWorkerSearchDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 328);
            this.Controls.Add(this.cbWorker);
            this.Controls.Add(this.cbEvent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvEventWorker);
            this.Controls.Add(this.dpbtn);
            this.Controls.Add(this.dtbtn);
            this.Controls.Add(this.edtbtn);
            this.Controls.Add(this.scbtn);
            this.Name = "EventWorkerSearchDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Найти сотрудника, ответственного за мероприятие";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventWorker)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button dpbtn;
        private System.Windows.Forms.Button dtbtn;
        private System.Windows.Forms.Button edtbtn;
        private System.Windows.Forms.Button scbtn;
        private System.Windows.Forms.DataGridView dgvEventWorker;
        private System.Windows.Forms.DataGridViewTextBoxColumn Event;
        private System.Windows.Forms.DataGridViewTextBoxColumn Worker;
        private System.Windows.Forms.ComboBox cbWorker;
        private System.Windows.Forms.ComboBox cbEvent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}