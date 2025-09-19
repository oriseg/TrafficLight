using TrafficLight.Models;

namespace TrafficLight.ModelsLogic
{
    internal class SwitchChangeLightText : SwitchChangeLightTextModel
    {
        public override string GetSwitchChangeLightText(bool isAutoChange)
        {
            if (isAutoChange) { return Strings.constantStopChangeLightText; }
            else {  return Strings.constantStartChangeLightText; }
        }
    }
}
