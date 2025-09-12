using System.Windows.Input;
using TrafficLight.Models;
using TrafficLight.ModelsLogic;

namespace TrafficLight.ViewModel
{
    class MainPageVM : ObservableObject
    {
        private ModelsLogic.TrafficLight trafficLight = new ();

        public ICommand changeLightCommand { get => new Command(ChangeLight); }

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
