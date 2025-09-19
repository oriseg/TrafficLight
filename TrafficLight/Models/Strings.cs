namespace TrafficLight.Models
{
    //The ideal in apps is to not write any text that will be displayed in the app in the xml code or other tags code.
    //For that, we have this class. It's a static class, means none of it values can be changed, where we just write our text.
    //Whatever we write here is retrieved in the xml.
    static class Strings
    {
        public const string changeLightText = "Change Light";
        public const string constantStartChangeLightText = "Start Auto Change";
        public const string constantStopChangeLightText = "Stop Auto Change";
    }
}
