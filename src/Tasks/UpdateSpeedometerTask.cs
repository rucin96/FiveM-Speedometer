using System;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using Speedometer.config;
using Speedometer.Dispatchers;
using Speedometer.Messages;

namespace Speedometer.Tasks
{
    public class UpdateSpeedometerTask : ITask
    {
        private readonly Configuration _configuration;
        private bool _isSpeedometerActive;

        public UpdateSpeedometerTask(Configuration configuration)
        {
            _configuration = configuration;
        }
        
        public void Run()
        {
            Ped player = _configuration.GetPlayer();
            NuiMessageDispatcher nuiMessageDispatcher = (NuiMessageDispatcher) _configuration.GetContainer().Get(typeof(NuiMessageDispatcher));
            bool isPlayerInCar = API.IsPedInAnyVehicle(player.Handle, false);
            string multiplier, multiplierType;
            _configuration.GetSettings().TryGetValue("multiplierValue", out multiplier);
            _configuration.GetSettings().TryGetValue("multiplierType", out multiplierType);

            UpdateParameters(isPlayerInCar, player, nuiMessageDispatcher, float.Parse(multiplier ?? "0"), multiplierType);
            UpdateDisplay(isPlayerInCar, nuiMessageDispatcher);
        }

        private static void UpdateParameters(bool isPlayerInCar, Ped player, NuiMessageDispatcher nuiMessageDispatcher, float multiplier, string multiplierType)
        {
            if (isPlayerInCar)
            {
                var currentVehicle = API.GetVehiclePedIsIn(player.Handle, false);
                var speed = API.GetEntitySpeed(currentVehicle) * multiplier;
                var rpm = API.GetVehicleCurrentRpm(currentVehicle);
                
                nuiMessageDispatcher.Dispatch(new JsonMessage()
                    .Add("type", "speed")
                    .Add("multiplierValue", Math.Floor(speed))
                    .Add("rpm", rpm)
                    .Add("multiplierType", multiplierType)
                    .ToString()
                );
            }
        }

        private void UpdateDisplay(bool isPlayerInCar, NuiMessageDispatcher nuiMessageDispatcher)
        {
            if (isPlayerInCar != _isSpeedometerActive)
            {
                nuiMessageDispatcher.Dispatch(new JsonMessage()
                    .Add("type", "enableui")
                    .Add("enable", isPlayerInCar)
                    .ToString()
                );
                _isSpeedometerActive = isPlayerInCar;
            }
        }
    }
}