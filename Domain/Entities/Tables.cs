using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Tables
    {
        [Key]
        public int TableId {  get; set; }
        public string Name { get; set; }        
        public string Database { get; set; }
        public string Shema { get; set; }
        public string TableName { get; set; }
        public string? Description {  get; set; }
        public int CountRecords {  get; set; }
        public int UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set;}
        public DateTime? ExpiredAt { get; set; }        
        public List<SettingsTables> Settings { get; set; }
    }
}
