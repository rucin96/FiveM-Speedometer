using CitizenFX.Core.Native;

namespace Speedometer.Dispatchers
{
    public class NuiMessageDispatcher
    {
        public void Dispatch(string message)
        {
            API.SendNuiMessage(message);
        }
    }
}