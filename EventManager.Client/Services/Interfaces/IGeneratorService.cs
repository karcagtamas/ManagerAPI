using ManagerAPI.Shared.DTOs;
using ManagerAPI.Shared.DTOs.CSM;
using ManagerAPI.Shared.Enums;
using ManagerAPI.Shared.Models.CSM;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManager.Client.Services.Interfaces
{
    /// <summary>
    /// Generator Service
    /// </summary>
    public interface IGeneratorService
    {
        /// <summary>
        /// Generate Simple by Settings
        /// </summary>
        /// <param name="settings">Generator settings</param>
        /// <returns>Modified settings</returns>
        Task<GeneratorSettings?> GenerateSimple(GeneratorSettings settings);

        /// <summary>
        /// Create csomor
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns>Created Id</returns>
        Task<int> Create(GeneratorSettingsModel model);

        /// <summary>
        /// Update csomor by Id
        /// </summary>
        /// <param name="id">Csomor Id</param>
        /// <param name="model">Model</param>
        Task<bool> Update(int id, GeneratorSettingsModel model);

        /// <summary>
        /// Delete csomor by Id
        /// </summary>
        /// <param name="id">Csomor Id</param>
        Task<bool> Delete(int id);

        /// <summary>
        /// Get csomor by Id
        /// </summary>
        /// <param name="id">Csomor Id</param>
        /// <returns>Settings</returns>
        Task<GeneratorSettings?> Get(int id);

        /// <summary>
        /// Get public list
        /// </summary>
        /// <returns>Csomor list</returns>
        Task<List<CsomorListDTO>> GetPublicList();

        /// <summary>
        /// Get owned list
        /// </summary>
        /// <returns>Csomor list</returns>
        Task<List<CsomorListDTO>> GetOwnedList();

        /// <summary>
        /// Get shared list
        /// </summary>
        /// <returns>Csomor list</returns>
        Task<List<CsomorListDTO>> GetSharedList();

        /// <summary>
        /// Share csomor
        /// </summary>
        /// <param name="id">Csomor Id</param>
        /// <param name="models">Models</param>
        Task<bool> Share(int id, List<CsomorAccessModel> models);

        /// <summary>
        /// Change public status of csomor
        /// </summary>
        /// <param name="id">Csomor Id</param>
        /// <param name="model">Model</param>
        Task<bool> ChangePublicStatus(int id, GeneratorPublishModel model);

        /// <summary>
        /// Get role for Csomor
        /// </summary>
        /// <param name="id">Csomor Id</param>
        Task<CsomorRole> GetRole(int id);

        /// <summary>
        /// Export PDF by Id
        /// </summary>
        /// <param name="id">Csomor Id</param>
        /// <param name="model">Model</param>
        Task<bool> ExportPdf(int id, ExportSettingsModel model);

        /// <summary>
        /// Export XLS by Id
        /// </summary>
        /// <param name="id">Csomor Id</param>
        /// <param name="model">Model</param>
        Task<bool> ExportXls(int id, ExportSettingsModel model);

        /// <summary>
        /// Get shared person list
        /// </summary>
        /// <param name="id">Csomor Id</param>
        /// <returns>List of persons and roles</returns>
        Task<List<CsomorAccessDTO>> GetSharedPersonList(int id);

        /// <summary>
        /// Get available persons for sharing
        /// </summary>
        /// <param name="id">Csomor Id</param>
        /// <param name="name">Name query</param>
        /// <returns>List of users</returns>
        Task<List<UserShortDto>> GetCorrectPersonsForSharing(int id, string name);
    }
}
