using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TrafficLight.Models
{
    //So this class kind of tricky, and I'll explain some behind-the-class things.
    //we got an event defined in TrafficLighModel, named LightChanged. Whenever a light change, TrafficLight.cs knows to invoke the methods
    //that are in the list. By that, whenever TrafficLight.cs says so, OnLightChanged (from MainPageVM) runs, calls ColorChanged method.
    //There, the class looks at which light changed and calls OnPropertyChanged({changed-to-color}). This is where this class enters the frame:
    //We define an event named PropertyChanged of type PropertyChangedEventHandler, a type that is defined in INotifyPropertyChanged,
    //built in C#/MAUI namespace. In the OnPropertyChanged method, we let the PropertyChanged know that there might be a property 
    //named "[CallerMemberName]" that might have just changed. The INotifyPropertyChanged/C#/MAUI hears that an element's property
    //have just changed, and they refresh it, makes sure the change will be displayed.
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;//Event binded to MAUI/C# namespaces
        //A method that triggers the event, getting the parameter of what property have changed ([CallerMemberName] lets you get the name of who called this method)
        protected void OnPropertyChanged([CallerMemberName] string? propertyChanged = null)
        {
            //The actual trigger:
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyChanged));
        }
    }
}
