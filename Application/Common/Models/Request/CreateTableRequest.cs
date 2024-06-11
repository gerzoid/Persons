using Application.Common.Dto;

namespace Application.Common.Models
{
    public class CreateTableRequest
    {
        public string Name { get; set; }
        public string Database { get; set; }
        public string Shema { get; set; } = "dbo";
        public string TableName { get; set; }
        public string? Description { get; set; }
        public int CountRecords { get; set; } = 0;
        public DateTime? ExpiredAt { get; set; }
        public List<SettingsTablesDto>? Settings { get; set; }
    }
}
