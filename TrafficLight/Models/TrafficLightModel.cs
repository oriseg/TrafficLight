using TrafficLight.ModelsLogic;

namespace TrafficLight.Models
{
    internal abstract class TrafficLightModel
    {
        public enum TrafficLightState
        {
            Red,
            RedYellow,
            Green,
            Yellow
        }
        public enum TrafficLight
        {
            Red,
            Yellow,
            Green
        }
        protected TrafficLightState state = TrafficLightState.Red;
        protected Light[] lights = { new Light(Colors.Red, true), new Light(Colors.Yellow, false), new Light(Colors.Green, false) };
        public EventHandler<LightChangedEventArgs>? LightChanged;
        public Color RedColor => lights[(int)TrafficLight.Red].Color;
        public Color YellowColor => lights[(int)TrafficLight.Yellow].Color;
        public Color GreenColor => lights[(int)TrafficLight.Green].Color;
        public abstract string LightImage { get; }
        public abstract void ChangeLight();
    }
}
