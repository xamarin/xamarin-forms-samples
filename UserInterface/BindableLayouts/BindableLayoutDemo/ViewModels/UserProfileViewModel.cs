using BindableLayoutDemo.Models;

namespace BindableLayoutDemo.ViewModels
{
    public class UserProfileViewModel
    {
        public User User { get; }

        public UserProfileViewModel()
        {
            User = new User
            { 
                Username = "davidortinau",
                Email = "daortin@microsoft.com",
                TopFollowers = new string[]
                {
                    "https://avatars0.githubusercontent.com/u/36863?s=400&v=4",
                    "https://avatars2.githubusercontent.com/u/7827070?s=460&v=4",
                    "https://avatars0.githubusercontent.com/u/313003?s=400&v=4",
                    "https://avatars0.githubusercontent.com/u/538025?s=400&v=4",
                    "https://avatars2.githubusercontent.com/u/5375137?s=400&v=4",
                    "https://avatars3.githubusercontent.com/u/1235097?s=400&v=4",
                },
                FavoriteTech = new string[]
                {
                    ".NET", "C#", "Xamarin.Forms", "XAML", "SkiaSharp", "Azure"
                },
                Achievements = new string[]
                {
                    "\uf2d2", "\uf2ba", "\uf30c"
                }
            };
        }
    }
}
