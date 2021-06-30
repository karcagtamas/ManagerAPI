using ManagerAPI.Domain.Entities.CSM;
using ManagerAPI.Shared.DTOs.CSM;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ManagerAPI.Services.Common.Excel
{
    /// <summary>
    /// Excel Service
    /// </summary>
    public interface IExcelService
    {
        /// <summary>
        /// Generate export
        /// </summary>
        /// <param name="objectList">Object list</param>
        /// <param name="columnList">Columns</param>
        /// <param name="fileName">File name</param>
        /// <param name="appendCurrentDate">Append current date to the filename</param>
        /// <typeparam name="T">Type of rows</typeparam>
        /// <returns>Export result</returns>
        FileStreamResult GenerateTableExport<T>(IEnumerable<T> objectList, IEnumerable<Header> columnList,
            string fileName, bool appendCurrentDate);

        /// <summary>
        /// Generate person csomor
        /// </summary>
        /// <param name="persons">List of people</param>
        /// <returns>Export result</returns>
        ExportResult GeneratePersonCsomor(List<CsomorPerson> persons);

        /// <summary>
        /// Generate work csomor
        /// </summary>
        /// <param name="works">List of works</param>
        /// <returns>Export result</returns>
        ExportResult GenerateWorkCsomor(List<CsomorWork> works);
    }
}