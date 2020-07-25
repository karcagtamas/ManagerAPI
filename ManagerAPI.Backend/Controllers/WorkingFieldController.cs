﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManagerAPI.Domain.Entities.WM;
using ManagerAPI.Services.Services;
using ManagerAPI.Services.Services.Interfaces;
using ManagerAPI.Shared.DTOs.WM;
using ManagerAPI.Shared.Models.WM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagerAPI.Backend.Controllers
{
    [Route("api/working-field")]
    [ApiController]
    public class WorkingFieldController : MyController<WorkingField, WorkingFieldModel, WorkingFieldListDto, WorkingFieldDto>
    {
        private readonly IWorkingFieldService _workingFieldService;
        public WorkingFieldController(IWorkingFieldService workingFieldService, ILoggerService loggerService) : base(loggerService, workingFieldService)
        {
            this._workingFieldService = workingFieldService;
        }
    }
}