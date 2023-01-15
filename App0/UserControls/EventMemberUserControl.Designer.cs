
namespace App0.UserControls
{
    partial class EventMemberUserControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvEventMember = new System.Windows.Forms.DataGridView();
            this.Event = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Member = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.scbtn = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.Edit = new System.Windows.Forms.Button();
            this.Add = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventMember)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvEventMember
            // 
            this.dgvEventMember.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEventMember.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Event,
            this.Member});
            this.dgvEventMember.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvEventMember.Location = new System.Drawing.Point(0, 83);
            this.dgvEventMember.Name = "dgvEventMember";
            this.dgvEventMember.Size = new System.Drawing.Size(860, 319);
            this.dgvEventMember.TabIndex = 0;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.scbtn);
            this.panel1.Controls.Add(this.Delete);
            this.panel1.Controls.Add(this.Edit);
            this.panel1.Controls.Add(this.Add);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(860, 77);
            this.panel1.TabIndex = 1;
            // 
            // scbtn
            // 
            this.scbtn.Location = new System.Drawing.Point(423, 15);
            this.scbtn.Name = "scbtn";
            this.scbtn.Size = new System.Drawing.Size(125, 46);
            this.scbtn.TabIndex = 4;
            this.scbtn.Text = "Поиск";
            this.scbtn.UseVisualStyleBackColor = true;
            this.scbtn.Click += new System.EventHandler(this.scbtn_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(292, 15);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(125, 46);
            this.Delete.TabIndex = 3;
            this.Delete.Text = "Удалить";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Edit
            // 
            this.Edit.Location = new System.Drawing.Point(161, 15);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(125, 46);
            this.Edit.TabIndex = 2;
            this.Edit.Text = "Изменить";
            this.Edit.UseVisualStyleBackColor = true;
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(30, 15);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(125, 46);
            this.Add.TabIndex = 0;
            this.Add.Text = "Добавить";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // EventMemberUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvEventMember);
            this.Name = "EventMemberUserControl";
            this.Size = new System.Drawing.Size(860, 402);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventMember)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEventMember;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Edit;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.DataGridViewTextBoxColumn Event;
        private System.Windows.Forms.DataGridViewTextBoxColumn Member;
        private System.Windows.Forms.Button scbtn;
    }
}
