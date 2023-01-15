
namespace App0.Forms
{
    partial class EventMemberSearchDialog
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
            this.MemberLabel = new System.Windows.Forms.Label();
            this.EventLabel = new System.Windows.Forms.Label();
            this.cbMember = new System.Windows.Forms.ComboBox();
            this.cbEvent = new System.Windows.Forms.ComboBox();
            this.dgvEventMember = new System.Windows.Forms.DataGridView();
            this.Event = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Member = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dpbtn = new System.Windows.Forms.Button();
            this.dtbtn = new System.Windows.Forms.Button();
            this.edtbtn = new System.Windows.Forms.Button();
            this.scbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventMember)).BeginInit();
            this.SuspendLayout();
            // 
            // MemberLabel
            // 
            this.MemberLabel.AutoSize = true;
            this.MemberLabel.Location = new System.Drawing.Point(380, 9);
            this.MemberLabel.Name = "MemberLabel";
            this.MemberLabel.Size = new System.Drawing.Size(55, 13);
            this.MemberLabel.TabIndex = 7;
            this.MemberLabel.Text = "Участник";
            // 
            // EventLabel
            // 
            this.EventLabel.AutoSize = true;
            this.EventLabel.Location = new System.Drawing.Point(1, 9);
            this.EventLabel.Name = "EventLabel";
            this.EventLabel.Size = new System.Drawing.Size(75, 13);
            this.EventLabel.TabIndex = 6;
            this.EventLabel.Text = "Мероприятие";
            // 
            // cbMember
            // 
            this.cbMember.FormattingEnabled = true;
            this.cbMember.Location = new System.Drawing.Point(441, 6);
            this.cbMember.Name = "cbMember";
            this.cbMember.Size = new System.Drawing.Size(299, 21);
            this.cbMember.TabIndex = 5;
            // 
            // cbEvent
            // 
            this.cbEvent.FormattingEnabled = true;
            this.cbEvent.Location = new System.Drawing.Point(82, 6);
            this.cbEvent.Name = "cbEvent";
            this.cbEvent.Size = new System.Drawing.Size(290, 21);
            this.cbEvent.TabIndex = 4;
            // 
            // dgvEventMember
            // 
            this.dgvEventMember.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEventMember.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Event,
            this.Member});
            this.dgvEventMember.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvEventMember.Location = new System.Drawing.Point(0, 85);
            this.dgvEventMember.Name = "dgvEventMember";
            this.dgvEventMember.Size = new System.Drawing.Size(752, 243);
            this.dgvEventMember.TabIndex = 8;
            // 
            // Event
            // 
            this.Event.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Event.DataPropertyName = "EventName";
            this.Event.HeaderText = "Мероприятие";
            this.Event.Name = "Event";
            // 
            // Member
            // 
            this.Member.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Member.DataPropertyName = "MemberName";
            this.Member.HeaderText = "Участник";
            this.Member.Name = "Member";
            // 
            // dpbtn
            // 
            this.dpbtn.Location = new System.Drawing.Point(615, 33);
            this.dpbtn.Name = "dpbtn";
            this.dpbtn.Size = new System.Drawing.Size(125, 46);
            this.dpbtn.TabIndex = 15;
            this.dpbtn.Text = "Сброс";
            this.dpbtn.UseVisualStyleBackColor = true;
            this.dpbtn.Click += new System.EventHandler(this.dpbtn_Click);
            // 
            // dtbtn
            // 
            this.dtbtn.Location = new System.Drawing.Point(441, 33);
            this.dtbtn.Name = "dtbtn";
            this.dtbtn.Size = new System.Drawing.Size(125, 46);
            this.dtbtn.TabIndex = 14;
            this.dtbtn.Text = "Удалить";
            this.dtbtn.UseVisualStyleBackColor = true;
            this.dtbtn.Click += new System.EventHandler(this.dtbtn_Click);
            // 
            // edtbtn
            // 
            this.edtbtn.Location = new System.Drawing.Point(247, 33);
            this.edtbtn.Name = "edtbtn";
            this.edtbtn.Size = new System.Drawing.Size(125, 46);
            this.edtbtn.TabIndex = 13;
            this.edtbtn.Text = "Изменить";
            this.edtbtn.UseVisualStyleBackColor = true;
            this.edtbtn.Click += new System.EventHandler(this.edtbtn_Click);
            // 
            // scbtn
            // 
            this.scbtn.Location = new System.Drawing.Point(82, 33);
            this.scbtn.Name = "scbtn";
            this.scbtn.Size = new System.Drawing.Size(125, 46);
            this.scbtn.TabIndex = 12;
            this.scbtn.Text = "Найти";
            this.scbtn.UseVisualStyleBackColor = true;
            this.scbtn.Click += new System.EventHandler(this.scbtn_Click);
            // 
            // EventMemberSearchDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 328);
            this.Controls.Add(this.dpbtn);
            this.Controls.Add(this.dtbtn);
            this.Controls.Add(this.edtbtn);
            this.Controls.Add(this.scbtn);
            this.Controls.Add(this.dgvEventMember);
            this.Controls.Add(this.MemberLabel);
            this.Controls.Add(this.EventLabel);
            this.Controls.Add(this.cbMember);
            this.Controls.Add(this.cbEvent);
            this.Name = "EventMemberSearchDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Найти участников мероприятий";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventMember)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MemberLabel;
        private System.Windows.Forms.Label EventLabel;
        private System.Windows.Forms.ComboBox cbMember;
        private System.Windows.Forms.ComboBox cbEvent;
        private System.Windows.Forms.DataGridView dgvEventMember;
        private System.Windows.Forms.DataGridViewTextBoxColumn Event;
        private System.Windows.Forms.DataGridViewTextBoxColumn Member;
        private System.Windows.Forms.Button dpbtn;
        private System.Windows.Forms.Button dtbtn;
        private System.Windows.Forms.Button edtbtn;
        private System.Windows.Forms.Button scbtn;
    }
}