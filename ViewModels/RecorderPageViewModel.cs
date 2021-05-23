using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmHelpers;
using MvvmHelpers.Commands;

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
        public ICommand RecordCommand => new AsyncCommand(ExecuteRecordCommand);

        static int counter;
        private async Task ExecuteRecordCommand()
        {
            Status = counter++.ToString();

        }
    }
}