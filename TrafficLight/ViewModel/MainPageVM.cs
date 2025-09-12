using System.Windows.Input;

namespace TrafficLight.ViewModel
{
    class MainPageVM
    {
        public ICommand changeLightCommand { get; }
        public MainPageVM()
        {
            changeLightCommand = new Command(changeLight);
        }

        private void changeLight()
        {
            
        }
    }
}
