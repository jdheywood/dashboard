using System;

namespace Dashboard.SourceControl.Entities
{
    public class Repository
    {
        public string SourceControlManager { get; set; }

        public bool HasWiki { get; set; }

        public string Description { get; set; }

        // TODO Links

        public string Name { get; set; }

        public string Language { get; set; }

        public DateTime Created { get; set; }

        public string FullName { get; set; }

        public int Size { get; set; }

        public bool IsPrivate { get; set; }

        public string Uuid { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}
