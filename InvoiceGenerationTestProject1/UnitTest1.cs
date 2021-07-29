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
        //UC2:Calculate aggregate fare for normal ride
        [TestMethod]
        [TestCategory("Calculate Aggregate Fare for normal ride")]
        public void CalculateAggregateFare()
        {
            CalculateInvoice calculate = new CalculateInvoice(CalculateInvoice.RideType.Normal);
            Ride[] ride = { new Ride(3, 5.0), new Ride(6, 7.0) };
            double actual = calculate.CalculateAggregateFare(ride);
            double expected = 129.0;
            Assert.AreEqual(expected, actual);

        }
        //TC2.1:Calculate aggregate fare for premium ride
        [TestMethod]
        [TestCategory("Calculate Aggregate Fare for Premium ride")]
        public void CalculateAggregateFareForPremiumRide()
        {
            CalculateInvoice calculate = new CalculateInvoice(CalculateInvoice.RideType.Premium);
            Ride[] ride = { new Ride(3, 5.0), new Ride(6, 7.0) };
            double actual = calculate.CalculateAggregateFare(ride);
            double expected = 198.0;
            Assert.AreEqual(expected, actual);
        }
        //TC2.2:Invalid Ride List Count
        [TestMethod]
        [TestCategory("Invalid Ride List")]
        public void InvalidRideList()
        {
            try
            {
                CalculateInvoice calculate = new CalculateInvoice(CalculateInvoice.RideType.Premium);
                Ride[] ride = { };
                calculate.CalculateAggregateFare(ride);
            }catch(InvoiceCustomException ex)
            {
                string expected = "Invalid Ride List";
                Assert.AreEqual(ex.Message, expected);
            }
        }
        //UC3:Test method for normal rides
        [TestMethod]
        [TestCategory("Invoice Summary for normal rides")]
        public void TestMethodToCheckInvoiceSummay()
        {
            CalculateInvoice calculate = new CalculateInvoice(CalculateInvoice.RideType.Normal);
            Ride[] ride = { new Ride(3, 5.0), new Ride(6, 7.0) };
            string actual = calculate.InvoiceSummary(ride);
            string expected = "\nNo of rides: 2 \nTotal Fare: 129 \nAverage Fare: 64.5";
            Assert.AreEqual(actual, expected);
        }
        //UC3.3:Test method for premium rides
        [TestMethod]
        [TestCategory("Invoice Summary for premium rides")]
        public void TestMethodToCheckInvoiceSummayForPremiumRides()
        {
            CalculateInvoice calculate = new CalculateInvoice(CalculateInvoice.RideType.Premium);
            Ride[] ride = { new Ride(3, 5.0), new Ride(6, 7.0) };
            string actual = calculate.InvoiceSummary(ride);
            string expected = "\nNo of rides: 2 \nTotal Fare: 198 \nAverage Fare: 99";
            Assert.AreEqual(actual, expected);
        }
        //UC:4test method to search for particular userID repos
        [TestMethod]
        [TestCategory("Invoice for user Id")]
        public void SearchInvoiceForUserId()
        {
            RideRepository ride = new RideRepository();
            Ride[] rides123 = { new Ride(3, 5.0), new Ride(6, 7.0) };
            Ride[] rides124 = { new Ride(4, 6.0), new Ride(7, 8.0) };
            ride.AddToDictionary("123",rides123);
            ride.AddToDictionary("124",rides124);
            string actual = ride.Search("123");
            string expected = "\nNormal\nNo of rides: 2 \nTotal Fare: 129 \nAverage Fare: 64.5\nPremium\nNo of rides: 2 \nTotal Fare: 198 \nAverage Fare: 99";
            Assert.AreEqual(actual, expected);

        }
        //Test case for invalid user Id
        [TestMethod]
        [TestCategory("Invalid userID search")]
        public void SearchForInvalidUserID()
        {
            RideRepository ride = new RideRepository();
            Ride[] rides123 = { new Ride(3, 5.0), new Ride(6, 7.0) };
            Ride[] rides124 = { new Ride(4, 6.0), new Ride(7, 8.0) };
            ride.AddToDictionary("123", rides123);
            ride.AddToDictionary("124", rides124);
            string actual = ride.Search("125");
            string expected = "Not found";
            Assert.AreEqual(actual, expected);

        }



    }
}

