using TrafficLight.Models;

namespace TrafficLight.ModelsLogic
{
    internal class LightImage : LightImageModel
    {
        public override string GetLightImage(TrafficLightModel.TrafficLightState state)
        {
            return lightImages[(int)state];
        }
    }
}
