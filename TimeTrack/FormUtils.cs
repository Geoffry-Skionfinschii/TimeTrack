using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTrack
{
    public static class FormUtils
    {
        private static Icon _defaultFormIcon;

        public static Icon DefaultFormIcon
        {
            get
            {
                if (FormUtils._defaultFormIcon == null)
                    FormUtils._defaultFormIcon = (Icon)typeof(Form).GetProperty("DefaultIcon", BindingFlags.Static | BindingFlags.NonPublic).GetValue((object)null, (object[])null);
                return FormUtils._defaultFormIcon;
            }
        }
    }
}
