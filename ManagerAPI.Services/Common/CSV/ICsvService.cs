using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ManagerAPI.Services.Common.CSV
{
    /// <summary>
    /// CSV Service
    /// </summary>
    public interface ICsvService
    {
        /// <summary>
        /// Generate table export
        /// </summary>
        /// <param name="objectList">Object list</param>
        /// <param name="columnList">Displayed columns</param>
        /// <param name="fileName">File name</param>
        /// <param name="appendCurrentDate">Append current date to file name</param>
        /// <typeparam name="T">Type of the table rows</typeparam>
        /// <returns>Generated file</returns>
        FileStreamResult GenerateTableExport<T>(IEnumerable<T> objectList, IEnumerable<Header> columnList,
            string fileName, bool appendCurrentDate);
    }
}