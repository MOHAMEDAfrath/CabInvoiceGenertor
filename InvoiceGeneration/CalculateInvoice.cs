using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceGeneration
{
    public class CalculateInvoice
    {
        double costPerKm;
        int costPerMin;
        double minimumFare;
        //enum for type of rides
        public enum RideType
        {
            Premium, Normal
        }

        //Parameterized Constructor
        public CalculateInvoice(RideType rideType)
        {
            //Normal Ride Values
            if (rideType.Equals(RideType.Normal))
            {
                costPerKm = 10;
                costPerMin = 1;
                minimumFare = 5;
            }else if (rideType.Equals(RideType.Premium))
            {
                costPerKm = 15;
                costPerMin = 2;
                minimumFare = 20;
            }
            
        }
        //calculates the fare
        public double CalculateFare(int time, double distance)

        {
            double totalFare = 0;


            if (distance <= 0)
            {
                throw new InvoiceCustomException(InvoiceCustomException.ExceptionType.INVALID_DISTANCE, "Distance should be greater than zero");
            }
            if (time <= 0)
            {
                throw new InvoiceCustomException(InvoiceCustomException.ExceptionType.INVALID_TIME, "Time should be greater than zero");
            }


            totalFare = distance * costPerKm + time * costPerMin;
            return Math.Max(minimumFare, totalFare);

        }

    }
}
