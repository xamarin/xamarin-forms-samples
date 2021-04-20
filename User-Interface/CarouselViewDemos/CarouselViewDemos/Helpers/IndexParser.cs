using System.Linq;

namespace CarouselViewDemos.Helpers
{
    public static class IndexParser
    {
        public static int ParseToken(string value)
        {
            if (!int.TryParse(value, out int index))
            {
                return -1;
            }
            return index;
        }
    }
}
