namespace TrafficLight.Models
{
    internal abstract class LightImageModel
    {
        protected string[] lightImages = ["crysmiley.jpg", "thinksmile.jpg", "happeysmile.jpg", "thinksmile2.jpg"];
        public abstract string GetLightImage(TrafficLightModel.TrafficLightState state);
    }
}
