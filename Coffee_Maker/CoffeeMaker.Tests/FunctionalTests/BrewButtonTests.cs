using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeMaker.Tests.Base;

namespace CoffeeMaker.Tests.FunctionalTests
{
    [TestClass]
    public class BrewButtonTests
    {
        private MockHardware _hardware;
        private BrewButton _brewButton;

        [TestInitialize]
        public void Initialize()
        {
            _hardware = new MockHardware();
            _brewButton = new BrewButton(_hardware);
        }

        [TestMethod]
        public void WhenTheBrewButtonStatusChangesThenItShouldThrowExactlyOneEvent()
        {
            int count = 0;
            _brewButton.BrewButtonPushedEvent += (s, e) => { count++; };
            _hardware.BrewButtonStatus = BrewButtonStatus.BREW_BUTTON_PUSHED;
            _brewButton.SampleHardware();
            _brewButton.SampleHardware();
            _brewButton.SampleHardware();
            Assert.AreEqual(1, count);
        }
    }
}
