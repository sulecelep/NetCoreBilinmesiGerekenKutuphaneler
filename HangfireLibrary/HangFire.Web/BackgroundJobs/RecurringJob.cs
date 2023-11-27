using Hangfire;
using System.Diagnostics;

namespace HangFire.Web.BackgroundJobs
{
    public class RecurringJob
    {
        public static void ReportingJob()
        {
            //cron haftalık aylık zaman dilimlerini belirleyen bir zaman belirteci
            //cronmaker sitesinden kendi zamanımızı oluşturabiliriz.
            Hangfire.RecurringJob.AddOrUpdate("reportJob1", () => EmailReport(), Cron.Minutely);
        }
        public static void EmailReport()
        {
            Debug.WriteLine("Rapor, email olarak gönderildi.");
        }
    }
}
