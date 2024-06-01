using System.Data;

namespace Web.Helpers
{
    public static class DataTableToJsonSerializer
    {
        public static string SystemTextJson(DataTable dataTable)
        {
            if (dataTable == null)
            {
                return string.Empty;
            }
            var data = dataTable.Rows.OfType<DataRow>()
                        .Select(row => dataTable.Columns.OfType<DataColumn>()
                             .ToDictionary(col => col.ColumnName, c => row[c] == DBNull.Value ? "" : row[c]));
            return System.Text.Json.JsonSerializer.Serialize(data);
        }
    }
}
