namespace LibraryApi.Responses
{
    public class ReservationResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public double TotalAmount { get; set; }
        public ReservationResponse(bool isSuccess, string message, double totalAmount)
        {
            IsSuccess = isSuccess;
            Message = message;
            TotalAmount = totalAmount;
        }
    }
}
   
   

