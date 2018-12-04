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
            client = DeviceClient.CreateFromConnectionString(clientConnectionString);
            mobileClient = DeviceClient.CreateFromConnectionString(mobileClientConnectionString);

            
        }




        public static async void SpawnClientSender()
        {
            await Task.Run(async () =>
            {
                while(true)
                {
                    Message msg = new Message
                    {
                        To = "MobileClient",
                    };

                    await client.SendEventAsync(msg);
                    await Task.Delay(10000);
                }
            });
        }

        public static async void SpawnMobileClientSender()
        {
            await Task.Run(async () =>
            {
                while (true)
                {
                    Message msg = new Message
                    {
                        To = "Client",
                    };

                    await mobileClient.SendEventAsync(msg);

                    await Task.Delay(10000);
                }
            });
        }

        private async static Task SendCloudToDeviceMessageAsync()
        {
            var commandMessage = new
             Message(Encoding.ASCII.GetBytes("Cloud to device message."));
            await serviceClient.SendAsync("myFirstDevice", commandMessage);
        }

        public static async void SpawnClientReceiver()
        {
            await Task.Run(async () =>
            {
                while (true)
                {
                    Console.WriteLine("\nReceiving cloud to device messages from service");
                    while (true)
                    {
                        Message receivedMessage = await client.ReceiveAsync();
                        if (receivedMessage == null) continue;

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Received message: {0}",
                        Encoding.ASCII.GetString(receivedMessage.GetBytes()));
                        Console.ResetColor();

                        await client.CompleteAsync(receivedMessage);
                    }

                    await Task.Delay(1000);
                }

            });
        }

        public static async void SpawnMobileClientReceiver()
        {
            await Task.Run(async () =>
            {
                while (true)
                {
                    Message received = await client.ReceiveAsync();

                    if (received != null)
                    {
                        Console.WriteLine("Received client message\n{0}", Encoding.ASCII.GetString(received.GetBytes()));
                        await client.CompleteAsync(received);
                    }

                    await Task.Delay(1000);
                }

            });
        }
    }
}
