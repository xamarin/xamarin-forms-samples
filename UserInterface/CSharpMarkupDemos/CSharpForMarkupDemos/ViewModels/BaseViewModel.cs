using System.ComponentModel;
using CSharpForMarkupDemos.Helpers;

namespace CSharpForMarkupDemos.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Check this property when you receive events from outside the viewmodel, e.g. from services.
        /// If IsShowing is true then it is a good time to update data-bound properties;
        /// if IsShowing is false then you could set a dirty flag, so later in OnShow() you can retrieve 
        /// changed data and update any changed data-bound properties.
        /// </summary>
        public bool IsShowing { get; private set; }
        
        /// <summary>
        /// This method is called when a view becomes visible. 
        /// You can override this method to update
        /// data-bound properties for any changes that originated from outside the viewmodel, 
        /// e.g. changes in service model objects that you were notified about in service events that you
        /// subscribed to in the viewmodel.
        /// 
        /// Always call base.OnShow() at the start of your method when you override it!
        /// 
        /// The view base classes call this method on the following view lifecycle events: 
        /// iOS:     TODO
        /// Android: TODO
        /// Windows: OnNavigatedTo
        /// </summary>
        public virtual void OnShow()
        {
            IsShowing = true;
        }

        /// <summary>
        /// This method is called when a view becomes invisible. 
        /// You can override this method to handle any tasks that do not belong in OnUserInteractionStopped().
        /// 
        /// Always call base.OnHide() at the end of your method when you override it!
        /// 
        /// The view base classes call this method on the following view lifecycle events: 
        /// iOS:     TODO
        /// Android: TODO
        /// Windows: OnNavigatingFrom
        /// </summary>
        public virtual void OnHide()
        {
            IsShowing = false;
            OnUserInteractionStopped();
        }

        /// <summary>
        /// This method is called when the user is done interacting with the viewmodel.
        /// <example>E.g. override this method to save changes in the viewmodel without the need for a save button.</example>
        /// <remarks>The standard QuickCross implementation will call this method from lifecycle events,
        /// such as when the app is stopped or when navigating away from a view.
        /// You could also call this method on other moments, e.g. when the user is inactive for a number of seconds.</remarks>
        /// </summary>
        public virtual void OnUserInteractionStopped() { }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                TaskHelper.RunOnUIThread(() => handler(this, new PropertyChangedEventArgs(propertyName)));
        }
        #endregion
    }
}
