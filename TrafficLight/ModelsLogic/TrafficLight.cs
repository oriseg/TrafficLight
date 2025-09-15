using TrafficLight.Models;

namespace TrafficLight.ModelsLogic
{
    //The class inherits form TrafficLightModel, since this class in the model logic.
    internal class TrafficLight : TrafficLightModel
    {
        //LightImage is a string property that when is called, returns the value that the GetLightImage returns when it is called
        //on the lightImage OBJECT (that is defined in the TrafficLightModel), with the current state (which is in the TrafficLightModel as well)
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
