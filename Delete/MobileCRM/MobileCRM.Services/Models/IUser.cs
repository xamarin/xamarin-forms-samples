using System;

namespace MobileCRM.Services
{
    public interface IUser
    {
        object Id { get; }
        string Username { get; }
    }
}

