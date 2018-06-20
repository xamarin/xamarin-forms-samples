using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DependencyServiceSample.Tizen;
using Tizen.Applications;
using Xamarin.Forms;

[assembly: Dependency(typeof(PicturePickerImplementation))]

namespace DependencyServiceSample.Tizen
{
    public class PicturePickerImplementation : IPicturePicker
    {
        public Task<Stream> GetImageStreamAsync()
        {
            string resultPath = "";
            TaskCompletionSource<Stream> tcs = new TaskCompletionSource<Stream>();

            AppControl appControl = new AppControl
            {
                Operation = AppControlOperations.Pick,
                Mime = "image/*",
            };

            AppControlReplyCallback callback = (launchRequest, replyRequest, result) =>
            {
                if (result == AppControlReplyResult.Succeeded)
                {
                    if (replyRequest.ExtraData.IsCollection(App​Control​Data.Selected))
                    {
                        resultPath = replyRequest.ExtraData.Get<IEnumerable<string>>(App​Control​Data.Selected).FirstOrDefault();
                        if (!string.IsNullOrEmpty(resultPath))
                            tcs.SetResult(new FileStream(resultPath, FileMode.Open, FileAccess.Read));
                        else
                            tcs.SetResult(null);
                    }
                    else
                    {
                        tcs.SetResult(null);
                    }
                }
            };
            try
            {
                AppControl.SendLaunchRequest(appControl, callback);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                tcs.SetResult(null);
            }
            return tcs.Task;
        }
    }
}