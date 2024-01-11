using System;
using TheBidCalculation.Core.Services.Interfaces;
using TheBidCalculation.Entities.DTOs;
using TheBidCalculation.Entities.Enums;

namespace TheBidCalculation.Core.Services
{
    public class SpecialFeeService : FeeService, ISpecialFee
    {
        public SpecialFeeService()
        {
            base.Name = "Special";
        }

        public override FeeDTO GetFee(VehicleValueDTO item)
        {
            try
            {
                FeeDTO fee = new FeeDTO { Name = base.Name, Value = 0 };
                if (item.VehicleType == VehicleTypeEnum.Common)
                {
                    fee.Value = item.Value * 0.02;
                    return fee;
                }

                if (item.VehicleType == VehicleTypeEnum.Luxury)
                {
                    fee.Value = item.Value * 0.04;
                    return fee;

                }
                return fee;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

