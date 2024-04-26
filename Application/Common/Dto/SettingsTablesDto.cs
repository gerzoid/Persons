using System.ComponentModel.DataAnnotations;

namespace Application.Common.Dto
{
    public class SettingsTablesDto
    {
        public int SettingsTableId { get; set; }
        //Название настройки        
        public required string Name { get; set; }
        public required string Field { get; set; }
        public required string NameField { get; set; }
    }
}
