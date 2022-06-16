using CitizenFX.Core;
using Speedometer.config;

namespace Speedometer.Listeners.Client
{
    public class PlayerSpawnedListener : IListener
    {
        private Configuration _configuration;

        public PlayerSpawnedListener(Configuration configuration)
        {
            _configuration = configuration;
        }
        
        public void Invoke()
        {
            _configuration.SetPlayer(Game.Player.Character);
        }
    }
}