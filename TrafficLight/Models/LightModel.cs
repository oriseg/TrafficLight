namespace TrafficLight.Models
{
    //A class that simply represents a Light. abstract, hinting we will also have a ModelsLogin.Light.
    abstract class LightModel(Color color, bool isOn)//Primary constructor, just adding the constructor to the header.
    {
        public bool isOn { get; set; } = isOn;//isOn is a property that can be acheived (get) by other classes and also be set by them. its initial value is the isOn appears in the header.
        protected Color color = color;//color is a protected type color that defines the color of the light when its on. 
        public abstract Color Color { get; }//defines the color property that'll be used in the ModelsLogin.Light, the class that inherits from it.
    }
}
