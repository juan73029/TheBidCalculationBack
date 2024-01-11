using TheBidCalculation.Core.Services;
using TheBidCalculation.Entities.DTOs;
using TheBidCalculation.Entities.Enums;

namespace TheBidCalculator.Test;

public class AssociationFeeServiceTest
{
    [Theory]
    [InlineData(398, VehicleTypeEnum.Common, 5)]
    [InlineData(501, VehicleTypeEnum.Common, 10)]
    [InlineData(57, VehicleTypeEnum.Common, 5)]
    [InlineData(1800, VehicleTypeEnum.Luxury, 15)]
    [InlineData(1100, VehicleTypeEnum.Common, 15)]
    [InlineData(1000000, VehicleTypeEnum.Luxury, 20)]
    public void GetFee_ReturnCorrectValue(double value, VehicleTypeEnum type, double feeValueExpected)
    {
        VehicleValueDTO vehicleValue = new VehicleValueDTO() { Value = value, VehicleType = type };
        AssociationFeeService service = new AssociationFeeService() { Name = "Association" };

        FeeDTO fee = service.GetFee(vehicleValue);

        Assert.Equal(fee.Value, feeValueExpected);
        Assert.Equal("Association", fee.Name);



    }
}
