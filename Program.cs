using System;
using Xamarin.Forms;
using Ooui.Forms;
using Ooui;
using Label = Xamarin.Forms.Label;
using PiLiveRecorder.Views;
using System.Diagnostics;
using PiLiveRecorder.Services;

namespace PiLiveRecorder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
             Forms.Init();

            DependencyService.RegisterSingleton<LoggingService>(new LoggingService());
            DependencyService.RegisterSingleton<IRecordingEngine>(new ALSAProcessEngine());

             UI.Host = "10.1.1.155";

             UI.Publish("/", x => new RecorderPage().GetOouiElement());
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "chromium-browser",
                    Arguments = "--app=http://10.1.1.155:8080",
                    //Arguments = "-f s32_LE -c 18 -r 48000 -D hw:2,0 -t wav test.wav",
                    UseShellExecute = false,
                }
            };
            process.Start();
            Console.ReadLine();
        }
    }
}
