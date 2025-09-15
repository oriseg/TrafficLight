using TrafficLight.Models;

namespace TrafficLight.ModelsLogic
{
    internal class TrafficLight : TrafficLightModel
    {
        public override string LightImage => lightImage.GetLightImage(state);

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
                foreach (TrafficLight tl in Enum.GetValues<TrafficLight>())
                    LightChanged?.Invoke(this, new LightChangedEventArgs(tl));
            }
            else if (state == TrafficLightState.Green)
            {
                state = TrafficLightState.Yellow;
                lights[(int)TrafficLight.Yellow].isOn = true;
                lights[(int)TrafficLight.Green].isOn = false;
                foreach (TrafficLight tl in Enum.GetValues<TrafficLight>())
                    if (tl != TrafficLight.Red)
                        LightChanged?.Invoke(this, new LightChangedEventArgs(tl));
            }
            else if (state == TrafficLightState.Yellow)
            {
                state = TrafficLightState.Red;
                lights[(int)TrafficLight.Yellow].isOn = false;
                lights[(int)TrafficLight.Red].isOn = true;
                foreach (TrafficLight tl in Enum.GetValues<TrafficLight>())
                    if (tl != TrafficLight.Green)
                        LightChanged?.Invoke(this, new LightChangedEventArgs(tl));
            }
        }
    }
}
