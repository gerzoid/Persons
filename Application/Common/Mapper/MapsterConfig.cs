using Microsoft.Extensions.DependencyInjection;

namespace Application.Common.Mapper
{
    public static class MapsterConfig
    {
        public static void RegisterMapsterConfiguration(this IServiceCollection services)
        {
            //TypeAdapterConfig<Tables, TablesDto>.NewConfig().RequireDestinationMemberSource(true);
            //TypeAdapterConfig<SettingsTables, SettingsTablesDto>.NewConfig().RequireDestinationMemberSource(true);
        }
    }
}
