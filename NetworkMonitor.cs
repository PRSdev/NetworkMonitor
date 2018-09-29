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

using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;

namespace NetworkMonitor
{
    public class NetworkMonitor
    {
        public delegate void NetworkStatusEventHandler(bool status);
        public event NetworkStatusEventHandler NetworkStatusChanged;

        public bool IsConnected { get; private set; }
        public int FailThreshold { get; set; } = 5;
        public string PingAddress { get; set; } = "8.8.8.8";
        public int PingInterval { get; set; } = 1000;
        public int PingTimeout { get; set; } = 1000;

        private int failCount = 0;
        private bool isFirstEvent = true;

        public void StartMonitorThread()
        {
            Task.Run(() =>
            {
                Stopwatch timer = new Stopwatch();

                while (true)
                {
                    timer.Restart();
                    CheckNetworkStatus();
                    int elapsed = (int)timer.ElapsedMilliseconds;
                    if (elapsed < PingInterval)
                    {
                        Thread.Sleep(PingInterval - elapsed);
                    }
                }
            });
        }

        private bool CheckNetworkStatus()
        {
            bool result = SendPing(PingAddress, PingTimeout);

            if (result)
            {
                failCount = 0;

                if (!IsConnected)
                {
                    IsConnected = true;
                    OnNetworkStatusChanged();
                }
            }
            else
            {
                failCount++;

                if (IsConnected && failCount >= FailThreshold)
                {
                    IsConnected = false;
                    OnNetworkStatusChanged();
                }
            }

            return result;
        }

        protected void OnNetworkStatusChanged()
        {
            if (isFirstEvent)
            {
                isFirstEvent = false;
                return;
            }

            if (NetworkStatusChanged != null)
            {
                NetworkStatusChanged(IsConnected);
            }
        }

        private bool SendPing(string address, int timeout)
        {
            using (Ping ping = new Ping())
            {
                PingReply reply = ping.Send(address, timeout);
                return reply != null && reply.Status == IPStatus.Success;
            }
        }
    }
}