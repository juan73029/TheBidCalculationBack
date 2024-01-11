using System;
using TheBidCalculation.Core.Services;
using TheBidCalculation.Entities.DTOs;
using TheBidCalculation.Entities.Enums;

namespace TheBidCalculator.Test
{
    public class StorageFeeServiceTest
    {
        [Theory]
        [InlineData(398, VehicleTypeEnum.Common, 100)]
        [InlineData(501, VehicleTypeEnum.Common, 100)]
        [InlineData(57, VehicleTypeEnum.Common, 100)]
        [InlineData(1800, VehicleTypeEnum.Luxury, 100)]
        [InlineData(1100, VehicleTypeEnum.Common, 100)]
        [InlineData(1000000, VehicleTypeEnum.Luxury, 100)]
        public void GetFee_ReturnCorrectValue(double value, VehicleTypeEnum type, double feeValueExpected)
        {
            VehicleValueDTO vehicleValue = new VehicleValueDTO() { Value = value, VehicleType = type };
            StorageFeeService service = new StorageFeeService() { Name = "Storage" };

            FeeDTO fee = service.GetFee(vehicleValue);

            double feeValue = double.Round(fee.Value, 2);
            Assert.Equal(feeValue, feeValueExpected);
            Assert.Equal("Storage", fee.Name);



        }
    }
}

