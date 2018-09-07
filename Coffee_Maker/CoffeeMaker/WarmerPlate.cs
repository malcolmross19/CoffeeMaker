using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoffeeMaker
{
    public class WarmerPlate
    {
        private IWarmerPlate _hardware;
        private Timer _timer;
        private  WarmerStatus _warmerStatus;

        public event EventHandler<WarmerStatusEventArgs> WarmerStatusChangedEvent;

        public WarmerPlate(IWarmerPlate hardware)
        {
            this._hardware = hardware;
            this._warmerStatus = _hardware.GetWarmerPlateStatus();
            this._timer = new Timer(new TimerCallback(SampleHardwareCallback), null, 0, 1000);
        }

        private void SampleHardwareCallback(object o)
        {
            SampleHardware();
        }

        public void SampleHardware()
        {
            var status = _hardware.GetWarmerPlateStatus();

            if (status != _warmerStatus)
            {
                _warmerStatus = status;

                if (_warmerStatus == WarmerStatus.POT_NOT_EMPTY)
                {
                    _hardware.SetWarmerState(WarmerState.WARMER_ON);
                }
                else
                {
                    _hardware.SetWarmerState(WarmerState.WARMER_OFF);
                }

                if (WarmerStatusChangedEvent != null)
                    WarmerStatusChangedEvent(this, new WarmerStatusEventArgs { WarmerStatus = _warmerStatus });
            }
        }
    }

    public class WarmerStatusEventArgs : EventArgs
    { 
        public WarmerStatus WarmerStatus { get; set; }
    }
}
