using Managemail.Model.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managemail.Model.Implementations
{
    public class EmailHistoryModel : BaseModel, IEmailHistoryModel
    {
        public string FromEmailAddress { get; set; }
        public string ToEmailAddress { get; set; }
        public string CcemailAddress { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public Guid ImportanceTypeId { get; set; }
        public IImportanceTypeModel ImportanceType { get; set; }
    }
}
