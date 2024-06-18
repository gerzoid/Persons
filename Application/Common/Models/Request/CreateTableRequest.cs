using Application.Common.Dto;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Application.Common.Models
{
    [JsonObject("table")]
    public class CreateTableRequest
    {
        [JsonPropertyName("name")]
        public required string Name { get; set; }
        [JsonPropertyName("database")]
        public required string Database { get; set; }
        [JsonPropertyName("shema")]
        public required string Shema { get; set; } = "dbo";
        [JsonPropertyName("tableName")]
        public required string TableName { get; set; }
        [JsonPropertyName("description")]
        public string? Description { get; set; }
        [JsonPropertyName("countRecords")]
        public int CountRecords { get; set; } = 0;
        [JsonPropertyName("expiredAt")]
        public DateTime? ExpiredAt { get; set; }
        [JsonPropertyName("settings")]
        public List<SettingsTablesDto>? Settings { get; set; }
    }
}
