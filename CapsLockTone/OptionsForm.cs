using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CapsLockTone
{
    public partial class OptionsForm : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int SelectedFrequency { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public double SelectedVolume { get; set; }

        private int originalFrequency;
        private double originalVolume;
        private bool wasPlaying;
        private Action<int, double>? previewCallback;

        public OptionsForm(int currentFrequency, double currentVolume, bool isPlaying, Action<int, double>? onPreview = null)
        {
            InitializeComponent();
            originalFrequency = currentFrequency;
            originalVolume = currentVolume;
            wasPlaying = isPlaying;
            previewCallback = onPreview;
            trackBarFrequency.Value = Math.Min(Math.Max(currentFrequency, trackBarFrequency.Minimum), trackBarFrequency.Maximum);
            labelFrequencyValue.Text = trackBarFrequency.Value.ToString();
            int trackBarValue = (int)Math.Round(currentVolume * 100);
            trackBarVolume.Value = Math.Min(Math.Max(trackBarValue, trackBarVolume.Minimum), trackBarVolume.Maximum);
            labelVolumeValue.Text = (trackBarVolume.Value / 100.0).ToString("0.00");
            trackBarFrequency.Scroll += trackBarFrequency_Scroll;
            trackBarFrequency.MouseUp += trackBarFrequency_MouseUp;
            trackBarVolume.Scroll += trackBarVolume_Scroll;
            trackBarVolume.MouseUp += trackBarVolume_MouseUp;
        }

        private void trackBarFrequency_Scroll(object sender, EventArgs e)
        {
            labelFrequencyValue.Text = trackBarFrequency.Value.ToString();
        }

        private void trackBarFrequency_MouseUp(object sender, MouseEventArgs e)
        {
            if (wasPlaying && previewCallback != null)
            {
                previewCallback.Invoke(trackBarFrequency.Value, trackBarVolume.Value / 100.0);
            }
        }

        private void trackBarVolume_Scroll(object sender, EventArgs e)
        {
            labelVolumeValue.Text = (trackBarVolume.Value / 100.0).ToString("0.00");
        }

        private void trackBarVolume_MouseUp(object sender, MouseEventArgs e)
        {
            if (wasPlaying && previewCallback != null)
            {
                previewCallback.Invoke(trackBarFrequency.Value, trackBarVolume.Value / 100.0);
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            SelectedFrequency = trackBarFrequency.Value;
            SelectedVolume = trackBarVolume.Value / 100.0;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (wasPlaying && previewCallback != null)
            {
                // revert to original values
                previewCallback.Invoke(originalFrequency, originalVolume);
            }
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}