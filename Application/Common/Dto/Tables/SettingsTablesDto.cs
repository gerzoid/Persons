using Mapster;
using System.Text.Json.Serialization;

namespace Application.Common.Dto
{
    public class SettingsTablesDto
    {
        [AdaptIgnore]
        public int SettingsTableId { get; set; }
        //Название настройки        
        [JsonPropertyName("name")]
        public required string Name { get; set; }
        [JsonPropertyName("field")]
        public required string Field { get; set; }
        [JsonPropertyName("nameField")]
        public required string NameField { get; set; }
    }
}
