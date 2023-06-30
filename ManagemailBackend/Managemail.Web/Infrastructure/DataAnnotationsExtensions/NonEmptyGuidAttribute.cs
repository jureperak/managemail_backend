using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managemail.Web.Infrastructure.DataAnnotationsExtensions
{
    public class NonEmptyGuidAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Guid modelGuid = Guid.NewGuid();
            if (Guid.TryParse(value.ToString(), out modelGuid))
            {
                return !modelGuid.Equals(Guid.Empty);
            }
            return false;
        }
    }
}
