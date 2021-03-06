﻿using ManagerAPI.Shared.DTOs.CSM;

namespace ManagerAPI.Shared.Models.CSM
{
    public class CsomorAccessModel
    {
        public string Id { get; set; }
        public bool HasWriteAccess { get; set; }

        public CsomorAccessModel() { }

        public CsomorAccessModel(CsomorAccessDTO dto)
        {
            this.Id = dto.Id;
            this.HasWriteAccess = dto.HasWriteAccess;
        }
    }
}
