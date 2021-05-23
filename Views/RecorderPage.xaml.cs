using System;
using PiLiveRecorder.ViewModels;
using Xamarin.Forms;



namespace PiLiveRecorder.Views
{
    public partial class RecorderPage : ContentPage
    {
        public RecorderPage()
        {
            BindingContext = new RecorderPageViewModel();
            InitializeComponent();
        }
    }
}