using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using CapsLockTone.Properties;

namespace CapsLockTone
{
    public partial class Form1 : Form
    {
        private NotifyIcon trayIcon;
        private ContextMenuStrip trayMenu;
        private System.Windows.Forms.Timer capsLockTimer;
        private WaveOutEvent waveOut;
        private SignalGenerator signalGenerator;
        private bool isTonePlaying = false;
        private bool isEnabled = true;
        private bool capsLockOn = false;
        private ToolStripMenuItem enableDisableItem;

        private int toneFrequency
        {
            get => Settings.Default.ToneFrequency;
            set
            {
                Settings.Default.ToneFrequency = value;
                Settings.Default.Save();
            }
        }

        private double toneVolume
        {
            get => Settings.Default.ToneVolume;
            set
            {
                Settings.Default.ToneVolume = value;
                Settings.Default.Save();
            }
        }

        public Form1()
        {
            InitializeComponent();
            InitializeTray();
            capsLockTimer = new System.Windows.Forms.Timer();
            capsLockTimer.Interval = 100; // ms
            capsLockTimer.Tick += CapsLockTimer_Tick;
            capsLockTimer.Start();
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            this.Visible = false;
            trayIcon.Icon = Properties.Resources.arrow_icon;
        }

        private void InitializeTray()
        {
            trayMenu = new ContextMenuStrip();
            enableDisableItem = new ToolStripMenuItem(isEnabled ? "Disable" : "Enable", null, (s, e) =>
            {
                isEnabled = !isEnabled;
                enableDisableItem.Text = isEnabled ? "Disable" : "Enable";
                if (!isEnabled) StopTone();
            });
            trayMenu.Items.Add(enableDisableItem);
            trayMenu.Items.Add("Options...", null, (s, e) => ShowOptions());
            trayMenu.Items.Add("About", null, (s, e) => ShowAbout());
            trayMenu.Items.Add("Quit", null, (s, e) => Application.Exit());

            trayIcon = new NotifyIcon();
            trayIcon.Text = "CapsLock Tone";
            trayIcon.Icon = SystemIcons.Information;
            trayIcon.ContextMenuStrip = trayMenu;
            trayIcon.Visible = true;
        }

        private void CapsLockTimer_Tick(object sender, EventArgs e)
        {
            bool currentCapsLock = Control.IsKeyLocked(Keys.CapsLock);
            if (isEnabled && currentCapsLock && !isTonePlaying)
            {
                StartTone();
            }
            else if ((!currentCapsLock || !isEnabled) && isTonePlaying)
            {
                StopTone();
            }
            capsLockOn = currentCapsLock;
        }

        private void StartTone()
        {
            if (waveOut != null) return; // Already playing

            isTonePlaying = true;
            signalGenerator = new SignalGenerator()
            {
                Gain = toneVolume, // Use persisted volume
                Frequency = toneFrequency,
                Type = SignalGeneratorType.Sin
            };
            waveOut = new WaveOutEvent();
            waveOut.Init(signalGenerator);
            waveOut.Play();
        }

        private void StopTone()
        {
            isTonePlaying = false;
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut.Dispose();
                waveOut = null;
                signalGenerator = null;
            }
        }

        private void ShowOptions()
        {
            bool wasPlaying = isTonePlaying;
            int originalFrequency = toneFrequency;
            double originalVolume = toneVolume;
            void Preview(int freq, double vol)
            {
                toneFrequency = freq;
                toneVolume = vol;
                if (isTonePlaying)
                {
                    StopTone();
                    StartTone();
                }
            }
            using (var options = new OptionsForm(toneFrequency, toneVolume, wasPlaying, Preview))
            {
                if (options.ShowDialog() == DialogResult.OK)
                {
                    toneFrequency = options.SelectedFrequency;
                    toneVolume = options.SelectedVolume;
                }
                else
                {
                    // Revert to original if cancelled
                    toneFrequency = originalFrequency;
                    toneVolume = originalVolume;
                    if (wasPlaying)
                    {
                        StopTone();
                        StartTone();
                    }
                }
            }
        }

        private void ShowAbout()
        {
            using (var about = new AboutForm())
            {
                about.ShowDialog();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            trayIcon.Visible = false;
            base.OnFormClosing(e);
        }
    }
}
