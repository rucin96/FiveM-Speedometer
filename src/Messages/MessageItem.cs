namespace Speedometer.Messages
{
    public class MessageItem
    {
        public MessageItem(string value, string type)
        {
            this.value = value;
            this.type = type;
        }

        public string value { get; }
        public string type { get; }
    }
}