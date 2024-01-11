using System;
using TheBidCalculation.Core.Services.Interfaces;
using TheBidCalculation.Entities.DTOs;

namespace TheBidCalculation.Core.Services
{
    public class AssociationFeeService : FeeService, IAssociationFee
    {
        public AssociationFeeService()
        {
            base.Name = "Association";
        }

        public override FeeDTO GetFee(VehicleValueDTO item)
        {
            try
            {
                FeeDTO fee = new FeeDTO { Name = base.Name, Value = 0 };
                switch (item.Value)
                {
                    case double value when (value >= 1 && value <= 500):
                        fee.Value = 5;
                        break;
                    case double value when (value > 500 && value <= 1000):
                        fee.Value = 10;
                        break;
                    case double value when (value > 1000 && value <= 3000):
                        fee.Value = 15;
                        break;
                    case double value when (value > 3000):
                        fee.Value = 20;
                        break;
                    default:
                        break;
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

