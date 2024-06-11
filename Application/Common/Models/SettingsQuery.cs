namespace Application.Common.Models
{
    public class SettingsQuery
    {
        public int Top { get; set; }
        public string[] Columns { get; set; }
        public string[] ColumnsOrder { get; set; }
    }
}
