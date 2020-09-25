﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerAPI.Shared.Models.CSM
{
    public class PersonTableModel
    {
        public DateTime Date;
        public bool IsAvailable { get; set; }
        public string WorkId { get; set; }

        public PersonTableModel() { }

        public PersonTableModel(DateTime date)
        {
            this.Date = date;
            this.IsAvailable = true;
            this.WorkId = null;
        }
    }
}
