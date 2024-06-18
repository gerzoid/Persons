using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    [Index(nameof(TableId),nameof(Name))]
    public class SettingsTables
    {
        [Key]        
        public int SettingsTableId { get; set; }
        public int TableId { get; set; }
        public Tables Table { get; set; }

        //Название настройки
        //filter - поле для фильтрации
        //unique - уникальное поле
        public required string Name { get; set; }
        //Имя поля, как есть в БД
        public required string Field { get; set; }
        //Имя поля для юзера
        public required string NameField { get; set; }

    }
}
