using KarcagS.Common.Tools.Export;
using KarcagS.Common.Tools.Export.PDF;
using ManagerAPI.Domain.Entities.CSM;
using ManagerAPI.Shared.DTOs.CSM;

namespace ManagerAPI.Services.Common.PDF;

/// <summary>
/// PDF Service
/// </summary>
public interface ICsomorPDFService : IPDFService
{
    /// <summary>
    /// Generate person csomor doc
    /// </summary>
    /// <param name="persons">List of persons</param>
    /// <returns>Export Result</returns>
    ExportResult GeneratePersonCsomor(List<CsomorPerson> persons);

    /// <summary>
    /// Generate work csomor doc
    /// </summary>
    /// <param name="works">List of works</param>
    /// <returns>Export Result</returns>
    ExportResult GenerateWorkCsomor(List<CsomorWork> works);
}
