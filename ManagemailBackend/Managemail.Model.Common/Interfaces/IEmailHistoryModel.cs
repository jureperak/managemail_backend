using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managemail.Model.Common.Interfaces
{
    public interface IEmailHistoryModel
    {
        Guid Id { get; set; }
        DateTime DateCreated { get; set; }
        DateTime DateUpdated { get; set; }
        string FromEmailAddress { get; set; }
        string ToEmailAddress { get; set; }
        string CcemailAddress { get; set; }
        string Subject { get; set; }
        string Content { get; set; }
        Guid ImportanceTypeId { get; set; }
        IImportanceTypeModel ImportanceType {get; set;}
    }
}
