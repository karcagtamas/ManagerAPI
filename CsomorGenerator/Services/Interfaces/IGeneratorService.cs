using KarcagS.Common.Tools.Export;
using ManagerAPI.Shared.DTOs;
using ManagerAPI.Shared.DTOs.CSM;
using ManagerAPI.Shared.Enums;
using ManagerAPI.Shared.Models.CSM;
using System.Collections.Generic;

namespace CsomorGenerator.Services.Interfaces
{
    /// <summary>
    /// Generator Service
    /// </summary>
    public interface IGeneratorService
    {
        /// <summary>
        /// Generate Csomor
        /// </summary>
        /// <param name="settings">Source settings</param>
        /// <return>Modified settings</return>
        GeneratorSettings? Generate(GeneratorSettings settings);

        /// <summary>
        /// Generate simple solution
        /// </summary>
        /// <param name="settings">Source settings</param>
        /// <return>Modified settings</return>
        GeneratorSettings? GenerateSimple(GeneratorSettings settings);

        /// <summary>
        /// Create Csomor
        /// </summary>
        /// <param name="model">Source model</param>
        /// <return>Newly created Csomor Id</return>
        int Create(GeneratorSettingsModel model);

        /// <summary>
        /// Update Csomor
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="model">Source model</param>
        void Update(int id, GeneratorSettingsModel model);

        /// <summary>
        /// Delete Csomor
        /// </summary>
        /// <param name="id">Id</param>
        void Delete(int id);

        /// <summary>
        /// Get Csomor by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Settings</returns>
        GeneratorSettings Get(int id);

        /// <summary>
        /// Get public csomor list
        /// </summary>
        /// <returns>Public list</returns>
        List<CsomorListDTO> GetPublicList();

        /// <summary>
        /// Get owned csomor list
        /// </summary>
        /// <returns>Owned list</returns>
        List<CsomorListDTO> GetOwnedList();

        /// <summary>
        /// Get shared csomor list
        /// </summary>
        /// <returns>Shared list</returns>
        List<CsomorListDTO> GetSharedList();

        /// <summary>
        /// Share Csomor
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="models">Access models</param>
        void Share(int id, List<CsomorAccessModel> models);

        /// <summary>
        /// Change public status
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="model">Model</param>
        void ChangePublicStatus(int id, GeneratorPublishModel model);

        /// <summary>
        /// Get role for csomor
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Role</returns>
        CsomorRole GetRoleForCsomor(int id);

        /// <summary>
        /// Export to PDF
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="type">Type</param>
        /// <param name="filterList">Filter list</param>
        /// <returns>PDF export</returns>
        ExportResult ExportPdf(int id, CsomorType type, List<string> filterList);

        /// <summary>
        /// Export to XLS
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="type">Type</param>
        /// <param name="filterList">Filter list</param>
        /// <returns>XLS export</returns>
        ExportResult ExportXls(int id, CsomorType type, List<string> filterList);

        /// <summary>
        /// Get shared person list
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Csomor accesses</returns>
        List<CsomorAccessDTO> GetSharedPersonList(int id);

        /// <summary>
        /// Get available presons
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="name">Filter</param>
        /// <returns>Persons</returns>
        List<UserShortDto> GetCorrectPersonsForSharing(int id, string name);
    }
}