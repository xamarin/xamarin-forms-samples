using Notes.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.DualScreen;

namespace Notes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public static MainPage Current { get; private set; }
        public MainPage()
        {
            InitializeComponent();
            twoPaneView.LayoutChanged += TwoPaneView_LayoutChanged;
            Current = this;
        }


        public bool DeviceIsSpanned => DualScreenInfo.Current.SpanMode != TwoPaneViewMode.SinglePane;

        private void TwoPaneView_LayoutChanged(object sender, EventArgs e)
        {
            if (DeviceIsSpanned)
            {
                twoPaneView.WideModeConfiguration = TwoPaneViewWideModeConfiguration.LeftRight;
                twoPaneView.TallModeConfiguration = TwoPaneViewTallModeConfiguration.TopBottom;
            }
            else
            {   // single screen!
                twoPaneView.WideModeConfiguration = TwoPaneViewWideModeConfiguration.SinglePane;
                twoPaneView.TallModeConfiguration = TwoPaneViewTallModeConfiguration.SinglePane;
            }

        }

        void OnNoteAddedClicked(object sender, EventArgs e)
        {
            twoPaneView.Pane2.BindingContext = new Note();
            twoPaneView.PanePriority = TwoPaneViewPriority.Pane2;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            RefreshData();
        }

        public void RefreshData()
        {
            var notes = new List<Note>();

            var files = Directory.EnumerateFiles(App.FolderPath, "*.notes.txt");
            foreach (var filename in files)
            {
                notes.Add(new Note
                {
                    Filename = filename,
                    Text = File.ReadAllText(filename),
                    Date = File.GetCreationTime(filename)
                });
            }

            BindingContext = notes
                .OrderBy(d => d.Date)
                .ToList();

            twoPaneView.PanePriority = TwoPaneViewPriority.Pane1;
        }
        public void OnListViewItemSelected(Note note)
        {
            if (note != null)
            {
                twoPaneView.Pane2.BindingContext = note;
                twoPaneView.PanePriority = TwoPaneViewPriority.Pane2;
            }
        }
        protected override bool OnBackButtonPressed()
        {
            if (!DeviceIsSpanned)
            { // single-screen
                if (twoPaneView.PanePriority == TwoPaneViewPriority.Pane2)
                { //showing detail, back goes to master (list)
                    twoPaneView.PanePriority = TwoPaneViewPriority.Pane1;
                    return true;
                }
            }
            return base.OnBackButtonPressed();
        }


    }
}