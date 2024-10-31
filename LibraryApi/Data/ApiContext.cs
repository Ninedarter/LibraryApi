using LibraryApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options)
             : base(options)
        {

        }


        public async Task<Book> ReturnIfExistsAsync(string title)
        {
            return await Books.FirstOrDefaultAsync(b => b.Title == title);
        }


        public async Task AddReservationAsync(Reservation reservation)
        {
            await Reservations.AddAsync(reservation);
            await SaveChangesAsync();
        }

        public async Task<bool> IsBookAlreadyReservedAsync(string title)
        {
            Reservation existingReservation = await Reservations.FirstOrDefaultAsync(b => b.Title == title);
            return existingReservation != null;
        }
    }
}