using TrafficLight.Models;

namespace TrafficLight.ModelsLogic
{
    //The model login of the LightImage. inherits from LightImageModel.
    //This class job is to keep the displayed image updated.
    internal class LightImage : LightImageModel
    {
        //A method that returns the name of the image we need to display now, based on the current state from the TrafficLightModel. override.
        public override string GetLightImage(TrafficLightModel.TrafficLightState state)
        {
            return lightImages[(int)state];
        }
    }
}
