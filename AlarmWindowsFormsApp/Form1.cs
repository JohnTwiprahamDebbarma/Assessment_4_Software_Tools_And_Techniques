using System;
using System.Drawing;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace AlarmWindowsFormsApp
{
    public partial class Form1 : Form
    {
        // I'm declaring delegate and event for the alarm
        public delegate void AlarmEventHandler(object source, EventArgs args);
        public event AlarmEventHandler RaiseAlarm;

        // I'm creating variables to track the alarm state
        private DateTime targetTime;
        private bool isRunning = false;
        private Timer timer;
        private Random random;

        public Form1()
        {
            InitializeComponent();

            // I'm initializing the timer for checking time and changing colors
            timer = new Timer();
            timer.Interval = 1000; // 1 second
            timer.Tick += Timer_Tick;

            // I'm initializing the random number generator for colors
            random = new Random();

            // I'm subscribing to my own event (self-subscription pattern)
            RaiseAlarm += Ring_alarm;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // No functionality here
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {
            // I'm leaving this event handler empty as we don't need any functionality when clicking the status label
        }

        // I'm adding a click event handler for the Start button
        private void btnStart_Click(object sender, EventArgs e)
        {
            // I'm validating the user input
            if (ValidateTimeInput(txtTimeInput.Text, out targetTime))
            {
                // I'm checking if the time is in the past
                if (targetTime < DateTime.Now)
                {
                    MessageBox.Show("The time you entered is in the past. Please enter a future time.",
                        "Invalid Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // I'm updating the UI to show the alarm is running
                lblStatus.Text = $"Status: Alarm set for {targetTime.ToString("HH:mm:ss")}";
                btnStart.Enabled = false;
                txtTimeInput.Enabled = false;
                isRunning = true;

                // I'm starting the timer
                timer.Start();
            }
            else
            {
                MessageBox.Show("Invalid time format. Please use HH:MM:SS format.",
                    "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // I'm updating the current time display
            DateTime currentTime = DateTime.Now;
            lblCurrentTime.Text = $"Current time: {currentTime.ToString("HH:mm:ss")}";

            // I'm checking if the alarm should go off
            if (isRunning)
            {
                // I'm changing the background color every second
                ChangeBackgroundColor();

                // I'm checking if current time matches the target time
                if (currentTime.Hour == targetTime.Hour &&
                    currentTime.Minute == targetTime.Minute &&
                    currentTime.Second == targetTime.Second)
                {
                    // I'm raising the event when times match
                    if (RaiseAlarm != null)
                    {
                        RaiseAlarm(this, EventArgs.Empty);
                    }
                }
            }
        }

        private void ChangeBackgroundColor()
        {
            // I'm generating a random light color for better text visibility
            int red = random.Next(100, 256);
            int green = random.Next(100, 256);
            int blue = random.Next(100, 256);

            this.BackColor = Color.FromArgb(red, green, blue);
        }

        private void Ring_alarm(object source, EventArgs e)
        {
            // I'm stopping the timer and color changes
            timer.Stop();
            isRunning = false;

            // I'm resetting the form background to default
            this.BackColor = SystemColors.Control;

            // I'm updating the UI
            lblStatus.Text = "Status: Alarm triggered!";
            btnStart.Enabled = true;
            txtTimeInput.Enabled = true;

            // I'm displaying the alarm message
            MessageBox.Show("ALARM! ALARM! It's time to wake up!",
                "Alarm", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool ValidateTimeInput(string timeInput, out DateTime result)
        {
            // I'm validating the time format
            bool isValid = DateTime.TryParseExact(
                timeInput,
                "HH:mm:ss",
                null,
                System.Globalization.DateTimeStyles.None,
                out DateTime parsedTime);

            if (isValid)
            {
                // I'm creating a new DateTime with today's date and user's time
                DateTime today = DateTime.Today;
                result = new DateTime(
                    today.Year, today.Month, today.Day,
                    parsedTime.Hour, parsedTime.Minute, parsedTime.Second
                );
                return true;
            }

            result = DateTime.Now;
            return false;
        }
    }
}
