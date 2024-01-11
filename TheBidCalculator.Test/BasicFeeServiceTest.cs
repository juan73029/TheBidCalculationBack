using System;
using TheBidCalculation.Core.Services;
using TheBidCalculation.Entities.DTOs;
using TheBidCalculation.Entities.Enums;

namespace TheBidCalculator.Test
{
    public class BasicFeeServiceTest
    {
        [Theory]
        [InlineData(398, VehicleTypeEnum.Common, 39.80)]
        [InlineData(501, VehicleTypeEnum.Common, 50)]
        [InlineData(57, VehicleTypeEnum.Common, 10)]
        [InlineData(1800, VehicleTypeEnum.Luxury, 180)]
        [InlineData(1100, VehicleTypeEnum.Common, 50)]
        [InlineData(1000000, VehicleTypeEnum.Luxury, 200)]
        public void GetFee_ReturnCorrectValue(double value, VehicleTypeEnum type, double feeValueExpected)
        {
            VehicleValueDTO vehicleValue = new VehicleValueDTO() { Value = value, VehicleType = type };
            BasicFeeService service = new BasicFeeService() { Name = "Basic" };

            FeeDTO fee = service.GetFee(vehicleValue);

            double feeValue = double.Round(fee.Value, 2);
            Assert.Equal(feeValue, feeValueExpected);
            Assert.Equal("Basic", fee.Name);



        }
    }
}

