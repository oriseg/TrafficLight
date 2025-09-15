namespace TrafficLight.Models
{
    //Remember that in MainPageVM we had this method?
    //private void OnLightChanged(object? sender, LightChangedEventArgs e)
    //we agreed that the e is some kind of bundle that holds info about the event that just happend, but in this use, e just contains 
    //whatever properties this class has, means it only has an enum of the lights.
    internal class LightChangedEventArgs(TrafficLightModel.TrafficLight light) : EventArgs
    {
        //To make it clear, the light we define here, is the same light we are talking about in ColorChanged(e.light), that is in "private void OnLightChanged(object? sender, LightChangedEventArgs e)" that in MainPageVM.
        public TrafficLightModel.TrafficLight light { get; } = light;
        //There's a use in a primary constructor here as well. we get the enum called light in the header, and we assign it in the above line.
    }
}
