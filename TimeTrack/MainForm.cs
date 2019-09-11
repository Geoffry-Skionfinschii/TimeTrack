using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTrack
{
    public partial class MainForm : Form
    {

        public Dictionary<string, ProcessTracked> trackedProcessList = new Dictionary<string, ProcessTracked>();

        public MainForm()
        {
            InitializeComponent();
            foreach(string key in Program.processTimes.Keys)
            {
                ProcessTime pt = Program.processTimes[key];
                NewProcessAdded(pt);
            }
            foreach(string key in Program.savedProcessTime.Keys)
            {
                ProcessTime pt = Program.savedProcessTime[key];
                NewProcessAdded(pt);
            }
        }

        public void ProcessClosed(ProcessTime pt)
        {
            /*if (InvokeRequired)
            {
                Invoke(new Action(() => {
                    if (this.IsDisposed) return;
                    ProcessClosed(pt);
                }));
                return;
            }
            if(trackedProcessList.ContainsKey(pt.ProcessName))
            {
                trackerList.Controls.Remove(trackedProcessList[pt.ProcessName]);
                trackedProcessList[pt.ProcessName].Dispose();
                trackedProcessList.Remove(pt.ProcessName);
            }*/
        }

        public void UpdateTimestamp(ProcessTime pt)
        {
            if (IsDisposed) return;
            if(InvokeRequired)
            {
                Invoke(new Action(() => {
                    if (this.IsDisposed) return;
                    UpdateTimestamp(pt);
                }));
                return;
            }
            if(!trackedProcessList.ContainsKey(pt.ProcessName))
            {
                NewProcessAdded(pt);
            } else
            {
                trackedProcessList[pt.ProcessName].Timestamp = pt.GetTimeFormatted();
            }

        }

        public void NewProcessAdded(ProcessTime pt)
        {
            if(InvokeRequired)
            {
                Invoke(new Action(() => {
                    if (this.IsDisposed) return;
                    NewProcessAdded(pt);
                }));
                return;
            }
            if (trackedProcessList.ContainsKey(pt.ProcessName)) return;

            ProcessTracked tracked = new ProcessTracked();
            tracked.ProcessName = pt.ProcessName;
            tracked.ProcessTitle = pt.ProcessTitle;
            tracked.Timestamp = pt.GetTimeFormatted();
            tracked.SetChecked(pt.GetTracked());

            trackedProcessList.Add(pt.ProcessName, tracked);

            trackerList.Controls.Add(tracked);
        }
    }
}
