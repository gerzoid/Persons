using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    [Index(nameof(ListTableId),nameof(Name))]
    public class SettingsTables
    {
        [Key]
        public int SettingsTableId { get; set; }
        public int ListTableId { get; set; }
        public Tables ListTable { get; set; }

        //Название настройки        
        public required string Name { get; set; }
        public required string Field { get; set; }
        public required string NameField { get; set; }

    }
}
