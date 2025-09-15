using TrafficLight.ViewModel;

namespace TrafficLight
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            //Default by MAUI
            InitializeComponent();
            //Connecting between the view and the ViewModel!
            BindingContext = new MainPageVM();
        }
    }
}
