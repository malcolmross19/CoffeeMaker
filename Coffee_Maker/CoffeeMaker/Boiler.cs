using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMaker
{
    public class Boiler
    {
        private IBoiler _hardware;

        public Boiler(IBoiler hardware)
        {
            this._hardware = hardware;
        }

        public void Start()
        {
            this._hardware.SetBoilerState(BoilerState.BOILER_ON);
        }

        public void Stop()
        {
            this._hardware.SetBoilerState(BoilerState.BOILER_OFF);
        }
    }
}
