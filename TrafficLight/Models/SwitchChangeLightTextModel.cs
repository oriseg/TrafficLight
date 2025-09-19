using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLight.Models
{
    internal abstract class SwitchChangeLightTextModel
    {
        public abstract string GetSwitchChangeLightText(bool isAutoChange);
    }
}
