using Application.Common.Models;
using Domain.Entities;
using Domain.Interfaces;
using Mapster;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.ComponentModel;
using System.Data;
using System.Globalization;

namespace Application.Services;

public class ExportsService(IPersonsRepository personsRepository)
{
    private readonly IPersonsRepository _personsRepository = personsRepository;

    public void FormattingTable(ExcelWorksheet workSheet, int rowCount, int colCount)
    {
        workSheet.Cells[1, 1, rowCount, colCount].AutoFitColumns();
        workSheet.Cells[1, 1, 1, colCount].Style.Font.Bold = true;
        workSheet.Cells[1, 1, rowCount, colCount].Style.Border.BorderAround(ExcelBorderStyle.Thin);
    }

    public Stream? TableToExcel(DataTable table)
    {
        if (table is null || table.Rows.Count == 0)
            return null;

        ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
        using var stream = new MemoryStream();
        using var package = new ExcelPackage(stream);

        var workSheet = package.Workbook.Worksheets.Add("Sheet1");
        
        workSheet.Cells.loadfromLoadFromDataReader(table, true);

        workSheet.Cells.LoadFromDataTable(table, true);

        int rowCount = workSheet.Dimension.End.Row;
        int colCount = workSheet.Dimension.End.Column;

        for (int i = 0; i < table.Columns.Count; i++)
            if (table.Columns[i].DataType == typeof(DateTime))
                workSheet.Cells[1, i + 1, rowCount, i + 1].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;

        FormattingTable(workSheet, rowCount, colCount);

        package.Save();

        stream.Position = 0;
        return stream;
    }

    public bool Export()
    {
        return true;
    }
}
