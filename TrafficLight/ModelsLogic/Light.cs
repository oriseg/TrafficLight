using TrafficLight.Models;

namespace TrafficLight.ModelsLogic
{
    internal class Light(Color color, bool isOn) : LightModel(color, isOn)
    {
        public override Color Color => isOn ? color : Colors.White;
    }
}
