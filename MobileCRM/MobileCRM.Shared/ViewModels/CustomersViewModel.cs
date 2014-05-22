using MobileCRM;
using MobileCRM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace Meetup.Shared.ViewModels
{
    public class CustomersViewModel : BaseViewModel
    {

        public CustomersViewModel()
        {
            Title = "Customers";
            Icon = "list.png"; ;
            Customers = new ObservableCollection<POI>();
        }
        public ObservableCollection<POI> Customers { get; set; }

        private Command loadCustomersCommand;
        public Command LoadCustomersCommand
        {
            get
            {
                return loadCustomersCommand ?? (loadCustomersCommand = new Command(ExecuteLoadCustomersCommand));
            }
        }

        protected void ExecuteLoadCustomersCommand()
        {
            if (App.PointsOfInterest != null && Customers.Count != 0)
                return;

            var name = string.Empty;
#if __IOS__
			name = "MobileCRM.iOS.Data.Poi.json";
#elif __ANDROID__
            name = "MobileCRM.Android.Data.Poi.json";
#elif WINDOWS_PHONE
			name = "MobileCRM.WindowsPhone.Data.Poi.json";
#endif
            var jsonStream = App.LoadResource(name);
            TestData data = null;
            using (var jsonReader = new StreamReader(jsonStream))
            {
                var json = jsonReader.ReadToEnd();
                data = global::Newtonsoft.Json.JsonConvert.DeserializeObject<TestData>(json);
            }
            App.PointsOfInterest = data.PointsOfInterest;
            foreach (var point in data.PointsOfInterest)
                Customers.Add(point);

            OnPropertyChanged("Customers");
        }
    }
}
