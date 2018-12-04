using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace ProcessingJob
{
    public class Functions
    {
        private const string DeviceQueue = "client";
        private const string AppQueue = "mobileclient";
        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.
        //public static void ProcessQueueMessage([QueueTrigger("queue")] string message, TextWriter log)
        //{
        //    log.WriteLine(message);
        //}

        public static void ProcessClientQueueMessage([QueueTrigger(DeviceQueue)] string message, TextWriter log)
        {
            log.WriteLine(message);
        }

        public static void ProcessMobileClientQueueMessage([QueueTrigger(AppQueue)] string message, TextWriter log)
        {
            log.WriteLine(message);
        }
    }
}
