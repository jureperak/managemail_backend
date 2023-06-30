using Managemail.Common.Constants;
using Managemail.Model.Common.Infrastructure;
using System;
using System.Collections.Generic;

namespace Managemail.Model.Infrastructure
{
    public class OptionsParameters : IOptionsParameters
    {
        public List<String> Includes { get; set; }
        public KeyValuePair<String, EnumConstant.SortingPairs>? Sorter { get; set; }
    }
}
