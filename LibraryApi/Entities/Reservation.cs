    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    namespace LibraryApi.Entities
    {
        public class Reservation
        {
            [Key] 
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
            public int ReservationId { get; set; }

            public string Title { get; set; }

            public int DaysToReserve {  get; set; } 
            
            public double TotalAmount { get; set; }

            public DateTime ReservationDate { get; set; }


            public Reservation(string title, int daysToReserve, double totalAmount)
            {
                Title = title;         
                DaysToReserve = daysToReserve;
                TotalAmount = totalAmount;
                ReservationDate = DateTime.UtcNow;
            }

        }
  
    }
