using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using EmployeeDirectory.WinPhone.Resources;
using Xamarin.Forms;
using System.IO;
using PCLStorage;

namespace EmployeeDirectory.WinPhone
{
	public partial class MainPage : global::Xamarin.Forms.Platform.WinPhone.FormsApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            CopyInfoIntoWorkingFolder("XamarinDirectory.csv");
            CopyInfoIntoWorkingFolder("XamarinFavorites.xml");

            Forms.Init();

			LoadApplication(new EmployeeDirectory.App()); // new in 1.3
        }

        private void CopyInfoIntoWorkingFolder(string fileName)
        {
            string documentsPath = FileSystem.Current.LocalStorage.Path;
            var path = Path.Combine(documentsPath, fileName);

            if (!File.Exists(path))
            {
                var readStream = File.OpenRead("Assets/" + fileName);
                var writeStream = new FileStream(path, FileMode.OpenOrCreate, System.IO.FileAccess.Write);
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