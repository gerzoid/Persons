using Mapster;
using System.Text.Json.Serialization;

namespace Application.Common.Dto
{
    public class SettingsTablesDto: SettingsTablesBaseDto
    {
        public int? SettingsTableId { get; set; }
    }
}
