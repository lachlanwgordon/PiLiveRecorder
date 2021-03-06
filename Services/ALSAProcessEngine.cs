using System;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PiLiveRecorder.Services
{
    public class ALSAProcessEngine : IRecordingEngine
    {
        Process process;
        LoggingService LoggingService;
        public ALSAProcessEngine()
        {
            LoggingService = DependencyService.Get<LoggingService>();
        }

        public Task Play()
        {
            LoggingService.Log("Engine started playing");

            return Task.CompletedTask;
        }

        public Task Record()
        {
            LoggingService.Log("+++Engine started recording");

            process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "arecord",
                    Arguments = "-f s32_LE -c 18 -r 48000 -D hw:2,0 -t wav 3.wav",
                    UseShellExecute = false,
                }
            };
            process.Start();


            return Task.CompletedTask;
        }

        public Task Stop()
        {
            LoggingService.Log("Engine stop ");
            process.Kill();

            return Task.CompletedTask;
        }
    }
}