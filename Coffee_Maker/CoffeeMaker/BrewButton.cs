using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoffeeMaker
{
    public class BrewButton
    {
        private IBrewButton _hardware;
        private Timer _timer;
        private BrewButtonStatus _brewButtonStatus;

        public event EventHandler<EventArgs> BrewButtonPushedEvent;

        public BrewButton(IBrewButton hardware)
        {
            this._hardware = hardware;
            this._brewButtonStatus = _hardware.GetBrewButtonStatus();
            this._timer = new Timer(new TimerCallback(SampleHardwareCallback), null, 0, 1000);
        }

        private void SampleHardwareCallback(object o)
        {
            SampleHardware();
        }

        public void SampleHardware()
        {
            var status = _hardware.GetBrewButtonStatus();

            if (status != _brewButtonStatus)
            {
                _brewButtonStatus = status;

                if (_brewButtonStatus == BrewButtonStatus.BREW_BUTTON_PUSHED)
                {
                    if (BrewButtonPushedEvent != null)
                        BrewButtonPushedEvent(this, new EventArgs());
                }
            }
        }
    }
}
