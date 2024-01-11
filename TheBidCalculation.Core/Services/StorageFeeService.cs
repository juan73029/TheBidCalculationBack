using System;
using TheBidCalculation.Core.Services.Interfaces;
using TheBidCalculation.Entities.DTOs;

namespace TheBidCalculation.Core.Services
{
    public class StorageFeeService : FeeService, IStorageFee
    {
        public StorageFeeService()
        {
            base.Name = "Storage";
        }



        public override FeeDTO GetFee(VehicleValueDTO item)
        {
            FeeDTO fee = new FeeDTO { Name = base.Name, Value = 100 };
            return fee;
        }
    }
}

