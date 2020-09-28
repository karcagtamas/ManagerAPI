﻿using System;

namespace ManagerAPI.Shared.DTOs.CSM
{
    public class PersonTable
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public bool IsAvailable { get; set; }
        public string WorkId { get; set; }
    }
}