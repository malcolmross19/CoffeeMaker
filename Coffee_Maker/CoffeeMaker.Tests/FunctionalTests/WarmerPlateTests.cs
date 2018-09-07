using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeMaker.Tests.Base;

namespace CoffeeMaker.Tests.FunctionalTests
{
    [TestClass]
    public class WarmerPlateTests
    {
        private MockHardware _hardware;
        private WarmerPlate _warmerPlate;

        [TestInitialize]
        public void Initialize()
        {
            _hardware = new MockHardware();
            _warmerPlate = new WarmerPlate(_hardware);
        }

        [TestMethod]
        public void WhenTheWarmerStatusChangesThenItShouldThrowAnEvent()
        {
            bool wasChanged = false;
            _warmerPlate.WarmerStatusChangedEvent += (s, e) => { wasChanged = true; };
            _hardware.WarmerPlateStatus = WarmerStatus.POT_EMPTY;
            _warmerPlate.SampleHardware();
            Assert.IsTrue(wasChanged);
        }

        [TestMethod]
        public void WhenTheWarmerStateChangesToPotNotEmptyThenItShouldStartTheWarmer()
        {
            _hardware.WarmerPlateStatus = WarmerStatus.POT_NOT_EMPTY;
            _warmerPlate.SampleHardware();
            Assert.AreEqual(WarmerState.WARMER_ON, _hardware.WarmerPlateState);
        }
    }
}
