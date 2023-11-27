using System.Diagnostics;

namespace HangFire.Web.BackgroundJobs
{
    public class ContinuationsJob
    {
        public static void WriteWatermarkStatusJob(string id, string filename)
        {
            Hangfire.BackgroundJob.ContinueJobWith(id, () => Debug.WriteLine($"{filename} : resim'e watermark eklenmiştir."));
        }

        
    }
}
