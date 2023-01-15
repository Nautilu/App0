
namespace App0.Forms
{
    partial class EventMemberAddEditDialog
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
            this.cbEvent = new System.Windows.Forms.ComboBox();
            this.cbMember = new System.Windows.Forms.ComboBox();
            this.EventLabel = new System.Windows.Forms.Label();
            this.MemberLabel = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbEvent
            // 
            this.cbEvent.FormattingEnabled = true;
            this.cbEvent.Location = new System.Drawing.Point(151, 12);
            this.cbEvent.Name = "cbEvent";
            this.cbEvent.Size = new System.Drawing.Size(370, 21);
            this.cbEvent.TabIndex = 0;
            // 
            // cbMember
            // 
            this.cbMember.FormattingEnabled = true;
            this.cbMember.Location = new System.Drawing.Point(151, 49);
            this.cbMember.Name = "cbMember";
            this.cbMember.Size = new System.Drawing.Size(370, 21);
            this.cbMember.TabIndex = 1;
            // 
            // EventLabel
            // 
            this.EventLabel.AutoSize = true;
            this.EventLabel.Location = new System.Drawing.Point(28, 15);
            this.EventLabel.Name = "EventLabel";
            this.EventLabel.Size = new System.Drawing.Size(75, 13);
            this.EventLabel.TabIndex = 2;
            this.EventLabel.Text = "Мероприятие";
            // 
            // MemberLabel
            // 
            this.MemberLabel.AutoSize = true;
            this.MemberLabel.Location = new System.Drawing.Point(28, 52);
            this.MemberLabel.Name = "MemberLabel";
            this.MemberLabel.Size = new System.Drawing.Size(55, 13);
            this.MemberLabel.TabIndex = 3;
            this.MemberLabel.Text = "Участник";
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(151, 92);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(125, 46);
            this.OK.TabIndex = 4;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(396, 92);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(125, 46);
            this.Cancel.TabIndex = 5;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // EventMemberAddEditDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 143);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.MemberLabel);
            this.Controls.Add(this.EventLabel);
            this.Controls.Add(this.cbMember);
            this.Controls.Add(this.cbEvent);
            this.Name = "EventMemberAddEditDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EventMemberAddEditDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbEvent;
        private System.Windows.Forms.ComboBox cbMember;
        private System.Windows.Forms.Label EventLabel;
        private System.Windows.Forms.Label MemberLabel;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
    }
}