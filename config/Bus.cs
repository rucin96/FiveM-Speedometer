using System;
using CitizenFX.Core;

namespace Speedometer.config
{
    public class Bus
    {
        private readonly EventHandlerDictionary _eventHandlers;

        public Bus(EventHandlerDictionary eventHandlers)
        {
            _eventHandlers = eventHandlers;
        }

        public Bus RegisterAction(string eventName, Action registerAction)
        {
            _eventHandlers[eventName] += registerAction;
            
            return this;
        }
    }
}