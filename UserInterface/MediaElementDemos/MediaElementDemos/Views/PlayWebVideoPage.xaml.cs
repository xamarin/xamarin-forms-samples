using System;
using Xamarin.Forms;

namespace MediaElementDemos
{
    public partial class PlayWebVideoPage : ContentPage
    {
        public PlayWebVideoPage()
        {
            InitializeComponent();
        }

        void OnMediaOpened(object sender, EventArgs e)
        {
            Console.WriteLine("Media opened.");
        }

        void OnMediaFailed(object sender, EventArgs e)
        {
            Console.WriteLine("Media failed.");
        }

        void OnMediaEnded(object sender, EventArgs e)
        {
            Console.WriteLine("Media ended.");
        }

        void OnSeekCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Seek completed.");
        }
    }
}
