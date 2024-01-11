using System;
namespace TheBidCalculation.Entities.DTOs
{
    public class BidDTO
    {
        public double VehicleValue { get; set; }
        public List<FeeDTO> Fees { get; set; }
        public double TotalPrice { get; set; }
    }
}

