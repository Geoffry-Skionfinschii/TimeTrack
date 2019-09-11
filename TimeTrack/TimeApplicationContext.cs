using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTrack
{
    internal class TimeApplicationContext : ApplicationContext
    {

        private readonly NotifyIcon trayIcon;

        public TimeApplicationContext()
        {
            this.trayIcon = new NotifyIcon()
            {
                Icon = FormUtils.DefaultFormIcon,
                ContextMenu = new ContextMenu(new MenuItem[2]
                {
                    new MenuItem("Open...", new EventHandler(this.Open)),
                    new MenuItem("Exit", new EventHandler(this.Exit))
                }),
                Visible = true
            };
        }

        private void Open(object sender, EventArgs e)
        {
            if (Program.mainForm != null && Program.mainForm.Visible)
                return;
            Program.mainForm = new MainForm
            {
                Visible = true
            };
        }

        private void Exit(object sender, EventArgs e)
        {
            this.trayIcon.Visible = false;
            Application.Exit();
        }
    }
}
