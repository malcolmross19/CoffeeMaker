using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMaker
{
    public class PressureReliefValve
    {
        private IReliefValve _hardware;

        public PressureReliefValve(IReliefValve hardware)
        {
            this._hardware = hardware;
        }

        public void Open()
        {
            this._hardware.SetReliefValveState(ReliefValveState.VALVE_OPEN);
        }

        public void Close()
        {
            this._hardware.SetReliefValveState(ReliefValveState.VALVE_CLOSED);
        }
    }
}
