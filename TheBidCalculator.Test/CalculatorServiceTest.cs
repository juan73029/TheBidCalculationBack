using System;
using TheBidCalculation.Core.Services;
using TheBidCalculation.Core.Services.Interfaces;
using TheBidCalculation.Entities.DTOs;
using TheBidCalculation.Entities.Enums;

namespace TheBidCalculator.Test
{
    public class CalculatorServiceTest
    {
        private IBasicFee _basicFeeService;
        private IAssociationFee _associationFeeService;
        private ISpecialFee _specialFeeService;
        private IStorageFee _storageFeeService;
        public CalculatorServiceTest()
        {

            _basicFeeService = new BasicFeeService() { Name = "Basic" };
            _associationFeeService = new AssociationFeeService() { Name = "Association" };
            _specialFeeService = new SpecialFeeService() { Name = "Special" };
            _storageFeeService = new StorageFeeService() { Name = "Storage" };
        }
        [Theory]
        [InlineData(398, VehicleTypeEnum.Common, 550.76)]
        [InlineData(501, VehicleTypeEnum.Common, 671.02)]
        [InlineData(57, VehicleTypeEnum.Common, 173.14)]
        [InlineData(1800, VehicleTypeEnum.Luxury, 2167)]
        [InlineData(1100, VehicleTypeEnum.Common, 1287)]
        [InlineData(1000000, VehicleTypeEnum.Luxury, 1040320)]
        public void GetFee_ReturnCorrectValue(double value, VehicleTypeEnum type, double totalPriceExpected)
        {

            VehicleValueDTO vehicleValue = new VehicleValueDTO() { Value = value, VehicleType = type };
            CalculatorService service = new(_basicFeeService, _associationFeeService, _specialFeeService, _storageFeeService);

            BidDTO bid = service.GetBid(vehicleValue);

            Assert.Equal(bid.TotalPrice, totalPriceExpected);




        }
    }
}

