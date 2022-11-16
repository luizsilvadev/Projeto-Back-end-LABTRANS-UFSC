using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IMapper _IMapper;
        private readonly IBooking _IBooking;
        private readonly IServiceBooking _IServiceBooking;
        public BookingController(IMapper IMapper, IBooking IBooking, IServiceBooking IServiceBooking)
        {
            _IMapper = IMapper;
            _IBooking = IBooking;
            _IServiceBooking = IServiceBooking;
        }

        //[Authorize]
        [Produces("application/json")]
        [HttpPost("/api/AddBooking")]
        public async Task<List<Notifies>> Add(BookingViewModel Booking)
        {
            var BookingMap = _IMapper.Map<Booking>(Booking);
            await _IServiceBooking.Adicionar(BookingMap);
            return BookingMap.Notificacoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/UpdateBooking")]
        public async Task<List<Notifies>> Update(BookingViewModel Booking)
        {
            var BookingMap = _IMapper.Map<Booking>(Booking);
            await _IServiceBooking.Atualizar(BookingMap);
            return BookingMap.Notificacoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/DeleteBooking")]
        public async Task<List<Notifies>> Delete(BookingViewModel Booking)
        {
            var BookingMap = _IMapper.Map<Booking>(Booking);
            await _IBooking.Delete(BookingMap);
            return BookingMap.Notificacoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/GetBookingById")]
        public async Task<BookingViewModel> GetEntityById(Booking Booking)
        {
            Booking = await _IBooking.GetEntityById(Booking.Id);
            var BookingMap = _IMapper.Map<BookingViewModel>(Booking);
            return BookingMap;
        }

        //[Authorize]   
        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/ListBooking")]
        public async Task<List<BookingViewModel>> List()
        {
            var mensagens = await _IBooking.List();
            var BookingMap = _IMapper.Map<List<BookingViewModel>>(mensagens);
            return BookingMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/ListBookingActives")]
        public async Task<List<BookingViewModel>> ListarBookingAtivas()
        {
            var mensagens = await _IServiceBooking.ListarBookingCafe();
            var BookingMap = _IMapper.Map<List<BookingViewModel>>(mensagens);
            return BookingMap;
        }

    }
}
