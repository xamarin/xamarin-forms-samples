using Xamarin.Forms;

namespace MediaElementDemos.Models
{
    public class MediaInfo
    {
        public string DisplayName { get; set; }
        public MediaSource Source { get; set; }

        public override string ToString()
        {
            return DisplayName;
        }
    }
}
