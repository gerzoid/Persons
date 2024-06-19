using Mapster;

namespace Application.Common.Dto
{
    public class TablesDto
    {
        public int? TableId { get; set; }
        public required string Name { get; set; }
        public required string Database { get; set; }
        public required string Shema { get; set; }
        public required string TableName { get; set; }
        public string? Description { get; set; }
        public int CountRecords { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? ExpiredAt { get; set; }
        public List<SettingsTablesDto>? Settings { get; set; }
        public string[] Columns { get; set; }
        [AdaptIgnore]
        public string FullTableName { get { return Database + '.' + Shema + '.' + TableName; } }

    }
}
