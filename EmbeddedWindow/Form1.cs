using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System;

namespace EmbeddedWindow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hwndChild, IntPtr hwndNewParent);

        private void Form1_Shown(object sender, EventArgs e)
        {
            Process p = Process.Start("notepad.exe");
            p.WaitForInputIdle();
            SetParent(p.MainWindowHandle, this.Handle);
        }
    }
}
