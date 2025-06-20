namespace CapsLockTone
{
    partial class AboutForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelAppName;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Button buttonOK;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            labelAppName = new System.Windows.Forms.Label();
            labelAuthor = new System.Windows.Forms.Label();
            labelDate = new System.Windows.Forms.Label();
            buttonOK = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // labelAppName
            // 
            labelAppName.AutoSize = true;
            labelAppName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelAppName.Location = new System.Drawing.Point(30, 20);
            labelAppName.Name = "labelAppName";
            labelAppName.Size = new System.Drawing.Size(210, 21);
            labelAppName.TabIndex = 0;
            labelAppName.Text = "CapsLock Tone Generator";
            // 
            // labelAuthor
            // 
            labelAuthor.AutoSize = true;
            labelAuthor.Location = new System.Drawing.Point(30, 55);
            labelAuthor.Name = "labelAuthor";
            labelAuthor.Size = new System.Drawing.Size(120, 15);
            labelAuthor.TabIndex = 1;
            labelAuthor.Text = "Author: John Merritt";
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Location = new System.Drawing.Point(30, 80);
            labelDate.Name = "labelDate";
            labelDate.Size = new System.Drawing.Size(120, 15);
            labelDate.TabIndex = 2;
            labelDate.Text = "Created: 2024-06-08";
            // 
            // buttonOK
            // 
            buttonOK.Location = new System.Drawing.Point(90, 110);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new System.Drawing.Size(75, 23);
            buttonOK.TabIndex = 3;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(270, 150);
            Controls.Add(labelAppName);
            Controls.Add(labelAuthor);
            Controls.Add(labelDate);
            Controls.Add(buttonOK);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "About";
            ResumeLayout(false);
            PerformLayout();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
