namespace CapsLockTone
{
    partial class OptionsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TrackBar trackBarFrequency;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelVolumeValue;
        private System.Windows.Forms.Label labelFrequencyValue;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;

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
            trackBarFrequency = new TrackBar();
            label1 = new Label();
            trackBarVolume = new TrackBar();
            label2 = new Label();
            labelVolumeValue = new Label();
            labelFrequencyValue = new Label();
            buttonOK = new Button();
            buttonCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)trackBarFrequency).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarVolume).BeginInit();
            SuspendLayout();
            // 
            // trackBarFrequency
            // 
            trackBarFrequency.Location = new Point(120, 20);
            trackBarFrequency.Name = "trackBarFrequency";   
            trackBarFrequency.Size = new Size(100, 45);
            trackBarFrequency.TabIndex = 0;
            trackBarFrequency.Minimum = 0;
            trackBarFrequency.Maximum = 500;
            trackBarFrequency.TickFrequency = 50;
            trackBarFrequency.Value = 150;
            trackBarFrequency.Scroll += trackBarFrequency_Scroll;
            trackBarFrequency.MouseUp += trackBarFrequency_MouseUp;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 22);
            label1.Name = "label1";
            label1.Size = new Size(94, 15);
            label1.TabIndex = 1;
            label1.Text = "Tone Frequency:";
            // 
            // labelFrequencyValue
            // 
            labelFrequencyValue.AutoSize = true;
            labelFrequencyValue.Location = new Point(225, 22);
            labelFrequencyValue.Name = "labelFrequencyValue";
            labelFrequencyValue.Size = new Size(34, 15);
            labelFrequencyValue.TabIndex = 8;
            labelFrequencyValue.Text = "150";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 65);
            label2.Name = "label2";
            label2.Size = new Size(77, 15);
            label2.TabIndex = 5;
            label2.Text = "Tone Volume:";
            // 
            // trackBarVolume
            // 
            trackBarVolume.Location = new Point(120, 60);
            trackBarVolume.Name = "trackBarVolume";
            trackBarVolume.Size = new Size(100, 45);
            trackBarVolume.TabIndex = 6;
            trackBarVolume.Minimum = 0;
            trackBarVolume.Maximum = 50;
            trackBarVolume.TickFrequency = 10;
            trackBarVolume.Value = 2;
            trackBarVolume.Scroll += trackBarVolume_Scroll;
            trackBarVolume.MouseUp += trackBarVolume_MouseUp;
            // 
            // labelVolumeValue
            // 
            labelVolumeValue.AutoSize = true;
            labelVolumeValue.Location = new Point(225, 65);
            labelVolumeValue.Name = "labelVolumeValue";
            labelVolumeValue.Size = new Size(34, 15);
            labelVolumeValue.TabIndex = 7;
            labelVolumeValue.Text = "0.02";
            // 
            // buttonOK
            // 
            buttonOK.Location = new Point(44, 110);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(75, 23);
            buttonOK.TabIndex = 2;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(125, 110);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 3;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // OptionsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 151);
            Controls.Add(labelFrequencyValue);
            Controls.Add(labelVolumeValue);
            Controls.Add(trackBarVolume);
            Controls.Add(label2);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Controls.Add(label1);
            Controls.Add(trackBarFrequency);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "OptionsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Options";
            ((System.ComponentModel.ISupportInitialize)trackBarFrequency).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarVolume).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}