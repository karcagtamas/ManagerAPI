﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Client.Models.Tasks
{
    public class TaskDateDto
    {
        public DateTime Deadline { get; set; }
        public List<TaskDto> TaskList { get; set; }
    }
}
