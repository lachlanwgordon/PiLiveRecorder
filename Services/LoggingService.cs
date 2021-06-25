using System;
using MvvmHelpers;

namespace PiLiveRecorder.Services
{
    public class LoggingService
    {
        public ObservableRangeCollection<string> Logs { get; set; } = new ObservableRangeCollection<string>();
        public void Log(string message)
        {
            Logs.Insert(0, message);
        }

    }
}