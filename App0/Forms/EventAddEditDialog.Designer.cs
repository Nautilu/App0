
namespace App0.Forms
{
    partial class EventAddEditDialog
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
            this.label2 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ebdLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbStartDT = new System.Windows.Forms.TextBox();
            this.tbEndDT = new System.Windows.Forms.TextBox();
            this.cbForm = new System.Windows.Forms.ComboBox();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.lbStatus = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbInfo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Название";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(193, 49);
            this.tbName.MaxLength = 50;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(370, 20);
            this.tbName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Дата и время начала";
            // 
            // ebdLabel
            // 
            this.ebdLabel.AutoSize = true;
            this.ebdLabel.Location = new System.Drawing.Point(28, 126);
            this.ebdLabel.Name = "ebdLabel";
            this.ebdLabel.Size = new System.Drawing.Size(142, 13);
            this.ebdLabel.TabIndex = 5;
            this.ebdLabel.Text = "Дата и время завершения";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Вид";
            // 
            // tbStartDT
            // 
            this.tbStartDT.Location = new System.Drawing.Point(193, 86);
            this.tbStartDT.MaxLength = 50;
            this.tbStartDT.Name = "tbStartDT";
            this.tbStartDT.Size = new System.Drawing.Size(370, 20);
            this.tbStartDT.TabIndex = 10;
            this.tbStartDT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDT_KeyPress);
            // 
            // tbEndDT
            // 
            this.tbEndDT.Location = new System.Drawing.Point(193, 123);
            this.tbEndDT.MaxLength = 50;
            this.tbEndDT.Name = "tbEndDT";
            this.tbEndDT.Size = new System.Drawing.Size(370, 20);
            this.tbEndDT.TabIndex = 11;
            this.tbEndDT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDT_KeyPress);
            // 
            // cbForm
            // 
            this.cbForm.FormattingEnabled = true;
            this.cbForm.Location = new System.Drawing.Point(193, 197);
            this.cbForm.Name = "cbForm";
            this.cbForm.Size = new System.Drawing.Size(370, 21);
            this.cbForm.TabIndex = 14;
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(193, 308);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(125, 46);
            this.OK.TabIndex = 16;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(438, 308);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(125, 46);
            this.Cancel.TabIndex = 17;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(28, 237);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(41, 13);
            this.lbStatus.TabIndex = 9;
            this.lbStatus.Text = "Статус";
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(193, 234);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(370, 21);
            this.cbStatus.TabIndex = 15;
            // 
            // tbResult
            // 
            this.tbResult.Location = new System.Drawing.Point(193, 271);
            this.tbResult.MaxLength = 100;
            this.tbResult.Name = "tbResult";
            this.tbResult.Size = new System.Drawing.Size(370, 20);
            this.tbResult.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 274);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Результат";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Информация";
            // 
            // tbInfo
            // 
            this.tbInfo.Location = new System.Drawing.Point(193, 160);
            this.tbInfo.MaxLength = 150;
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.Size = new System.Drawing.Size(370, 20);
            this.tbInfo.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "ID";
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(193, 12);
            this.tbID.MaxLength = 50;
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(370, 20);
            this.tbID.TabIndex = 23;
            this.tbID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbID_KeyPress);
            // 
            // EventAddEditDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 357);
            this.Controls.Add(this.tbID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbInfo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbResult);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
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
            this.Name = "EventAddEditDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EventAddEditDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ebdLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbStartDT;
        private System.Windows.Forms.TextBox tbEndDT;
        private System.Windows.Forms.ComboBox cbForm;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.TextBox tbResult;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbID;
    }
}