using System;
using System.IO;
using System.Threading.Tasks;

namespace SkiaSharpFormsDemos
{
    public interface IPicturePicker
    {
        Task<Stream> GetImageStreamAsync();
    }
}