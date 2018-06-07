using System;
using Android.App;
using Android.OS;
using System.IO;
using EmployeeDirectoryUI;
using Android.Content.PM;
using Android.Support.V4.Content;
using Android.Support.V4.App;
using Android.Widget;
using Xamarin.Forms.Platform.Android;

namespace EmployeeDirectory.Android
{
	[Activity(Label = "EmployeeDirectory", Theme = "@style/MainTheme", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : FormsAppCompatActivity
    {
        internal static MainActivity Instance { get; private set; }

        public interface IPermissionCallback
        {
            void OnGrantedPermission(int requestCode);
            void OnDeniedPermission(int requestCode);
        }

        int currentRequestCodePermission;
        IPermissionCallback currentPermissionCallback;

        protected override void OnCreate(Bundle bundle)
        {
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            Instance = this;

            CopyInfoIntoWorkingFolder("XamarinDirectory.csv",
                EmployeeDirectory.Android.Resource.Raw.XamarinDirectory);
            CopyInfoIntoWorkingFolder("XamarinFavorites.xml",
                EmployeeDirectory.Android.Resource.Raw.XamarinFavorites);

            Xamarin.Forms.Forms.Init(this, bundle);

            App.PhoneFeatureService = new AndroidPhoneFeatureService(this);

            LoadApplication(new App());
        }

        public void AskForPermission(string permission, int requestCode, IPermissionCallback callback)
        {
            currentPermissionCallback = callback;
            var permissionCheck = (int)ContextCompat.CheckSelfPermission(this, permission);
            if (permissionCheck == (int)Permission.Granted)
            {
                callback.OnGrantedPermission(requestCode);
            }
            else
            {
                currentRequestCodePermission = requestCode;
                ActivityCompat.RequestPermissions(this, new string[] { permission }, requestCode);
            }
        }

        public void ShowToast(string message)
        {
            Toast.MakeText(this, message, ToastLength.Long).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            if (requestCode == currentRequestCodePermission)
            {
                if (grantResults.Length > 0 && grantResults[0] == Permission.Granted)
                {
                    // permission was granted
                    if (currentPermissionCallback != null)
                    {
                        currentPermissionCallback.OnGrantedPermission(requestCode);
                    }
                }
                else
                {
                    // permission denied
                    if (currentPermissionCallback != null)
                    {
                        currentPermissionCallback.OnDeniedPermission(requestCode);
                    }
                }
                currentPermissionCallback = null;
            }
        }

        private void CopyInfoIntoWorkingFolder(string fileName, int resourceId)
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            var path = Path.Combine(documentsPath, fileName);

            if (!File.Exists(path))
            {
                var readStream = Resources.OpenRawResource(resourceId);
                var writeStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                ReadWriteStream(readStream, writeStream);
            }
        }

        private void ReadWriteStream(Stream readStream, Stream writeStream)
        {
            int Length = 256;
            var buffer = new Byte[Length];
            int bytesRead = readStream.Read(buffer, 0, Length);

            using (readStream)
            using (writeStream)
            {
                while (bytesRead > 0)
                {
                    writeStream.Write(buffer, 0, bytesRead);
                    bytesRead = readStream.Read(buffer, 0, Length);
                }
            }
        }
    }
}


