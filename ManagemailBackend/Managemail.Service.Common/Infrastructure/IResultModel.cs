using System;

namespace Managemail.Service.Common.Infrastructure
{
    public interface IResultModel
    {
        public Boolean Succeeded { get; set; }
        public String Message { get; set; }
        public Object Value { get; set; }
    }
}
