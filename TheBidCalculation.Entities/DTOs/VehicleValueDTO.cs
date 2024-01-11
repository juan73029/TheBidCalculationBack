using System;
using System.Text.Json.Serialization;
using TheBidCalculation.Entities.Enums;

namespace TheBidCalculation.Entities.DTOs
{
    public class VehicleValueDTO
    {
        public double Value { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public VehicleTypeEnum VehicleType { get; set; }
    }
}

