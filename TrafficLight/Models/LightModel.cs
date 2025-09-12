namespace TrafficLight.Models
{
    abstract class LightModel(Color color, bool isOn)
    {
        public bool isOn { get; set; } = isOn;
        protected Color color = color;
        public abstract Color Color { get; }
    }
}
