using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmHelpers;
using MvvmHelpers.Commands;
using PiLiveRecorder.Services;

namespace PiLiveRecorder.ViewModels
{
    public class RecorderPageViewModel : BaseViewModel
    {
        string status = "Welcome";
        public string Status
        {
            get => status;
            set => SetProperty(ref status, value);
        }
        public ObservableRangeCollection<string> Logs => LoggingService.Logs;
        public IRecordingEngine Engine = new ALSAProcessEngine();

        public ICommand RecordCommand => new AsyncCommand(ExecuteRecordCommand);
        public ICommand PlayCommand => new AsyncCommand(ExecutePlayCommand);
        public ICommand StopCommand => new AsyncCommand(ExecuteStopCommand);

        private async Task ExecutePlayCommand()
        {
            await Engine.Play();
        }


        private async Task ExecuteStopCommand()
        {
            await Engine.Stop();
        }

        static int counter;
        private async Task ExecuteRecordCommand()
        {
            Status = counter++.ToString();
            LoggingService.Log(Status);
            await Engine.Record();
        }
    }
}