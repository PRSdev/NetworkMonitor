#region License Information (GPL v3)

/*
    ShareX - A program that allows you to take screenshots and share any file type
    Copyright (c) 2007-2018 ShareX Team

    This program is free software; you can redistribute it and/or
    modify it under the terms of the GNU General Public License
    as published by the Free Software Foundation; either version 2
    of the License, or (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

    Optionally you can also view the license at <http://www.gnu.org/licenses/>.
*/

#endregion License Information (GPL v3)

#region License Information (GPL v3)

/*
    Network Monitor - A program that allows you to monitor network activity
    Copyright (c) 2018 ShareX Team

    This program is free software; you can redistribute it and/or
    modify it under the terms of the GNU General Public License
    as published by the Free Software Foundation; either version 2
    of the License, or (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

    Optionally you can also view the license at <http://www.gnu.org/licenses/>.
*/

#endregion License Information (GPL v3)

using NetworkMonitor.Properties;
using ShareX.HelpersLib;
using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace NetworkMonitor
{
    public partial class MainForm : Form
    {
        private NetworkMonitor networkMonitor;
        private bool forceClose;

        #region Paths

        private const string AppName = "Network Monitor";
        public const string LogsFoldername = "Logs";
        public static readonly string DefaultPersonalFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), AppName);
        public static string LogsFolder => Path.Combine(DefaultPersonalFolder, LogsFoldername);

        public static string LogsFilePath
        {
            get
            {
                string filename = string.Format("NetworkMonitor-Log-{0:yyyy-MM}.txt", DateTime.Now);
                return Path.Combine(LogsFolder, filename);
            }
        }

        #endregion Paths

        public MainForm()
        {
            InitializeComponent();
            Icon = Resources.Icon;
            niMain.Icon = Resources.Icon;
            DebugHelper.Init(LogsFilePath);

            networkMonitor = new NetworkMonitor();
            networkMonitor.NetworkStatusChanged += NetworkMonitor_NetworkStatusChanged;
            networkMonitor.StartMonitorThread();
        }

        private void NetworkMonitor_NetworkStatusChanged(bool status)
        {
            if (!IsDisposed)
            {
                Invoke((Action)delegate
                {
                    string text = status ? "Connected." : "Disconnected.";

                    ListViewItem lvi = new ListViewItem();
                    lvi.ForeColor = status ? Color.Green : Color.Firebrick;
                    lvi.Text = DateTime.Now.ToString();
                    lvi.SubItems.Add(text);
                    lvMain.Items.Add(lvi);

                    DebugHelper.WriteLine(lvi.SubItems[1].Text);

                    niMain.ShowBalloonTip(5000, "Network monitor", text, ToolTipIcon.Info);
                });
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !forceClose)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void OpenMainWindow()
        {
            if (!Visible)
            {
                Show();
            }

            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }

            BringToFront();
            Activate();
        }

        private void CopyAll()
        {
            if (lvMain.Items.Count > 0)
            {
                StringBuilder sbLog = new StringBuilder();
                foreach (ListViewItem lvi in lvMain.Items)
                {
                    foreach (ListViewItem.ListViewSubItem lvsi in lvi.SubItems)
                    {
                        sbLog.Append(lvsi.Text);
                        sbLog.Append(" ");
                    }

                    sbLog.AppendLine();
                }
                Clipboard.SetText(sbLog.ToString().Trim());
            }
        }

        private void niMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                OpenMainWindow();
            }
        }

        private void tsmiOpenMainWindow_Click(object sender, EventArgs e)
        {
            OpenMainWindow();
        }

        private void tsmiCopyAll_Click(object sender, EventArgs e)
        {
            CopyAll();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            forceClose = true;
            Close();
        }
    }
}