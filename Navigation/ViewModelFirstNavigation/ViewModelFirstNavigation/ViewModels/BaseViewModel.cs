using System;
using System.ComponentModel;
using ViewModelFirstNavigation.Interfaces;
namespace ViewModelFirstNavigation.ViewModels
{
    public class BaseViewModel : IViewModelBase
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
