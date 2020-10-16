﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ManagerAPI.Shared.DTOs.CSM
{
    public class ExportResult
    {
        public byte[] Content { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
    }
}
