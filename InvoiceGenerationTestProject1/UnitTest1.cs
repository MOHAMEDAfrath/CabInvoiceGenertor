using InvoiceGeneration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InvoiceGenerationTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //UC1.1:Calculates the fare for normal ride
        [TestMethod]
        [TestCategory("Calculate Fare For Normal Ride")]
        public void CalculateTotalFareForNormalRide()
        {
            CalculateInvoice cabInvoiceCalculate = new CalculateInvoice(CalculateInvoice.RideType.Normal);
            double distance = 4.8;
            int time = 20;
            double fare = cabInvoiceCalculate.CalculateFare(time,distance);
            double expected = 68.0;
            Assert.AreEqual(expected, fare);

        }
        //Test case for distance less than or equal to zero
        [TestMethod]
        [TestCategory("Calculate for invalid distance")]
        public void InvalidDistanceCalculateTotalFareForNormalRide()
        {
            try
            {
                CalculateInvoice cabInvoiceCalculate = new CalculateInvoice(CalculateInvoice.RideType.Normal);
                double distance = 0;
                int time = 12;
                cabInvoiceCalculate.CalculateFare(time,distance);

            }
            catch (InvoiceCustomException ex)
            {
                string expected = "Distance should be greater than zero";
                Assert.AreEqual(expected, ex.Message);
            }
        }
        //Test case for time less than or equal to zero
        [TestMethod]
        [TestCategory("Calculate for invalid Time")]
        public void InvalidTimeCalculateTotalFareForNormalRide()
        {
            try
            {
                CalculateInvoice cabInvoiceCalculate = new CalculateInvoice(CalculateInvoice.RideType.Normal);
                double distance = 12;
                int time = 0;
                cabInvoiceCalculate.CalculateFare(time, distance);

            }
            catch (InvoiceCustomException ex)
            {
                string expected = "Time should be greater than zero";
                Assert.AreEqual(expected, ex.Message);
            }
        }
        //UC5.0:Calculates the fare for Premium ride
        [TestMethod]
        [TestCategory("Calculate Fare For Premium Ride")]
        public void CalculateTotalFareForPremiumRide()
        {
            CalculateInvoice cabInvoiceCalculate = new CalculateInvoice(CalculateInvoice.RideType.Premium);
            double distance = 4.8;
            int time = 20;
            double fare = cabInvoiceCalculate.CalculateFare(time, distance);
            double expected = 112.0;
            Assert.AreEqual(expected, fare);

        }
        //Test case for distance less than or equal to zero
        [TestMethod]
        [TestCategory("Calculate for invalid distance Premium Ride")]
        public void InvalidDistanceCalculateTotalFareForPremiumRide()
        {
            try
            {
                CalculateInvoice cabInvoiceCalculate = new CalculateInvoice(CalculateInvoice.RideType.Premium);
                double distance = 0;
                int time = 12;
                cabInvoiceCalculate.CalculateFare(time, distance);

            }
            catch (InvoiceCustomException ex)
            {
                string expected = "Distance should be greater than zero";
                Assert.AreEqual(expected, ex.Message);
            }
        }
        //Test case for time less than or equal to zero
        [TestMethod]
        [TestCategory("Calculate for invalid Time Premium Ride")]
        public void InvalidTimeCalculateTotalFareForPremiumRide()
        {
            try
            {
                CalculateInvoice cabInvoiceCalculate = new CalculateInvoice(CalculateInvoice.RideType.Premium);
                double distance = 12;
                int time = 0;
                cabInvoiceCalculate.CalculateFare(time, distance);

            }
            catch (InvoiceCustomException ex)
            {
                string expected = "Time should be greater than zero";
                Assert.AreEqual(expected, ex.Message);
            }
        }

    }
}

