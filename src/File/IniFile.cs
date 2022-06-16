using System.IO;
using CitizenFX.Core.Native;

namespace Speedometer.config
{
    public class IniFile
    {
        StringReader reader;

        public IniFile(string name)
        {
            string data = Function.Call<string>(Hash.LOAD_RESOURCE_FILE, "Speedometer", name);
            reader = new StringReader(data);
        }

        public string Read(string key, string section = null)
        {
            string line = null;
            while ((line = reader.ReadLine()) != null)
            {
                line = line.Trim();
                if (!line.StartsWith(key) || !line.Contains("="))
                {
                    continue;
                }

                return line.Substring(line.LastIndexOf("=") + 1);
            }

            return "";
        }

        public bool KeyExists(string key, string section = null)
        {
            return Read(key, section).Length > 0;
        }
    }
}