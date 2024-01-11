

using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using TheBidCalculation.Core.Services;
using TheBidCalculation.Core.Services.Interfaces;

namespace TheBidCalculation.Core
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {

            services.AddScoped<IAssociationFee, AssociationFeeService>();
            services.AddScoped<IBasicFee, BasicFeeService>();
            services.AddScoped<ISpecialFee, SpecialFeeService>();
            services.AddScoped<IStorageFee, StorageFeeService>();
            services.AddScoped<ICalculatorService, CalculatorService>();
            return services;
        }
    }
}

