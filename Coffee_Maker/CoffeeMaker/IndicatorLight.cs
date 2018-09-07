using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMaker
{
    public class IndicatorLight
    {
        private IIndicatorLight _hardware;

        public IndicatorLight(IIndicatorLight hardware)
        {
            this._hardware = hardware;
        }

        public void On()
        {
            this._hardware.SetIndicatorState(IndicatorState.INDICATOR_ON);
        }

        public void Off()
        {
            this._hardware.SetIndicatorState(IndicatorState.INDICATOR_OFF);
        }
    }
}
