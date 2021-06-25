using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmHelpers;
using MvvmHelpers.Commands;
using PiLiveRecorder.Services;
using Xamarin.Forms;

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
        public IRecordingEngine Engine;
        public LoggingService LoggingService;

        public ICommand RecordCommand => new AsyncCommand(ExecuteRecordCommand);
        public ICommand PlayCommand => new AsyncCommand(ExecutePlayCommand);
        public ICommand StopCommand => new AsyncCommand(ExecuteStopCommand);

        public RecorderPageViewModel()
        {
            LoggingService = DependencyService.Get<LoggingService>();
            Engine = DependencyService.Get<IRecordingEngine>();
        }


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