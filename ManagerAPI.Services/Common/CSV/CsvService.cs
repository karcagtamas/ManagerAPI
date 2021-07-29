using ManagerAPI.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ManagerAPI.Services.Common.CSV
{
    /// <inheritdoc />
    public class CsvService : ICsvService
    {
        /// <inheritdoc />
        public FileStreamResult GenerateTableExport<T>(IEnumerable<T> objectList, IEnumerable<Header> columnList,
            string fileName,
            bool appendCurrentDate)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(string.Join(",", columnList.Select(x => x.DisplayName).ToList()));


            foreach (var obj in objectList)
            {
                stringBuilder.AppendLine(string.Join(",", columnList.Select(x => x.GetValue(obj)).ToList()));
            }

            var result = new FileStreamResult(new MemoryStream(Encoding.UTF8.GetBytes(stringBuilder.ToString())),
                "text/csv")
            {
                FileDownloadName = appendCurrentDate
                    ? $"{DateHelper.DateToString(DateTime.Now)}{fileName}.csv"
                    : $"{fileName}.csv"
            };

            return result;
        }
    }
}