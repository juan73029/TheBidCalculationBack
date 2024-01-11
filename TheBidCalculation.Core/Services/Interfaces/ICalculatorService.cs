using System;
using TheBidCalculation.Entities.DTOs;

namespace TheBidCalculation.Core.Services.Interfaces
{
    public interface ICalculatorService
    {
        BidDTO GetBid(VehicleValueDTO item);

    }
}

