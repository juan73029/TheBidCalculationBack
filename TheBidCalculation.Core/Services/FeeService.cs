using System;
using TheBidCalculation.Core.Services.Interfaces;
using TheBidCalculation.Entities.DTOs;

namespace TheBidCalculation.Core.Services
{
    public abstract class FeeService : IFee
    {
        public required string Name;
        public abstract FeeDTO GetFee(VehicleValueDTO item);

    }
}

