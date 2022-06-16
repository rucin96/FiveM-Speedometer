using System.Collections.Generic;

namespace Speedometer.Messages
{
    /**
     * This is hack because Newtonsoft.Json don't work.
     * It should work on v12.0.2 portable-net40+sl5+win8+wp8+wpa81 but for some reasons it doesn't.
     */
    public class JsonMessage
    {
        private readonly Dictionary<string, MessageItem> data = new Dictionary<string, MessageItem>();

        public JsonMessage Add(string key, string value)
        {
            data.Add(key, new MessageItem(value, "string"));

            return this;
        }

        public JsonMessage Add(string key, int value)
        {
            data.Add(key, new MessageItem(value.ToString(), "int"));

            return this;
        }

        public JsonMessage Add(string key, double value)
        {
            data.Add(key, new MessageItem(value.ToString(), "double"));

            return this;
        }

        public JsonMessage Add(string key, bool value)
        {
            data.Add(key, new MessageItem(value.ToString(), "bool"));

            return this;
        }

        public override string ToString()
        {
            var message = "{";
            var messages = new Dictionary<string, string>();

            foreach (var entry in data)
            {
                var element = "\"" + entry.Key + "\":";

                switch (entry.Value.type)
                {
                    case "string":
                        element += "\"" + entry.Value.value + "\"";
                        break;
                    case "double":
                        element += float.Parse(entry.Value.value);
                        break;
                    case "int":
                        element += int.Parse(entry.Value.value);
                        break;
                    case "bool":
                        element += entry.Value.value.ToLower();
                        break;
                }

                messages.Add(entry.Key, element);
            }

            message += string.Join(",", messages.Values);
            message += "}";

            return message;
        }
    }
}