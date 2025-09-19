﻿using Microsoft.Extensions.Logging;
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
        //So, the button in XAML runs trafficLight.ChangeLight() through this property. More correctly, it calls the method in this class, which automatically calls trafficLight.ChangeLight().

        public ICommand SwitchAutoChangeCommand { get => new Command(SwitchAutoChange); }

        public Color RedColor => trafficLight.RedColor;
        public Color YellowColor => trafficLight.YellowColor;
        public Color GreenColor => trafficLight.GreenColor;
   
        public string SwitchChangeLightText => trafficLight.SwitchChangeLightText;
        public string LightImage => trafficLight.LightImage;
        public string CurrentTimerChange => trafficLight.TimerChange;
        private void ChangeLight()
        {
            trafficLight.ChangeLight();
        }

        private void SwitchAutoChange()
        {
            trafficLight.SwitchAutoChange();
            OnPropertyChanged(nameof(SwitchChangeLightText));
        }

        //When the app creates a new MainPageVM, this method runs, as a constructor.
        //trafficLight.LightChanged is an event coming from TrafficLightModel.
        //+= OnLightChanged means: “Whenever trafficLight says a light has changed, please call my OnLightChanged method.”
        //This is like handing someone your phone number. It will not call it immidently, but he will when its necessary.
        //MORE INFO IN TRAFFICLIGHTMODEL
        public MainPageVM()
        {
            trafficLight.LightChanged += OnLightChanged;
        }

        //Not sure why the sender is a necessary parameter, but whatever.
        //This method is not called through the MainPageVM method, but by the ChangeLight() method in ModelsLogic.TrafficLight, where it
        //provides the 2 parameters (in all the invokes who share "this, new LightChangedEventArgs(TrafficLight.{some-color})").
        //As much as I understood, LightChangedEventArgs is some sort of a bundle contains a lot of information about the event that just
        //happend. Usually, SomethingEventArgs means “info about a Something event.”
        //The method calls the ColorChanged method with only the e.Light, which is a type of a thing in the TrafficLightModel TrafficLight enum (that will be explained later).
        private void OnLightChanged(object? sender, LightChangedEventArgs e)
        {
            ColorChanged(e.light);
        }

        //As mentioned, this method recieves as a parameter only a one thing from the TrafficLightModel enum, which must be a color.
        //The method checks what color did he get (which can only be those that are in the enum, red, yellow are green), and calls
        //the OnPropertyChanged method (that is in the ObservableObjects.cs class) with the parameter nameof({some-color}), 
        //which basically returns the string "some-color", means for the first scenerio it will called with the string parameter
        //"RedColor", etc.
        //As metioned before, this method is going to run everytime the Change Light button clicked.
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
