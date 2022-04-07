using ChallengeWirolsut.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeWirolsut.Core.Interfaces
{
    public interface ITicketService
    {
        Task AssignTrip();
        Task GetAllTrips();
        Task RescheduleTrip();
        Task CancelTrip();
    }
}
