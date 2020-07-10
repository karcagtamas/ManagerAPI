﻿using System;

namespace ManagerAPI.Models.Models
{
    public class TaskModel
    {
        public string Title { get; set; }
        public DateTime Deadline { get; set; }
        public string Description { get; set; }

        public TaskModel() { }
    }
}
