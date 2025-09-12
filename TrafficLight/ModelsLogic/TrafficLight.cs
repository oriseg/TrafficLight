using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLight.Models;

namespace TrafficLight.ModelsLogic
{
    internal class TrafficLight : TrafficLightModel
    {
        public override void ChangeLight()
        {
            if (state == TrafficLightState.Red)
            {
                state = TrafficLightState.RedYellow;
                lights[(int)TrafficLight.Yellow].isOn = true;
                LightChanged?.Invoke(this, new LightChangedEventArgs(TrafficLight.Yellow));
            }
            else if (state == TrafficLightState.RedYellow)
            {
                state = TrafficLightState.Green;
                lights[(int)TrafficLight.Yellow].isOn = false;
                lights[(int)TrafficLight.Red].isOn = false;
                lights[(int)TrafficLight.Green].isOn = true;
                LightChanged?.Invoke(this, new LightChangedEventArgs(TrafficLight.Yellow));
                LightChanged?.Invoke(this, new LightChangedEventArgs(TrafficLight.Red));
                LightChanged?.Invoke(this, new LightChangedEventArgs(TrafficLight.Green));
            }
            else if (state == TrafficLightState.Green)
            {
                state = TrafficLightState.Yellow;
                lights[(int)TrafficLight.Yellow].isOn = true;
                lights[(int)TrafficLight.Green].isOn = false;
                LightChanged?.Invoke(this, new LightChangedEventArgs(TrafficLight.Yellow));
                LightChanged?.Invoke(this, new LightChangedEventArgs(TrafficLight.Green));
            }
            else if (state == TrafficLightState.Yellow)
            {
                state = TrafficLightState.Red;
                lights[(int)TrafficLight.Yellow].isOn = false;
                lights[(int)TrafficLight.Red].isOn = true;
                LightChanged?.Invoke(this, new LightChangedEventArgs(TrafficLight.Yellow));
                LightChanged?.Invoke(this, new LightChangedEventArgs(TrafficLight.Red));
            }
        }
    }
}
