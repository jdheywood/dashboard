using System;
using System.Collections.Generic;
using Dashboard.SourceControl.Contracts;

namespace Dashboard.SourceControl.Entities
{
    public class Account
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public AccountType AccountType { get; set; }

        public string Website { get; set; }
        
        public string DisplayName { get; set; }

        public IEnumerable<AccountLink> Links { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Location { get; set; }
    }
}