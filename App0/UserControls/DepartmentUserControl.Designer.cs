
namespace App0.UserControls
{
    partial class DepartmentUserControl
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
            this.dgvDep = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dpbtn = new System.Windows.Forms.Button();
            this.scbtn = new System.Windows.Forms.Button();
            this.dtbtn = new System.Windows.Forms.Button();
            this.edtbtn = new System.Windows.Forms.Button();
            this.addbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDep)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDep
            // 
            this.dgvDep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDep.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Dep});
            this.dgvDep.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDep.Location = new System.Drawing.Point(0, 83);
            this.dgvDep.Name = "dgvDep";
            this.dgvDep.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDep.Size = new System.Drawing.Size(860, 313);
            this.dgvDep.TabIndex = 1;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Width = 50;
            // 
            // Dep
            // 
            this.Dep.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Dep.DataPropertyName = "Name";
            this.Dep.HeaderText = "Название отдела";
            this.Dep.Name = "Dep";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dpbtn);
            this.panel1.Controls.Add(this.scbtn);
            this.panel1.Controls.Add(this.dtbtn);
            this.panel1.Controls.Add(this.edtbtn);
            this.panel1.Controls.Add(this.addbtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(860, 77);
            this.panel1.TabIndex = 2;
            // 
            // dpbtn
            // 
            this.dpbtn.Location = new System.Drawing.Point(554, 15);
            this.dpbtn.Name = "dpbtn";
            this.dpbtn.Size = new System.Drawing.Size(125, 46);
            this.dpbtn.TabIndex = 5;
            this.dpbtn.Text = "Сброс";
            this.dpbtn.UseVisualStyleBackColor = true;
            this.dpbtn.Click += new System.EventHandler(this.dpbtn_Click);
            // 
            // scbtn
            // 
            this.scbtn.Location = new System.Drawing.Point(423, 15);
            this.scbtn.Name = "scbtn";
            this.scbtn.Size = new System.Drawing.Size(125, 46);
            this.scbtn.TabIndex = 5;
            this.scbtn.Text = "Поиск";
            this.scbtn.UseVisualStyleBackColor = true;
            this.scbtn.Click += new System.EventHandler(this.scbtn_Click);
            // 
            // dtbtn
            // 
            this.dtbtn.Location = new System.Drawing.Point(292, 15);
            this.dtbtn.Name = "dtbtn";
            this.dtbtn.Size = new System.Drawing.Size(125, 46);
            this.dtbtn.TabIndex = 4;
            this.dtbtn.Text = "Удалить";
            this.dtbtn.UseVisualStyleBackColor = true;
            this.dtbtn.Click += new System.EventHandler(this.dtbtn_Click);
            // 
            // edtbtn
            // 
            this.edtbtn.Location = new System.Drawing.Point(161, 15);
            this.edtbtn.Name = "edtbtn";
            this.edtbtn.Size = new System.Drawing.Size(125, 46);
            this.edtbtn.TabIndex = 3;
            this.edtbtn.Text = "Изменить";
            this.edtbtn.UseVisualStyleBackColor = true;
            this.edtbtn.Click += new System.EventHandler(this.edtbtn_Click);
            // 
            // addbtn
            // 
            this.addbtn.Location = new System.Drawing.Point(30, 15);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(125, 46);
            this.addbtn.TabIndex = 0;
            this.addbtn.Text = "Добавить";
            this.addbtn.UseVisualStyleBackColor = true;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // DepartmentUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvDep);
            this.Name = "DepartmentUserControl";
            this.Size = new System.Drawing.Size(860, 402);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDep)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDep;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button dtbtn;
        private System.Windows.Forms.Button edtbtn;
        private System.Windows.Forms.Button addbtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dep;
        private System.Windows.Forms.Button scbtn;
        private System.Windows.Forms.Button dpbtn;
    }
}
