using Microsoft.Extensions.Logging;
using System.Threading.Channels;
using System.Windows.Input;      
using TrafficLight.Models;       
using TrafficLight.ModelsLogic;  

namespace TrafficLight.ViewModel
{
    class MainPageVM : ObservableObject 
    {
        private ModelsLogic.TrafficLight trafficLight = new();
        public ICommand changeLightCommand { get => new Command(ChangeLight); }
        public ICommand SwitchAutoChangeCommand { get => new Command(SwitchAutoChange); }
        public ICommand SumbitTimeCommand { get => new Command(SubmitTime); }

        public Color RedColor => trafficLight.RedColor;
        public Color YellowColor => trafficLight.YellowColor;
        public Color GreenColor => trafficLight.GreenColor;
   
        public string SwitchChangeLightText => trafficLight.SwitchChangeLightText;
        public string LightImage => trafficLight.LightImage;
        public int CurrentSecondsChange { get => trafficLight.CurrentSecondsChange; set => trafficLight.CurrentSecondsChange = value; }
        private void SubmitTime()
        {
            trafficLight.SubmitTime();
        }
        private void ChangeLight()
        {
            trafficLight.ChangeLight();
        }

        private void SwitchAutoChange()
        {
            trafficLight.SwitchAutoChange();
            OnPropertyChanged(nameof(SwitchChangeLightText));
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
            OnPropertyChanged(nameof(LightImage));
        }
    }
}
