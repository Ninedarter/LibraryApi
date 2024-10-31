using LibraryApi.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace LibraryApi.Services
{
    public class CalculationService {    
                public CalculationService()
        {
          
        }


        public double CalculateTotalAmount(ReservationData request)
        {

           int amountWithoutDiscount =  CalculateAmountNoDiscount(request);

            double totalAmount = amountWithoutDiscount;
            if (isDiscountApplicable(request.ReservationDays))
            {
                totalAmount = ApplyDiscount(request.ReservationDays, amountWithoutDiscount);
            }

            totalAmount = ApplyOtherFees(request, totalAmount);
    

            return totalAmount;
          
        }
    


        public int CalculateAmountNoDiscount(ReservationData request)
        {
            System.Diagnostics.Debug.WriteLine("yes");
            int totalAmount = 0;
           
                switch (request.Type)
                {
                    case "physical":
                 
                    totalAmount = request.ReservationDays* (int)BookPrice.PhysicalBook;
                    break;
                    case "audio":
                        totalAmount = request.ReservationDays * (int)BookPrice.AudioBook;
                    break;
                    default:
                    totalAmount = 0;
                    break;

            }

            return totalAmount;
        }


        public double ApplyDiscount(int reservationDays, int amountWithoudDiscount)
        {
           
            double totalAfterDiscount = 0;
                
            if (reservationDays > 3 && reservationDays <= 10)
            {
                totalAfterDiscount =  amountWithoudDiscount*0.9;
            }
            else if(reservationDays > 10)
            {
                totalAfterDiscount = amountWithoudDiscount * 0.8;
            }
            else
            {
                totalAfterDiscount = amountWithoudDiscount;
            }

            return totalAfterDiscount;
        }

        public double ApplyOtherFees(ReservationData request, double totalAmount)
        {
     
            double totalAfterFees = 0;
            totalAfterFees = (request.IsQuickPickup) ? totalAmount + (int)BookPrice.QuickPickupFee + (int)BookPrice.ServiceFee : totalAmount + (int)(BookPrice.QuickPickupFee);
            return totalAfterFees;
        }


        private bool isDiscountApplicable(int numberOfDays)
        {

            return numberOfDays > 3;
        }
    }
}