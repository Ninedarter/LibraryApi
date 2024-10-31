using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace TestLibraryUnitTests
{
    [TestClass]
    public class CalculationTests
    {
        [TestMethod]
        public void ShouldApplyDiscount_WhenReservationDayIs4()
        {
            //Arange
            var calulation = new CalculationService();
            int reservationDays = 4;
            //Act
            //Assert
        }
    }
}
