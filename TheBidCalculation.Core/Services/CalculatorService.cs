using System;
using TheBidCalculation.Core.Services.Interfaces;
using TheBidCalculation.Entities.DTOs;

namespace TheBidCalculation.Core.Services
{
    public class CalculatorService : ICalculatorService
    {
        private readonly IBasicFee _basicFee;
        private readonly IAssociationFee _associationFee;
        private readonly ISpecialFee _specialFee;
        private readonly IStorageFee _storageFee;

        public CalculatorService(
            IBasicFee basicFee,
            IAssociationFee associationFee,
            ISpecialFee specialFee,
            IStorageFee storageFee
            )
        {
            _associationFee = associationFee;
            _basicFee = basicFee;
            _specialFee = specialFee;
            _storageFee = storageFee;

        }

        public BidDTO GetBid(VehicleValueDTO item)
        {
            try
            {
                BidDTO bid = new BidDTO();
                List<FeeDTO> fees = new List<FeeDTO>();
                FeeDTO basicFee = _basicFee.GetFee(item);
                FeeDTO associationFee = _associationFee.GetFee(item);
                FeeDTO specialFee = _specialFee.GetFee(item);
                FeeDTO storageFee = _storageFee.GetFee(item);
                fees.Add(basicFee);
                fees.Add(associationFee);
                fees.Add(specialFee);
                fees.Add(storageFee);
                bid.Fees = fees;
                bid.VehicleValue = item.Value;
                bid.TotalPrice = GetTotalPrice(bid);
                return bid;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private double GetTotalPrice(BidDTO bid)
        {
            try
            {
                double total = bid.VehicleValue;
                foreach (FeeDTO fee in bid.Fees)
                {
                    total += fee.Value;
                }
                return total;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

