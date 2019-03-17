using OfflineCurrencyConverter.Services.PerPlatform;
using OfflineCurrencyConverter.Shared;
using Plugin.Share;
using Plugin.Share.Abstractions;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;
using Xamarin.Forms;

namespace OfflineCurrencyConverter.ViewModels
{
    public class ShareAppPopupViewModel<T> : BaseViewModel<T>
    {
        public ReactiveCommand<Unit, Unit> ShareCommand { get; set; }
        public ReactiveCommand<Unit, Unit> CancelCommand { get; set; }

        private string _shareMessage;

        public string ShareMessage
        {
            get { return _shareMessage; }
            set { this.RaiseAndSetIfChanged(ref _shareMessage, value); }
        }
        
        public ShareAppPopupViewModel()
        {
            ShareMessage = "ShareCurrencyConv".Translate();
            ShareCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                if (!CrossShare.IsSupported)
                    return;

                await CrossShare.Current.Share(new ShareMessage
                {
                    Text = ShareMessage,
                    Url = DependencyService.Get<IPerPlatformUtilities>().GetStoreLink()
                });
            }, this.WhenAnyValue(x => x.ShareMessage, sm => !string.IsNullOrEmpty(sm)));
            CancelCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                await _navService.ClosePopupAsync();
            });
        }
    }
}
