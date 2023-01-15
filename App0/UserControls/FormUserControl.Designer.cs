
namespace App0.UserControls
{
    partial class FormUserControl
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
            this.dgvForm = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Form = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.scbtn = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.Edit = new System.Windows.Forms.Button();
            this.Add = new System.Windows.Forms.Button();
            this.dpbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvForm)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvForm
            // 
            this.dgvForm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvForm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Form});
            this.dgvForm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvForm.Location = new System.Drawing.Point(0, 83);
            this.dgvForm.Name = "dgvForm";
            this.dgvForm.Size = new System.Drawing.Size(860, 319);
            this.dgvForm.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Width = 50;
            // 
            // Form
            // 
            this.Form.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Form.DataPropertyName = "Name";
            this.Form.HeaderText = "Вид";
            this.Form.Name = "Form";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dpbtn);
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
            this.scbtn.TabIndex = 3;
            this.scbtn.Text = "Поиск";
            this.scbtn.UseVisualStyleBackColor = true;
            this.scbtn.Click += new System.EventHandler(this.scbtn_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(292, 15);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(125, 46);
            this.Delete.TabIndex = 2;
            this.Delete.Text = "Удалить";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Edit
            // 
            this.Edit.Location = new System.Drawing.Point(161, 15);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(125, 46);
            this.Edit.TabIndex = 1;
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
            // dpbtn
            // 
            this.dpbtn.Location = new System.Drawing.Point(554, 15);
            this.dpbtn.Name = "dpbtn";
            this.dpbtn.Size = new System.Drawing.Size(125, 46);
            this.dpbtn.TabIndex = 6;
            this.dpbtn.Text = "Сброс";
            this.dpbtn.UseVisualStyleBackColor = true;
            this.dpbtn.Click += new System.EventHandler(this.dpbtn_Click);
            // 
            // FormUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvForm);
            this.Name = "FormUserControl";
            this.Size = new System.Drawing.Size(860, 402);
            ((System.ComponentModel.ISupportInitialize)(this.dgvForm)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvForm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Edit;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button scbtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Form;
        private System.Windows.Forms.Button dpbtn;
    }
}
