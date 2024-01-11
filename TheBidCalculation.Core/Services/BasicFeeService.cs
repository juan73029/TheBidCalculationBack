using System;
using TheBidCalculation.Core.Services.Interfaces;
using TheBidCalculation.Entities.DTOs;
using TheBidCalculation.Entities.Enums;

namespace TheBidCalculation.Core.Services
{
    public class BasicFeeService : FeeService, IBasicFee
    {
        public BasicFeeService()
        {
            base.Name = "Basic";
        }

        public override FeeDTO GetFee(VehicleValueDTO item)
        {
            try
            {
                FeeDTO fee = new FeeDTO { Name = base.Name, Value = 0 };
                double feeValue = item.Value * 0.1;
                switch (item.VehicleType)
                {
                    case VehicleTypeEnum.Common:
                        fee.Value = GetCommonFee(feeValue);
                        return fee;
                    case VehicleTypeEnum.Luxury:
                        fee.Value = GetLuxuryFee(feeValue);
                        return fee;
                    default:
                        return fee;

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private double GetCommonFee(double feeValue)
        {
            if (feeValue < 10)
            {
                return 10;

            }
            if (feeValue > 50)
            {
                return 50;

            }
            return feeValue;
        }

        private double GetLuxuryFee(double feeValue)
        {
            if (feeValue < 25)
            {
                return 25;

            }
            if (feeValue > 200)
            {
                return 200;

            }
            return feeValue;
        }
    }
}


