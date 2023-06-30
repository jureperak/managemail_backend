using System;
using System.Collections.Generic;

#nullable disable

namespace Managemail.DAL.Entities
{
    public partial class ImportanceType
    {
        public ImportanceType()
        {
            EmailHistories = new HashSet<EmailHistory>();
        }

        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public int Sort { get; set; }

        public virtual ICollection<EmailHistory> EmailHistories { get; set; }
    }
}
