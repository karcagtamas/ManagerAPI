﻿namespace ManagerAPI.Models.DTOs
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsSolved { get; set; }
    }
}
