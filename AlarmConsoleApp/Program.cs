using System;
using System.Threading;

namespace AlarmConsoleApp
{
    // I'm creating a delegate for the alarm event
    public delegate void AlarmEventHandler(object source, EventArgs args);

    // I'm defining the publisher class that will raise the alarm event
    public class AlarmClock
    {
        // I'm declaring the event using the delegate
        public event AlarmEventHandler RaiseAlarm;

        private DateTime targetTime;
        private bool isRunning = false;

        // Creating a method to set the alarm time
        public void SetAlarm(DateTime time)
        {
            targetTime = time;
            Console.WriteLine($"Alarm set for: {targetTime.ToString("HH:mm:ss")}");
        }

        // Implementing a method to start checking the time
        public void StartMonitoring()
        {
            isRunning = true;
            Console.WriteLine("Alarm monitoring started...");

            // I'm using a while loop to continuously check the current time
            while (isRunning)
            {
                DateTime currentTime = DateTime.Now;

                // I'm displaying the current time to show the progress
                Console.Write($"\rCurrent time: {currentTime.ToString("HH:mm:ss")}");

                // I'm checking if current time matches the target time
                if (currentTime.Hour == targetTime.Hour &&
                    currentTime.Minute == targetTime.Minute &&
                    currentTime.Second == targetTime.Second)
                {
                    // I'm raising the event when times match
                    OnAlarmTime();
                    isRunning = false;
                }

                // I'm adding a small delay to prevent excessive CPU usage
                Thread.Sleep(100);
            }
        }

        // I'm creating a protected method to raise the event
        protected virtual void OnAlarmTime()
        {
            // I'm checking if there are any subscribers before raising the event
            if (RaiseAlarm != null)
            {
                RaiseAlarm(this, EventArgs.Empty);
            }
        }
    }

    // I'm defining the subscriber class that will handle the alarm event
    public class AlarmHandler
    {
        // I'm creating the event handler method
        public void Ring_alarm(object source, EventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine("==============================================");
            Console.WriteLine("ALARM! ALARM! It's time to wake up!");
            Console.WriteLine("==============================================");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Alarm Clock Application");
            Console.WriteLine("======================");

            // I'm creating instances of the publisher and subscriber
            AlarmClock alarmClock = new AlarmClock();
            AlarmHandler handler = new AlarmHandler();

            // I'm subscribing to the event
            alarmClock.RaiseAlarm += handler.Ring_alarm;

            // Getting the time input from the user
            DateTime targetTime;
            bool validInput = false;

            while (!validInput)
            {
                Console.Write("\nEnter alarm time (HH:MM:SS): ");
                string timeInput = Console.ReadLine();

                // Validating the user input
                if (DateTime.TryParseExact(timeInput, "HH:mm:ss", null,
                    System.Globalization.DateTimeStyles.None, out targetTime))
                {
                    // Creating a new DateTime with today's date and user's time
                    DateTime today = DateTime.Today;
                    targetTime = new DateTime(
                        today.Year, today.Month, today.Day,
                        targetTime.Hour, targetTime.Minute, targetTime.Second
                    );

                    // Checking if the time is in the past
                    if (targetTime < DateTime.Now)
                    {
                        Console.WriteLine("The time you entered is in the past. Please enter a future time.");
                    }
                    else
                    {
                        validInput = true;
                        alarmClock.SetAlarm(targetTime);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid time format. Please use HH:MM:SS format.");
                }
            }

            // Starting the alarm monitoring
            alarmClock.StartMonitoring();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
