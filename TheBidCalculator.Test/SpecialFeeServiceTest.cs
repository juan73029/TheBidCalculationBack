using System;
using TheBidCalculation.Core.Services;
using TheBidCalculation.Entities.DTOs;
using TheBidCalculation.Entities.Enums;

namespace TheBidCalculator.Test
{
    public class SpecialFeeServiceTest
    {
        [Theory]
        [InlineData(398, VehicleTypeEnum.Common, 7.96)]
        [InlineData(501, VehicleTypeEnum.Common, 10.02)]
        [InlineData(57, VehicleTypeEnum.Common, 1.14)]
        [InlineData(1800, VehicleTypeEnum.Luxury, 72)]
        [InlineData(1100, VehicleTypeEnum.Common, 22)]
        [InlineData(1000000, VehicleTypeEnum.Luxury, 40000)]
        public void GetFee_ReturnCorrectValue(double value, VehicleTypeEnum type, double feeValueExpected)
        {
            VehicleValueDTO vehicleValue = new VehicleValueDTO() { Value = value, VehicleType = type };
            SpecialFeeService service = new SpecialFeeService() { Name = "Special" };

            FeeDTO fee = service.GetFee(vehicleValue);

            double feeValue = double.Round(fee.Value, 2);
            Assert.Equal(feeValue, feeValueExpected);
            Assert.Equal("Special", fee.Name);



        }

    }
}

