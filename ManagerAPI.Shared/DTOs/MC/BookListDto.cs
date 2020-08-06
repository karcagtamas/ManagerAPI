using System;

namespace ManagerAPI.Shared.DTOs.MC
{
    public class BookListDto : IIdentified
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public DateTime? Publish { get; set; }

        public string Creator { get; set; }
    }
}