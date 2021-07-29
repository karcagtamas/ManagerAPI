using ManagerAPI.Shared.DTOs.CSM;

namespace ManagerAPI.Shared.Models.CSM
{
    /// <summary>
    /// Csomor Access Model
    /// </summary>
    public class CsomorAccessModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Has Write access
        /// </summary>
        public bool HasWriteAccess { get; set; }

        /// <summary>
        /// Init Csomor Access Model
        /// </summary>
        public CsomorAccessModel() { }

        /// <summary>
        /// Init Csomor Access Model from Csomor Access
        /// </summary>
        /// <param name="dto">Csomor Access</param>
        public CsomorAccessModel(CsomorAccessDTO dto)
        {
            this.Id = dto.Id;
            this.HasWriteAccess = dto.HasWriteAccess;
        }
    }
}
