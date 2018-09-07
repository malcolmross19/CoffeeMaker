using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMaker
{
    public class CoffeeMaker
    {
        private Boiler _boiler;
        private BrewButton _brewButton;
        private IndicatorLight _indicatorLight;
        private PressureReliefValve _pressureReliefValve;
        private WarmerPlate _warmerPlate;
        private ICoffeeMakerAPI _hardware;

        public CoffeeMaker(ICoffeeMakerAPI hardware)
        {
            this._hardware = hardware;
            this._boiler = new Boiler(hardware);
            this._brewButton = new BrewButton(hardware);
            this._indicatorLight = new IndicatorLight(hardware);
            this._pressureReliefValve = new PressureReliefValve(hardware);
            this._warmerPlate = new WarmerPlate(hardware);

            this._brewButton.BrewButtonPushedEvent += (s, e) => StartBrewCycle();
            this._warmerPlate.WarmerStatusChangedEvent += (s, e) =>
            {
                if (e.WarmerStatus == WarmerStatus.WARMER_EMPTY)
                    StopBrewCycle();
            };
        }

        public void StartBrewCycle()
        {
            this._boiler.Start();
            this._pressureReliefValve.Close();
            this._indicatorLight.Off();
        }

        public void StopBrewCycle()
        {
            this._boiler.Stop();
            this._pressureReliefValve.Open();
            this._indicatorLight.On();
        }
    }
}
