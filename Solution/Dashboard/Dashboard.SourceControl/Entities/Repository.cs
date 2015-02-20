using System;

namespace Dashboard.SourceControl.Entities
{
    public class Repository
    {
        public string Name { get; set; }

        public string Slug { get; set; }

        public string Description { get; set; }

        public string WebSite { get; set; }

        public string Owner { get; set; }

        public string Language { get; set; }

        public string Logo { get; set; }

        public string ResourceUri { get; set; }

        public bool IsPrivate { get; set; }
        
        public string SourceControlManager { get; set; }

        public int Size { get; set; }

        public DateTime Created { get; set; }

        public DateTime? LastUpdated { get; set; }
    }
}
