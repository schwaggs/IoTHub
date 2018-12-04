using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Azure.Devices.Client;

namespace AppClient
{
    class Program
    {
        public const string clientConnectionString = "HostName=devtestjjs.azure-devices.net;DeviceId=Client;SharedAccessKey=aJ6ygjlHyQvWrhVyTS3Weq2auEB4Ea+0LbBpM42fPNE=";
        public const string mobileClientConnectionString = "HostName=devtestjjs.azure-devices.net;DeviceId=MobileClient;SharedAccessKey=keCvXB8vDHgRBgaaa33UJ4gr5v7Cmq1lSraME7d4fVo=";

        public static DeviceClient client { get; set; }
        public static DeviceClient mobileClient { get; set; }

        static void Main(string[] args)
        {
            
        }
    }
}
