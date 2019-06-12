namespace ChatServer
{
    public static class Constants
    {
        // NOTE: for clients to receive messages, this value must match
        // the value in the ChatClient Constants.cs file.
        public static string MessageName { get; set; } = "newMessage";
    }
}
