using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using TablesLists.WinPhone.Resources;
using Xamarin.Forms;
using System.IO;
using PCLStorage;

namespace TablesLists.WinPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            CopyInfoIntoWorkingFolder("MainMenuItems.xml");
            CopyInfoIntoWorkingFolder("SimpleListItem1.xml");
            CopyInfoIntoWorkingFolder("SimpleListItem2.xml");
            CopyInfoIntoWorkingFolder("ActivityListItem.xml");
            CopyInfoIntoWorkingFolder("DateList.xml");
            CopyInfoIntoWorkingFolder("LabelledSections.xml");
            CopyInfoIntoWorkingFolder("DefaultCellStyle.xml");

            Forms.Init ();
            Content = TablesLists.App.GetMainPage ().ConvertPageToUIElement (this);
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