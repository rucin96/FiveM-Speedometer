using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core;
using Speedometer.config;
using Speedometer.Dispatchers;
using Speedometer.Events.Client;
using Speedometer.Factory;
using Speedometer.Listeners.Client;
using Speedometer.Tasks;

namespace Speedometer
{
    public class Main : BaseScript
    {
        private readonly Configuration _configuration;
        private List<ITask> _tasks = new List<ITask>();

        public Main()
        {
            _configuration = Configuration.Create(
                Container.GetContainer(), 
                new Bus(EventHandlers),
                Game.Player.Character,
                new Dictionary<string, string>()
            );

            ConfigureContainer();
            ConfigureEvents();
            ConfigureTasks();
            ConfigureSettings();
            
            Tick += OnTick;
        }

        private void ConfigureSettings()
        {
            Dictionary<string, string> settings = _configuration.GetSettings();
            IniFile iniSettings = new IniFile("settings.ini");
            string multiplierType = iniSettings.Read("MULTIPLIER");
            settings.Add("multiplierType", multiplierType);
            settings.Add("multiplierValue", (new MultiplierFactory(multiplierType).Get().ToString()));
        }

        private void ConfigureContainer()
        {
            Container container = _configuration.GetContainer();
            
            container.Register<NuiMessageDispatcher>(new NuiMessageDispatcher());
            container.Register<PlayerSpawnedListener>(new PlayerSpawnedListener(_configuration));
        }
        
        private void ConfigureEvents()
        { 
            Container container = _configuration.GetContainer();
            Bus bus = _configuration.GetBus();
            
            bus.RegisterAction(PlayerSpawned.Name, ((PlayerSpawnedListener) container.Get(typeof(PlayerSpawnedListener))).Invoke);
        }

        private void ConfigureTasks()
        {
            _tasks.Add(new UpdateSpeedometerTask(_configuration));
        }

        private async Task OnTick()
        {
            await Delay(1);
            
            foreach (ITask task in _tasks)
            {
                task.Run();
            }
        }
    }
}