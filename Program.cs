using System;
using Xamarin.Forms;
using Ooui.Forms;
using Ooui;
using Label = Xamarin.Forms.Label;

namespace PiLiveRecorder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Forms.Init();
            UI.Host = "10.1.1.155";
            var page = new ContentPage();
            var content = new StackLayout
            {
                Children = 
                {
                    new Label{Text = "hellooww"}
                }
            };
            page.Content = content;

            var element = page.GetOouiElement();

            UI.Publish("/", element);

            Console.ReadLine();
        }
    }
}
