using ChallengeWirolsut.Core.Interfaces;
using ChallengeWirolsut.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeWirolsut.Core.Services
{
    public class TicketService : ITicketService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TicketService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public Task AssignTrip()
        {
            throw new NotImplementedException();
        }

        public Task CancelTrip()
        {
            throw new NotImplementedException();
        }

        public Task GetAllTrips()
        {
            throw new NotImplementedException();
        }

        public Task RescheduleTrip()
        {
            throw new NotImplementedException();
        }
    }
}
