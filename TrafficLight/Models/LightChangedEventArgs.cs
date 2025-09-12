namespace TrafficLight.Models
{
    internal class LightChangedEventArgs(TrafficLightModel.TrafficLight light) : EventArgs
    {
        public TrafficLightModel.TrafficLight light { get; } = light;

    }
}
