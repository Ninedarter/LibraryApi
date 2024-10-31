using LibraryApi.Data;
using LibraryApi.Entities;
using LibraryApi.Requests;
using LibraryApi.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Services
{
    public class ReservationService
    {

        private readonly CalculationService _calculationService;
        private readonly ApiContext _aApiContext;
        private readonly ValidationService _validationService;

        public ReservationService(CalculationService calculation, ValidationService validationService, ApiContext apiContext)
        {
            _calculationService = calculation;
            _validationService = validationService;
            _aApiContext = apiContext;
        }

        public async Task<ReservationResponse> MakeReservation(ReservationData request)
        {
         Book book = await _aApiContext.ReturnIfExistsAsync(request.Title);


            if(book == null)
            {
                return new ReservationResponse(false, "Book not found in database", 0.0);
            }
            if (await IsBookAlreadyReserved(request.Title)){
             return   new ReservationResponse(false, "Book is already reserved", 0.0);
            }
            double totalAmount = _calculationService.CalculateTotalAmount(request);
            Reservation reservation = new Reservation(request.Title, request.ReservationDays, totalAmount);
            await _aApiContext.AddReservationAsync(reservation);

            return new ReservationResponse(true, "Successfully reserved", totalAmount);
        }

        public async Task<List<Reservation>> GetAll()
        {
            var reservations = await _aApiContext.Reservations.ToListAsync();
            return reservations;
        }

        private async Task<bool> IsBookAlreadyReserved(string title)
        {
            return await _aApiContext.IsBookAlreadyReservedAsync(title);
           
        }
    }
}
