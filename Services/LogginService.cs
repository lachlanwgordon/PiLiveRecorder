using System;
using MvvmHelpers;

namespace PiLiveRecorder.Services
{
    public static class LoggingService
    {
        public static ObservableRangeCollection<string> Logs { get; set; } = new ObservableRangeCollection<string>();
        public static void Log(string message)
        {
            Logs.Insert(0, message);
        }

    }
}