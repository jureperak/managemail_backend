using System;
using System.Collections.Generic;

#nullable disable

namespace Managemail.DAL.Entities
{
    public partial class EmailHistory
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string FromEmailAddress { get; set; }
        public string ToEmailAddress { get; set; }
        public string CcemailAddress { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public Guid ImportanceTypeId { get; set; }

        public virtual ImportanceType ImportanceType { get; set; }
    }
}
