using Application.Common.Dto;
using Domain.Entities;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Mapper
{
    public static class MapsterConfig
    {
       public static void RegisterMapsterConfiguration(this IServiceCollection services)
        {
            TypeAdapterConfig<Tables, TablesDto>.NewConfig().RequireDestinationMemberSource(true);
        }
    }
}
