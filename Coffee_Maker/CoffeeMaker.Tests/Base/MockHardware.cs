using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMaker.Tests.Base
{
    public class MockHardware : ICoffeeMakerAPI
    {
        public MockHardware()
        {
            this.BoilerState = BoilerState.BOILER_OFF;
            this.BoilerStatus = BoilerStatus.BOILER_EMPTY;
            this.BrewButtonStatus = BrewButtonStatus.BREW_BUTTON_NOT_PUSHED;
            this.IndicatorState = IndicatorState.INDICATOR_OFF;
            this.ReliefValveState = ReliefValveState.VALVE_OPEN;
            this.WarmerPlateState = WarmerState.WARMER_OFF;
            this.WarmerPlateStatus = WarmerStatus.WARMER_EMPTY;
        }

        public BoilerStatus GetBoilerStatus()
        {
            return this.BoilerStatus;
        }

        public void SetBoilerState(BoilerState boilerState)
        {
            this.BoilerState = boilerState;
        }

        public BrewButtonStatus GetBrewButtonStatus()
        {
            var button = this.BrewButtonStatus;
            if (button == BrewButtonStatus.BREW_BUTTON_PUSHED)
                this.BrewButtonStatus = BrewButtonStatus.BREW_BUTTON_NOT_PUSHED;
            return button;
        }

        public void SetIndicatorState(IndicatorState indicatorState)
        {
            this.IndicatorState = indicatorState;
        }

        public void SetReliefValveState(ReliefValveState reliefValveState)
        {
            this.ReliefValveState = reliefValveState;
        }

        public WarmerStatus GetWarmerPlateStatus()
        {
            return this.WarmerPlateStatus;
        }

        public void SetWarmerState(WarmerState warmerState)
        {
            this.WarmerPlateState = warmerState;
        }

        public BoilerState BoilerState { get; set; }

        public BoilerStatus BoilerStatus { get; set; }

        public BrewButtonStatus BrewButtonStatus { get; set; }

        public IndicatorState IndicatorState { get; set; }

        public ReliefValveState ReliefValveState { get; set; }

        public WarmerState WarmerPlateState { get; set; }

        public WarmerStatus WarmerPlateStatus { get; set; }
    }
}
