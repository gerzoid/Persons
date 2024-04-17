using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class ListTables
    {
        [Key]
        public int ListTableId {  get; set; }
        public string NameList { get; set; }
        public string TableName { get; set; }
        public string? Description {  get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set;}
        public DateTime? ExpiredAt { get; set; }
    }
}
