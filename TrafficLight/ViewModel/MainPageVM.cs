using Microsoft.Extensions.Logging;
using System.Threading.Channels;
using System.Windows.Input;      // gives you the ICommand interface
using TrafficLight.Models;       // for Color and LightChangedEventArgs
using TrafficLight.ModelsLogic;  // for the TrafficLight brain class

namespace TrafficLight.ViewModel
{
    class MainPageVM : ObservableObject /*It inherits from ObservableObject (a helper that raises PropertyChanged events so the UI updates when a property changes).*/
    {
        private ModelsLogic.TrafficLight trafficLight = new ();
        //This is a little box that holds your real traffic light logic (from the ModelsLogic folder).
        //The weird syntax is because the Traffic light class doesn't have a constuctor, so it just creates the object with the base class constructor (which is TrafficLightModel)

        public ICommand changeLightCommand { get => new Command(ChangeLight); }
        //ICommand is an interface for “something you can run from a button.”
        //Command(ChangeLight) builds a command object that calls the ChangeLight method when the button is tapped.
        //So, the button in XAML runs trafficLight.ChangeLight() through this property.

        public Color RedColor => trafficLight.RedColor;
        public Color YellowColor => trafficLight.YellowColor;
        public Color GreenColor => trafficLight.GreenColor;

        private void ChangeLight()
        {
            trafficLight.ChangeLight();
        }
        public MainPageVM()
        {
            trafficLight.LightChanged += OnLightChanged;
        }

        private void OnLightChanged(object? sender, LightChangedEventArgs e)
        {
            ColorChanged(e.light);
        }

        private void ColorChanged(TrafficLightModel.TrafficLight light)
        {
            switch (light)
            {
                case TrafficLightModel.TrafficLight.Red:
                    OnPropertyChanged(nameof(RedColor));
                    break;
                case TrafficLightModel.TrafficLight.Yellow:
                    OnPropertyChanged(nameof(YellowColor));
                    break;
                case TrafficLightModel.TrafficLight.Green:
                    OnPropertyChanged(nameof(GreenColor));
                    break;

            }
        }
    }
}
