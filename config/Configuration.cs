using System.Collections.Generic;
using CitizenFX.Core;

namespace Speedometer.config
{
    public class Configuration
    {
        private static Configuration _configuration;
        private readonly Container _container;
        private readonly Bus _bus;
        private Ped _player;
        private Dictionary<string, string> _settings;

        public static Configuration Create(Container container, Bus bus, Ped player, Dictionary<string, string> settings)
        {
            return _configuration ?? (_configuration = new Configuration(container, bus, player, settings));
        }
        
        public Configuration(Container container, Bus bus, Ped player, Dictionary<string, string> settings)
        {
            _container = container;
            _bus = bus;
            _player = player;
            _settings = settings;
        }
        
        public Container GetContainer() => _container;
        public Bus GetBus() => _bus;
        public Ped GetPlayer() => _player;
        public Dictionary<string, string> GetSettings() => _settings;
        public void SetPlayer(Ped player) => _player = player;
    }
}