using LibraryApi.Requests;
using LibraryApi.Services;

namespace CalculationUnitTests
{
    public class CalculationUnitTests
    {
        [Fact]
        public void ShouldApply10PercentDiscount_WhenReservationDaysIs5()
        {
            var calculationService = new CalculationService();
            int reservationDays = 5;
            double expectedAmount = 9.0;

            double actualTotal =  calculationService.ApplyDiscount(reservationDays, 10);
            Assert.Equal(expectedAmount, actualTotal);
        }
        [Fact]
        public void ShouldApply20PercentDiscount_WhenReservationDaysIs20()
        {
            var calculationService = new CalculationService();
            int reservationDays = 20;
            double expectedAmount = 32.0;
            int totalWithNoDiscount = 40;
            double actualTotal = calculationService.ApplyDiscount(reservationDays, totalWithNoDiscount);
            Assert.Equal(expectedAmount, actualTotal);
        }

        [Fact]
        public void ShouldNotApplyAnyDiscount_WhenReservationDaysIs3()
        {
            var calculationService = new CalculationService();
            int reservationDays = 3;
            double expectedAmount = 6;
            int totalWithNoDiscount = 6;
            double actualTotal = calculationService.ApplyDiscount(reservationDays, totalWithNoDiscount);
            Assert.Equal(expectedAmount, actualTotal);
        }

        [Fact]
        public void ShouldApplyServiceAndQuickPickupFees()
        {
            var calculationService = new CalculationService();
            ReservationData request = new ReservationData("Book1", "physical", 3, true);
            int totalWithNoDiscount = 6;
            int expectedAmount = 14;
            double actualTotal = calculationService.ApplyOtherFees(request, totalWithNoDiscount);
            Assert.Equal(expectedAmount, actualTotal);

        }

        [Fact]
        public void ShouldApplyServiceFeeOnly()
        {
            var calculationService = new CalculationService();
            ReservationData request = new ReservationData("Book1", "physical", 3, false);
            int totalWithNoDiscount = 6;
            int expectedAmount = 11;
            double actualTotal = calculationService.ApplyOtherFees(request, totalWithNoDiscount);
            Assert.Equal(expectedAmount, actualTotal);

        }

        [Fact]
        public void ShouldCalculatePhysicalBookAmountBeforeAnyDiscountOrFee()
        {
            var calculationService = new CalculationService();
            ReservationData request = new ReservationData("Book1", "physical", 3, true);
            double actualTotal = calculationService.CalculateAmountNoDiscount(request);
            int expectedAmount = 6;
            Assert.Equal(expectedAmount, actualTotal);

        }


        [Fact]
        public void ShouldCalculateAudioBookAmountBeforeAnyDiscountOrFee()
        {
            var calculationService = new CalculationService();
            ReservationData request = new ReservationData("Book1", "audio", 3, true);
            double actualTotal = calculationService.CalculateAmountNoDiscount(request);
            int expectedAmount = 9;
            Assert.Equal(expectedAmount, actualTotal);

        }

        [Fact]
        public void ShouldReturnZero_WhenBookIsNeitherPhysicalOrAudio()
        {
            var calculationService = new CalculationService();
            ReservationData request = new ReservationData("Book1", "something", 3, true);
            double actualTotal = calculationService.CalculateAmountNoDiscount(request);
            int expectedAmount = 0;
            Assert.Equal(expectedAmount, actualTotal);

        }


        [Fact]
        public void ShouldCalculateTotalAmount()
        {
            var calculationService = new CalculationService();
            ReservationData request = new ReservationData("Book1", "audio", 20, true);
            double actualTotal = calculationService.CalculateTotalAmount(request);
            int expectedAmount = 56;
            Assert.Equal(expectedAmount, actualTotal);

        }
    }
}


