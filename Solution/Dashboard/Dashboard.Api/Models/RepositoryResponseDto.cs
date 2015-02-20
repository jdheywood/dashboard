using System;

namespace Dashboard.Api.Models
{
    public class RepositoryResponseDto
    {
        public string Name { get; set; }
       
        public string Description { get; set; }

        public string Language { get; set; }

        public DateTime Created { get; set; }

        public string FullName { get; set; }
    }
}