using TrafficLight.Models;

namespace TrafficLight.ModelsLogic
{
    //The class inherits form TrafficLightModel, since this class in the model logic.
    internal class TrafficLight : TrafficLightModel
    {
        //LightImage is a string property that when is called, returns the value that the GetLightImage returns when it is called
        //on the lightImage OBJECT (that is defined in the TrafficLightModel), with the current state (which is in the TrafficLightModel as well)
        public override string LightImage => lightImage.GetLightImage(state);
        public override Color AutoBackground { get; set; } = Color.Parse("#512BD4");
        public override string constantChangeLightText { get; set; } = Models.Strings.constantStartChangeLightText;
        public bool ToggleAuto = false;
        public override async void AutoChangeLight()
        {
            if (!ToggleAuto)
            {
                ToggleAuto = true;
                AutoBackground = Colors.Red;
                constantChangeLightText = Models.Strings.constantStopChangeLightText;
                await AutoChangeLightExecuter();
            }
            else
            {
                ToggleAuto = false;
                constantChangeLightText = Models.Strings.constantStartChangeLightText;
                AutoBackground = Color.Parse("#512BD4");
            }
        }

        public async Task AutoChangeLightExecuter()
        {
            while (ToggleAuto)
            {
                ChangeLight();
                await Task.Delay(1000);
            }
        }


        //The main method that handles the light change.
        //Breakdown inside the method.
        public override void ChangeLight()
        {
            //Checks if the current state (as the enum defined in TrafficLightModel) is red. If yes, enters.
            if (state == TrafficLightState.Red)
            {
                state = TrafficLightState.RedYellow;//Changes the current state to the red + yellow, in the TrafficLightState enum.
                lights[(int)TrafficLight.Yellow].isOn = true;//Updates the array in the model for the current light change, setting the yellow on.
                LightChanged?.Invoke(this, new LightChangedEventArgs(TrafficLight.Yellow));//literally, what changes the lights background. calls the Invoke method by the parameters this (which is the TrafficLight type variable, named trafficLight), and a thing from the TrafficLightModel enum.
            }
            else if (state == TrafficLightState.RedYellow)
            {
                state = TrafficLightState.Green;//Changes the current state to the green, in the TrafficLightState enum.
                //Updates the array in the model for the current light change, setting the green on and the rest off.
                lights[(int)TrafficLight.Yellow].isOn = false;
                lights[(int)TrafficLight.Red].isOn = false;
                lights[(int)TrafficLight.Green].isOn = true;
                //For each thing in the enum (right now every "thing" is defined as tl), it calls the invoke method.
                //for each is a kind of loop that runs for every thing in a container. in this example, Enum.GetValues<TrafficLight>() returns
                //an array of the constants in the enum, so it will run 3 times, for every light in the enum.
                foreach (TrafficLight tl in Enum.GetValues<TrafficLight>())
                    LightChanged?.Invoke(this, new LightChangedEventArgs(tl));
            }
            else if (state == TrafficLightState.Green)
            {
                //Changes the current state to the yellow, in the TrafficLightState enum.
                state = TrafficLightState.Yellow;
                //Updates the array in the model for the current light change, setting the green off and the yellow on.
                lights[(int)TrafficLight.Yellow].isOn = true;
                lights[(int)TrafficLight.Green].isOn = false;
                //The same "for each", but now it runs for every thing in the enum, that is not the red. The reason we want that is because
                //yellow and green are the only lights going through a change. red stays off in the change between green on to yellow on.
                foreach (TrafficLight tl in Enum.GetValues<TrafficLight>())
                    if (tl != TrafficLight.Red)
                        LightChanged?.Invoke(this, new LightChangedEventArgs(tl));
            }
            else if (state == TrafficLightState.Yellow)
            {
                //Changes the current state to the red, in the TrafficLightState enum.
                state = TrafficLightState.Red;
                //Updates the array in the model for the current light change, setting the yellow off and the red on.
                lights[(int)TrafficLight.Yellow].isOn = false;
                lights[(int)TrafficLight.Red].isOn = true;
                //The same "for each", but now it runs for every thing in the enum, that is not the green. The reason we want that is because
                //yellow and red are the only lights going through a change. green stays off in the change between yellow on to red on.
                foreach (TrafficLight tl in Enum.GetValues<TrafficLight>())
                    if (tl != TrafficLight.Green)
                        LightChanged?.Invoke(this, new LightChangedEventArgs(tl));
            }
        }
    }
}
