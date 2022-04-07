using ChallengeWirolsut.Dtos;
using ChallengeWirolsut.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeWirolsut.Core.Interfaces
{
    public interface IVehicleService
    {
        Task AddVehicle(VehicleDto vehicleDto, int id);
        Task UpdateVehicle();
        Task DeleteVehicle();
        List<Vehicle> ListedVehicles();
    }
}
