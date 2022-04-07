using ChallengeWirolsut.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeWirolsut.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<City> CityRepository { get; }
        IGenericRepository<Ticket> TicketRepository { get; }
        IGenericRepository<Vehicle> VehicleRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
