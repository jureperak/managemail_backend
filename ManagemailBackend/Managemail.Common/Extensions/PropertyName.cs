using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Managemail.Common.Infrastructure
{
    public static class PropertyName
    {
        public static string GetPropertyName<T>(this Expression<Func<T, object>> propertyExpression)
        {
            MemberExpression mbody = propertyExpression.Body as MemberExpression;

            if (mbody == null)
            {
                UnaryExpression ubody = propertyExpression.Body as UnaryExpression;

                if (ubody != null)
                {
                    mbody = ubody.Operand as MemberExpression;
                }

                if (mbody == null)
                {
                    throw new ArgumentException("Expression is not a MemberExpression", "propertyExpression");
                }
            }

            return mbody.Member.Name;
        }
    }
}
