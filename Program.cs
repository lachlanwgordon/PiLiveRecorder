using System;
using Xamarin.Forms;
using Ooui.Forms;
using Ooui;
using Label = Xamarin.Forms.Label;
using PiLiveRecorder.Views;

namespace PiLiveRecorder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Forms.Init();
            UI.Host = "10.1.1.199";

            UI.Publish("/", x => new RecorderPage().GetOouiElement());

            Console.ReadLine();
        }
    }
}
