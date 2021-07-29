﻿using EventManager.Client.Http;
using ManagerAPI.Shared.DTOs.WM;
using ManagerAPI.Shared.Models.WM;

namespace EventManager.Client.Services.Interfaces
{
    /// <summary>
    /// Working day type Service
    /// </summary>
    public interface IWorkingDayTypeService : IHttpCall<WorkingDayTypeListDto, WorkingDayTypeDto, WorkingDayTypeModel>
    {
    }
}