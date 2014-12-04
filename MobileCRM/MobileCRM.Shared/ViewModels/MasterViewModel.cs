using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using System.Reflection;
using System.Linq;
using MobileCRM.Services;
using MobileCRM.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MobileCRM.Shared.ViewModels
{
    public class MasterViewModel<T> : BaseViewModel
        where T: class, IContact, new()
    {
        // Analysis disable once StaticFieldInGenericType
        static readonly MethodInfo GetDependency;

        static MasterViewModel() 
        {
            // NOTE: Workaround lack of generics support in DependencyService,
            //          i.e. because we can't just do: DependencyService.Get<IRepository<T>>()
            // NOTE: Refactor to a Factory/Builder pattern.
            var repoType = MobileCRMApp.TypeMap[typeof(T)];
            var getMethod = typeof(DependencyService)
                .GetRuntimeMethods()
                .Single((method)=>
                    method.Name.Equals("Get"));
            GetDependency = getMethod.MakeGenericMethod(repoType);
        }

        const string IconFormat = "{0}.png";

        private T selectedModel = null;

        public MasterViewModel()
        {
            Title = typeof(T).Name;
            Icon = string.Format(IconFormat, Title).ToLower() ;
            Models = new ObservableCollection<T>();
        }

        /// <summary>
        /// Gets or sets the "Users" property.
        /// </summary>
        /// <value>The users.</value>
        public const string SelectedModelPropertyName = "SelectedModel";
        public T SelectedModel
        {
            get { return selectedModel; }
            set { SetProperty(ref selectedModel, value, SelectedModelPropertyName); }
        }

        private Command saveSelectedModel;
        public Command SaveSelectedModel
        {
            get
            {
                return saveSelectedModel ?? (saveSelectedModel = new Command(ExecuteSaveSelectedModel));
            }
        }

        protected virtual async void ExecuteSaveSelectedModel()
        {
            using (var service = (IRepository<T>)GetDependency.Invoke(null, new object[] { DependencyFetchTarget.GlobalInstance }))
            {
                var model = await service.Update(SelectedModel);
                SelectedModel = model; // In case any updates propagate from the repository (e.g. updated id, etc.).
            }
        }

        public ObservableCollection<T> Models { get; private set; }

        private Command loadModelsCommand;
        public Command LoadModelsCommand
        {
            get
            {
                return loadModelsCommand ?? (loadModelsCommand = new Command(ExecuteLoadModelsCommand));
            }
        }

        protected virtual async void ExecuteLoadModelsCommand()
        {
            using (var service = (IRepository<T>)GetDependency.Invoke(null, new object[] { DependencyFetchTarget.GlobalInstance }))
            {
                var models = await service.All();

                foreach(var model in models)
                    Models.Add(model);
            }
            OnPropertyChanged("Models");

            using (var service = DependencyService.Get<UserRepository>())
            {
                var users = await service.All();
                Users = users;
            }

        }
    }

    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        private IEnumerable<IUser> users = new IUser[0];
        private string title = string.Empty;

        /// <summary>
        /// Gets or sets the "Users" property.
        /// </summary>
        /// <value>The users.</value>
        public const string UsersPropertyName = "Users";
        public IEnumerable<IUser> Users
        {
            get { return users; }
            set { SetProperty(ref users, value, UsersPropertyName); }
        }

        /// <summary>
        /// Gets or sets the "Title" property
        /// </summary>
        /// <value>The title.</value>
        public const string TitlePropertyName = "Title";
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value, TitlePropertyName); }
        }

        private string subTitle = string.Empty;
        /// <summary>
        /// Gets or sets the "Subtitle" property
        /// </summary>
        public const string SubtitlePropertyName = "Subtitle";
        public string Subtitle
        {
            get { return subTitle; }
            set { SetProperty(ref subTitle, value, SubtitlePropertyName); }
        }

        private string icon = null;
        /// <summary>
        /// Gets or sets the "Icon" of the viewmodel
        /// </summary>
        public const string IconPropertyName = "Icon";
        public string Icon
        {
            get { return icon; }
            set { SetProperty(ref icon, value, IconPropertyName); }
        }

        protected void SetProperty<U>(
            ref U backingStore, U value,
            string propertyName,
            Action onChanged = null,
            Action<U> onChanging = null)
        {
            if (EqualityComparer<U>.Default.Equals(backingStore, value))
                return;

            if (onChanging != null)
                onChanging(value);

            OnPropertyChanging(propertyName);

            backingStore = value;

            if (onChanged != null)
                onChanged();

            OnPropertyChanged(propertyName);
        }

        #region INotifyPropertyChanging implementation
        public event Xamarin.Forms.PropertyChangingEventHandler PropertyChanging ;
        #endregion

        public void OnPropertyChanging(string propertyName)
        {
            if (PropertyChanging == null)
                return;

            PropertyChanging(this, new Xamarin.Forms.PropertyChangingEventArgs(propertyName));
        }


        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
