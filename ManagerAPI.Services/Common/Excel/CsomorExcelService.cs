using ClosedXML.Excel;
using KarcagS.Common.Tools.Export;
using KarcagS.Common.Tools.Export.Excel;
using ManagerAPI.Domain.Entities.CSM;
using ManagerAPI.Shared.DTOs.CSM;
using ManagerAPI.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace ManagerAPI.Services.Common.Excel;

/// <inheritdoc />
public class CsomorExcelService : ExcelService, ICsomorExcelService
{
    /// <inheritdoc />
    public ExportResult GeneratePersonCsomor(List<CsomorPerson> persons)
    {
        persons = persons.OrderBy(x => x.Name).ToList();
        const string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        string name = $"{DateHelper.ToFileName(DateTime.Now)}_persons.xlsx";

        using (var workbook = new XLWorkbook())
        {
            var worksheet = workbook.Worksheets.Add("Persons");

            // Header
            for (int i = 0; i < persons.Count; i++)
            {
                worksheet.Cell(1, i + 2).Value = persons[i].Name;
            }

            var groups = persons.SelectMany(x => x.Tables).GroupBy(x => x.Date).OrderBy(x => x.Key);

            // Date Col
            int rowNo = 2;
            foreach (var row in groups)
            {
                worksheet.Cell(rowNo, 1).Value = WriteHelper.HourInterval(row.Key, 1);

                int colNo = 2;
                foreach (var col in row)
                {
                    worksheet.Cell(rowNo, colNo).Value = col.Work != null ? col.Work.Name : "-";
                    colNo++;
                }
                rowNo++;
            }

            var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return new ExportResult { Content = stream.ToArray(), FileName = name, ContentType = contentType };
        }
    }

    /// <inheritdoc />
    public FileStreamResult GenerateTableExport<T>(IEnumerable<T> objectList, IEnumerable<Header> columnList,
        string fileName,
        bool appendCurrentDate)
    {
        const string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        string name = appendCurrentDate
            ? $"{DateHelper.DateToString(DateTime.Now)}{fileName}.xlsx"
            : $"{fileName}.xlsx";

        using (var workbook = new XLWorkbook())
        {
            var worksheet = workbook.Worksheets.Add(fileName);

            // Header
            var columns = columnList.ToList();
            for (int i = 0; i < columns.Count; i++)
            {
                worksheet.Cell(1, i + 1).Value = columns[i].DisplayName;
            }

            var objects = objectList.ToList();
            for (int i = 0; i < objects.Count; i++)
            {
                for (int j = 0; j < columns.Count; j++)
                {
                    worksheet.Cell(2 + i, j + 1).Value = columns[j].GetValue(objects[i]);
                }
            }

            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);

                return new FileStreamResult(stream, contentType) { FileDownloadName = name };
            }
        }
    }

    /// <inheritdoc />
    public ExportResult GenerateWorkCsomor(List<CsomorWork> works)
    {
        works = works.OrderBy(x => x.Name).ToList();
        const string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        string name = $"{DateHelper.ToFileName(DateTime.Now)}_works.xlsx";

        using (var workbook = new XLWorkbook())
        {
            var worksheet = workbook.Worksheets.Add("Works");

            // Header
            for (int i = 0; i < works.Count; i++)
            {
                worksheet.Cell(1, i + 2).Value = works[i].Name;
            }

            var groups = works.SelectMany(x => x.Tables).GroupBy(x => x.Date).OrderBy(x => x.Key);

            // Date Col
            int rowNo = 2;
            foreach (var row in groups)
            {
                worksheet.Cell(rowNo, 1).Value = WriteHelper.HourInterval(row.Key, 1);

                int colNo = 2;
                foreach (var col in row)
                {
                    worksheet.Cell(rowNo, colNo).Value = col.Person != null ? col.Person.Name : "-";
                    colNo++;
                }
                rowNo++;
            }

            var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return new ExportResult { Content = stream.ToArray(), FileName = name, ContentType = contentType };
        }
    }
}
