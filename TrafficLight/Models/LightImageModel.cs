namespace TrafficLight.Models
{
    //The Model that implements the LightImage changing. ABSTRACT, so there'll be a ModelsLogic.LightImage that inherits from it.
    internal abstract class LightImageModel
    {
        //An array with the names of the images, so ModelsLogic.LightImage will use it. Protected, so ModelsLogic.LightImage will have it override.
        protected string[] lightImages = ["crysmiley.jpg", "thinksmile.jpg", "happeysmile.jpg", "thinksmile2.jpg"];
        //A method that returns the name of the image we need to display now, based on the current state from the TrafficLightModel. abstract.
        public abstract string GetLightImage(TrafficLightModel.TrafficLightState state);
    }
}
