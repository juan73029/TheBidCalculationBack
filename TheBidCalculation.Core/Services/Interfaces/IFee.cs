using System;
using TheBidCalculation.Entities.DTOs;

namespace TheBidCalculation.Core.Services.Interfaces
{
    public interface IFee
    {
        FeeDTO GetFee(VehicleValueDTO item);
    }
}

