﻿using System.Collections.Generic;

namespace ManagerAPI.Shared.DTOs.MC
{
    public class SeasonListDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public List<EpisodeListDto> Episodes { get; set; }
    }
}