using System.IO;
using Android.App;
using Android.Content.PM;
using Android.OS;
using AndroidX.AppCompat.App;
using Notes.Droid.Models;
using Notes.Droid.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Toolbar = AndroidX.AppCompat.Widget.Toolbar;

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

            // Create app-level resource dictionary.
            Xamarin.Forms.Application.Current = new Xamarin.Forms.Application();
            Xamarin.Forms.Application.Current.Resources = new MyDictionary();

            Instance = this;

            SetContentView(Resource.Layout.Main);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Notes";

            FolderPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData));

            NotesPage notesPage = new NotesPage()
            {
                // Set the parent so that the app-level resource dictionary can be located.
                Parent = Xamarin.Forms.Application.Current
            };
            AndroidX.Fragment.App.Fragment notesPageFragment = notesPage.CreateSupportFragment(this);

            SupportFragmentManager
                .BeginTransaction()
                .Replace(Resource.Id.fragment_frame_layout, notesPageFragment)
                .Commit();

            SupportFragmentManager.BackStackChanged += (sender, e) =>
            {
                bool hasBack = SupportFragmentManager.BackStackEntryCount > 0;
                SupportActionBar.SetHomeButtonEnabled(hasBack);
                SupportActionBar.SetDisplayHomeAsUpEnabled(hasBack);
                SupportActionBar.Title = hasBack ? "Note Entry" : "Notes";
            };

            notesPage.Parent = null;
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
            NoteEntryPage noteEntryPage = new NoteEntryPage
            {
                BindingContext = note,
                // Set the parent so that the app-level resource dictionary can be located.
                Parent = Xamarin.Forms.Application.Current
            };

            AndroidX.Fragment.App.Fragment noteEntryFragment = noteEntryPage.CreateSupportFragment(this);
            SupportFragmentManager
                .BeginTransaction()
                .AddToBackStack(null)
                .Replace(Resource.Id.fragment_frame_layout, noteEntryFragment)
                .Commit();

            noteEntryPage.Parent = null;
        }

        public void NavigateBack()
        {
            SupportFragmentManager.PopBackStack();
        }
    }
}
