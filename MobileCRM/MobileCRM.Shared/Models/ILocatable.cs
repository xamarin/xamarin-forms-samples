using System;

namespace MobileCRM.Models
{
    public interface ILocatable
    {
        double Latitude { get; }
        double Longitude { get; }
    }
}

