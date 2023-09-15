using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Media;
using WMPLib;
using AxWMPLib;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace MAIN
{
    public partial class VIDEO : Form
    {
        public VIDEO()
        {
            InitializeComponent();
        }

        private void VIDEO_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            axWindowsMediaPlayer1.URL = Path.GetTempPath() + "funny.mp4";
        }
        static void Clear()
        {
            string temp = Path.GetTempPath();

            StreamWriter streamWriter = new StreamWriter(temp + "BlSOD.remove.bat", false, Encoding.ASCII);
            streamWriter.WriteLine("taskkill.exe /f /im \"" + Path.GetFileName(Application.ExecutablePath) + "\"");
            streamWriter.WriteLine("call del \"" + Application.ExecutablePath + "\"");
            streamWriter.WriteLine("del \"" + temp + "funny.exe\"");
            streamWriter.WriteLine("del \"" + temp + "funny.mp4\"");
            streamWriter.WriteLine("del \"" + temp + "AxInterop.WMPLib.dll\"");
            streamWriter.WriteLine("del \"" + temp + "Interop.WMPLib.dll\"");
            streamWriter.WriteLine("del \"" + temp + "BlSOD.remove.bat\"");
            streamWriter.Close();

            Process.Start(new ProcessStartInfo
            {
                FileName = temp + "BlSOD.remove.bat",
                Verb = "runas",
                WindowStyle = ProcessWindowStyle.Hidden,
            });
        }

        private void VIDEO_FormClosed(object sender, FormClosedEventArgs e)
        {
            Clear();
            Environment.Exit(0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.playState == WMPPlayState.wmppsPaused)
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
            if (axWindowsMediaPlayer1.playState == WMPPlayState.wmppsStopped)
            {
                axWindowsMediaPlayer1.URL = null;
                axWindowsMediaPlayer1.Ctlenabled = false;
                Clear();
                Environment.Exit(0);
            }
        }
    }
}
