using TrafficLight.ModelsLogic;

namespace TrafficLight.Models
{
    //The class is abstract, means there got to be a class that inherits from it and initialize the method that has "abstract" in them!
    //This class is the TrafficLightModel, holds variables that are necessary for the TrafficLight.cs (model logic) to run.
    //The class does not contain a code, only variables!
    internal abstract class TrafficLightModel
    {
        //The enum (which is a weird data structure, a little similar to an array), that hold the different states that the traffic light can have.
        public enum TrafficLightState
        {
            Red,
            RedYellow,
            Green,
            Yellow
        }
        //Another enum that contains the different lights and colors there are in a traffic light.
        public enum TrafficLight
        {
            Red,
            Yellow,
            Green
        }
        protected TrafficLightState state = TrafficLightState.Red;//sets a state variable, holding the current state. obviously, the first one will be red.
        //An array of type Light (that is a class on its own) that contains the lights of a traffic light in every moment. each light
        //in it has 2 properties - color, which is a type of color (a class defined in C#), and isOn - determines if the light is on or off.
        protected Light[] lights = { new Light(Colors.Red, true), new Light(Colors.Yellow, false), new Light(Colors.Green, false) };

        //This is the cool part. LightChanged is a kind of an event. Literally, it's a list of a lot of methods that runs everytime
        //we do the Invoke part. Where it happens:
        //1. In MainPageVM, this is the constructor, it adds the method "OnLightChanged to the event list:
        //public MainPageVM() { trafficLight.LightChanged += OnLightChanged; }
        //Since "OnLightChanged()" has 2 parameters (object? sender, LightChangedEventArgs e), everytime some trigger wants to call it,
        //it will have to write two parameters of the same types, but where does it happens?
        //2. In TrafficLight.cs, we got this line, for example:
        //LightChanged?.Invoke(this, new LightChangedEventArgs(tl));
        //The LightChanged relates to the event, and the invoke just tells it to run all the methods that are in the events list, with those parametes.
        //In conclusion, LightChanged is a list of method. To add to the list, you do LightChanged += {name-of-method}. To run the method in this list, you do LightChanged.Invoke({param1}, {param2})
        public EventHandler<LightChangedEventArgs>? LightChanged;

        //Whenever someone searches for the RedColor from TrafficLightModel, these will run. They return the color property of one of
        //the things in the lights array, in the index of the wanted color position in the enum.
        //RedColor example:
        //TrafficLight.Red is a thing in the enum.
        //Casting it to (int)TrafficLight.Red, returns its index in the enum.
        //lights[(int)TrafficLight.Red] returns a light type thing in the lights array (defined in line 28).
        //lights[(int)TrafficLight.Red].Color go to the LightModel and gets the color of the light, type color (C# built in namespace).
        public Color RedColor => lights[(int)TrafficLight.Red].Color;
        public Color YellowColor => lights[(int)TrafficLight.Yellow].Color;
        public Color GreenColor => lights[(int)TrafficLight.Green].Color;
        public abstract string LightImage { get; }//a string that defines the path/the name of the image we want to currently be displayed. for example: "crysmiley.jpg"
        protected LightImage lightImage = new();//defines a LightImage type variable that we will use to retrieve the LightImage string every time the ChangeButton is clicked
        public abstract void ChangeLight();//abstract ChangeLight, so TrafficLight will have to implement it.
    }
}
