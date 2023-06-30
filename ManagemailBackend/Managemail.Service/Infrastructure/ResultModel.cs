using Managemail.Service.Common.Infrastructure;
using System;

namespace Managemail.Service.Infrastructure
{
    public class ResultModel : IResultModel
    {
        public Boolean Succeeded { get; set; }
        public String Message { get; set; }
        public Object Value { get; set; }
    }
}
