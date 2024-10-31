namespace LibraryApi.Requests
{
    public class ReservationData
    {


        public string Title { get; set; }

        public string Type { get; set; }

        public int ReservationDays { get; set; }

        public bool IsQuickPickup { get; set; }

        public double? TotalAmount { get; set; }

        public ReservationData(string title, string type, int reservationDays, bool isQuickPickup)
        {
            Title = title;
            Type = type;
            ReservationDays = reservationDays;
            IsQuickPickup = isQuickPickup;
            TotalAmount = 0.0;
        }

    }
}
