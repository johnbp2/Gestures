namespace JohnBPearson.Windows.Forms.Gestures.Messaging
{
    public enum MessageType
    {

        Info = 1,
        Warning = 2,
        Error = 3
    }
    public struct Message
    {
        public MessageType type;
        public string message;
    }
}
