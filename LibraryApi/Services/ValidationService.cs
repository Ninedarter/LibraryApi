using LibraryApi.Requests;
using System.Drawing.Text;

namespace LibraryApi.Services
{
    public class ValidationService
    {

        public bool IsRequestValid(ReservationData request)
        {
            if (request == null)
            {
                return false;
            }
            if (!IsReservationDaysValid(request.ReservationDays) || !isTypeOfBookValid(request.Type) && request.Title != null)
            {
                return false;
            }

            return true;
        }


        //No logic provided in task, so maximum reservation days not provided
        private bool IsReservationDaysValid(int reservationDays)
        {
            return reservationDays > 0;
        }

        private bool isTypeOfBookValid(String bookType)
        {
            return (bookType.Equals("physical") || bookType.Equals("audio"));
        }
    } }
