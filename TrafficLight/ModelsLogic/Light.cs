using TrafficLight.Models;

namespace TrafficLight.ModelsLogic
{
    //The model logic of the light! inherits from LightModel
    internal class Light(Color color, bool isOn) : LightModel(color, isOn)
    {
        //The background color of the lamp is depend on 2 things. The color when is on, and is on.
        //This line checks if the light is on. if it is, it sets the Color to be the given color in the header.
        //If it doesn't, it sets the color to be Colors.White.
        public override Color Color => isOn ? color : Colors.White;
    }
}
