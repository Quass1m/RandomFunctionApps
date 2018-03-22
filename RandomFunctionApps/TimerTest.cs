using System;
using System.Threading;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace RandomFunctionApps
{
    public static class TimerTest
    {
        [FunctionName("TimerTest")]
        public static void Run([TimerTrigger("*/10 * * * * *")]TimerInfo myTimer, Microsoft.Azure.WebJobs.ExecutionContext ctx, TraceWriter log)
        {
            //var id = Thread.CurrentThread.ManagedThreadId;
            var id = ctx.InvocationId;

            log.Info($"C# Timer trigger function [{id}] executed at: {DateTime.Now}");

            if (myTimer.IsPastDue)
                log.Info($"C# Timer trigger function [{id}] is past due!");

            Thread.Sleep(TimeSpan.FromSeconds(60));

            log.Info($"C# Timer trigger function [{id}] quit at: {DateTime.Now}");
        }
    }
}