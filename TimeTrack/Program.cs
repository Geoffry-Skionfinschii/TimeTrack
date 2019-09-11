using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeTrack.Properties;

namespace TimeTrack
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        public static MainForm mainForm;
        private static System.Timers.Timer findProcessTimer;
        private static System.Timers.Timer updateTimeTimer;

        //Contains the time for processes currently not running. Is not touched until a process exits.
        public static Dictionary<string, ProcessTime> savedProcessTime = new Dictionary<string, ProcessTime>();

        //Contains the time for currently existing processes.
        public static Dictionary<string, ProcessTime> processTimes = new Dictionary<string, ProcessTime>();

        [STAThread]
        static void Main()
        {

            if (Process.GetProcessesByName(Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location)).Count() > 1)
            {
                MessageBox.Show("This application is already running");
                Process.GetCurrentProcess().Kill();
            }

            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            object path = key.GetValue("TimeTrackAutorun");
            if (path == null || path.ToString() != Assembly.GetEntryAssembly().Location)
            {
                key.SetValue("TimeTrackAutorun", Assembly.GetEntryAssembly().Location);
            }

            LoadProgramTimes();

            FindProcessLoop();
            UpdateTimeLoop();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TimeApplicationContext());
        }

        private static void LoadProgramTimes()
        {
            StringCollection programSettings = Settings.Default.ProgramTrackData;
            if (programSettings == null) return;
            foreach(string str in programSettings)
            {
                string[] arr = str.Split('?');
                string[] details = arr[1].Split('`');
                if (details.Length != 4) continue;
                ProcessTime pt = new ProcessTime(details[0], details[1], ulong.Parse(details[2]));
                pt.SetTracked(bool.Parse(details[3]));
                if (pt.GetTime() == 0) continue;
                savedProcessTime.Add(arr[0], pt);
            }
        }

        private static void SaveProgramTimes()
        {
            Debug.WriteLine("Saving data");
            StringCollection collection = new StringCollection();
            List<string> addedKeys = new List<string>();
            foreach(string key in processTimes.Keys)
            {
                if (addedKeys.Contains(key)) continue;
                ProcessTime pt = processTimes[key];
                if (pt.GetTime() == 0) continue;
                collection.Add($"{key}?{pt.ProcessName}`{pt.ProcessTitle}`{pt.GetTime()}`{pt.GetTracked()}");
                addedKeys.Add(key);
            }

            foreach (string key in savedProcessTime.Keys)
            {
                if (addedKeys.Contains(key)) continue;
                ProcessTime pt = savedProcessTime[key];
                if (pt.GetTime() == 0) continue;
                collection.Add($"{key}?{pt.ProcessName}`{pt.ProcessTitle}`{pt.GetTime()}`{pt.GetTracked()}");
                addedKeys.Add(key);
            }
            Settings.Default.ProgramTrackData = collection;
            Settings.Default.Save();
        }


        private static int secondsPerLoop = 10;
        private static void FindProcessLoop()
        {
            Program.findProcessTimer = new System.Timers.Timer(2000);
            findProcessTimer.Elapsed += (o, o2) =>
            {
                findProcessTimer.Interval = secondsPerLoop * 1000;
                Process[] processes = Process.GetProcesses();
                foreach (Process p in processes)
                {
                    if (processTimes.ContainsKey(p.ProcessName) || string.IsNullOrEmpty(p.MainWindowTitle))
                    {
                        continue;
                    }
                    else
                    {
                        try
                        {
                            p.EnableRaisingEvents = true;
                            if (savedProcessTime.ContainsKey(p.ProcessName))
                            {
                                ProcessTime pt = savedProcessTime[p.ProcessName];
                                ProcessTime newPT = new ProcessTime(p.ProcessName, p.MainWindowTitle, pt.GetTime());
                                newPT.SetTracked(pt.GetTracked());
                                processTimes.Add(p.ProcessName, newPT);
                                if (mainForm != null && mainForm.Visible)
                                {
                                    mainForm.NewProcessAdded(pt);
                                }
                            }
                            else
                            {
                                processTimes.Add(p.ProcessName, new ProcessTime(p.ProcessName, p.MainWindowTitle));
                                if (mainForm != null && mainForm.Visible)
                                {
                                    mainForm.NewProcessAdded(processTimes[p.ProcessName]);
                                }
                            }

                            p.Exited += Process_Exited;
                        }
                        catch (Win32Exception)
                        {
                        }
                    }
                }

            };
            Program.findProcessTimer.AutoReset = true;
            Program.findProcessTimer.Start();
        }

        private static DateTime lastUpdate;

        private static int secondsPerTimeSave = 1;
        private static int countPerSave = 5;
        private static int countOfUpdates = 0;
        private static void UpdateTimeLoop()
        {
            Program.updateTimeTimer = new System.Timers.Timer(2000);
            updateTimeTimer.Elapsed += (o, o2) =>
            {
                updateTimeTimer.Interval = secondsPerTimeSave * 1000;
                if (lastUpdate == null)
                {
                    lastUpdate = DateTime.Now;
                }
                else
                {
                    DateTime current = DateTime.Now;
                    foreach (string key in processTimes.Keys)
                    {
                        if (processTimes[key].GetTracked())
                        {
                            processTimes[key].AddSeconds((ulong)Math.Floor((current - lastUpdate).TotalSeconds));
                            if (mainForm != null)
                            {
                                mainForm.UpdateTimestamp(processTimes[key]);
                            }
                        }
                    }
                    lastUpdate = current;
                    countOfUpdates++;
                    if (countOfUpdates % countPerSave == 0)
                    {
                        SaveProgramTimes();
                        countOfUpdates = 0;
                    }
                }
            };
            Program.updateTimeTimer.AutoReset = true;
            Program.updateTimeTimer.Start();
        }

        private static void Process_Exited(object sender, EventArgs e)
        {
            Process p = (Process)sender;
            savedProcessTime[p.ProcessName] = processTimes[p.ProcessName];
            mainForm.ProcessClosed(processTimes[p.ProcessName]);
            processTimes.Remove(p.ProcessName);
            Debug.WriteLine("Process " + p.ProcessName + " exited");
        }
    }
}
