using ChallengeWirolsut.DataAccess;
using ChallengeWirolsut.Entities;
using ChallengeWirolsut.Repositories.Interfaces;
using System.Threading.Tasks;

namespace ChallengeWirolsut.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ChallengeContext _context;
        private readonly IGenericRepository<City> _cityRepository;
        private readonly IGenericRepository<Ticket> _ticketRepository;
        private readonly IGenericRepository<Vehicle> _vehicleRepository;

        public UnitOfWork(ChallengeContext context)
        {
            _context = context;
        }

        public IGenericRepository<City> CityRepository => _cityRepository ?? new GenericRepository<City>(_context);

        public IGenericRepository<Ticket> TicketRepository => _ticketRepository ?? new GenericRepository<Ticket>(_context);

        public IGenericRepository<Vehicle> VehicleRepository => _vehicleRepository ?? new GenericRepository<Vehicle>(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
