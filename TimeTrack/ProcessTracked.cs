using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTrack
{
    public partial class ProcessTracked : UserControl
    {

        public string ProcessName
        {
            get
            {
                return labelProcessName.Text;
            }
            set
            {
                labelProcessName.Text = value;
            }
        }
        public string ProcessTitle {
            get
            {
                return labelProcessTitle.Text;
            }
            set
            {
                labelProcessTitle.Text = value;
            }
        }
        public string Timestamp {
            set
            {
                this.labelTotalTime.Text = value;
            }
        }

        public void SetChecked(bool isChecked)
        {
            checkboxIsTracked.Checked = isChecked;
        }

        public ProcessTracked()
        {
            InitializeComponent();
        }

        private void CheckboxIsTracked_CheckedChanged(object sender, EventArgs e)
        {
            if(Program.processTimes.ContainsKey(ProcessName))
            {
                Program.processTimes[ProcessName].SetTracked(((CheckBox)sender).Checked);
            }
        }
    }
}
