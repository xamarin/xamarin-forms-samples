using Xamarin.Forms;

namespace UsingResxLocalization
{
    public static class ImagePathHelper
    {
        public static string FilePath(string fileName)
        {
            switch (Device.OS)
            {
                case TargetPlatform.iOS:
                    return fileName;
                case TargetPlatform.Android:
                    return fileName;
                case TargetPlatform.WinPhone:
                    return fileName;
                case TargetPlatform.Windows:
                    return $"Assets/Images/{fileName}";
                case TargetPlatform.Other:
                default:
                    return fileName;
            }
        }

    }
}
