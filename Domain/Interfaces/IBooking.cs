using Domain.Interfaces.Generics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IBooking : IGeneric<Booking>
    {
        Task<List<Booking>> ListarBooking(Expression<Func<Booking, bool>> exBooking);
    }
}
