using System.Collections.Generic;

namespace Dashboard.Api.Models
{
    public class RepositoriesResponseDto
    {
        public IEnumerable<RepositoryResponseDto> Repositories { get; set; }
    }
}