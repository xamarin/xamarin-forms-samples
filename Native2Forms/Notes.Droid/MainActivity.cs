using System.IO;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using Notes.Droid.Models;
using Notes.Droid.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace Notes.Droid
{
    [Activity(Label = "Note.Droid",
        Icon = "@drawable/icon",
        Theme = "@style/MyTheme",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : AppCompatActivity
    {
        public static string FolderPath { get; private set; }

        public static MainActivity Instance;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Forms.Init(this, bundle);
            Instance = this;

            SetContentView(Resource.Layout.Main);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Notes";

            FolderPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData));
            Android.Support.V4.App.Fragment mainPage = new NotesPage().CreateSupportFragment(this);
            SupportFragmentManager
                .BeginTransaction()
                .Replace(Resource.Id.fragment_frame_layout, mainPage)
                .Commit();

            SupportFragmentManager.BackStackChanged += (sender, e) =>
            {
                bool hasBack = SupportFragmentManager.BackStackEntryCount > 0;
                SupportActionBar.SetHomeButtonEnabled(hasBack);
                SupportActionBar.SetDisplayHomeAsUpEnabled(hasBack);
                SupportActionBar.Title = hasBack ? "Note Entry" : "Notes";
            };
        }

        public override bool OnOptionsItemSelected(Android.Views.IMenuItem item)
        {
            if (item.ItemId == global::Android.Resource.Id.Home && SupportFragmentManager.BackStackEntryCount > 0)
            {
                SupportFragmentManager.PopBackStack();
                return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        public void NavigateToNoteEntryPage(Note note)
        {
            Android.Support.V4.App.Fragment noteEntryPage = new NoteEntryPage
            {
                BindingContext = note
            }.CreateSupportFragment(this);
            SupportFragmentManager
                .BeginTransaction()
                .AddToBackStack(null)
                .Replace(Resource.Id.fragment_frame_layout, noteEntryPage)
                .Commit();
        }

        public void NavigateBack()
        {
            SupportFragmentManager.PopBackStack();
        }
    }
}
