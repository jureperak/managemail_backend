using Managemail.Common.Constants;
using System;
using System.Collections.Generic;

namespace Managemail.Model.Common.Infrastructure
{
    public interface IOptionsParameters
    {
        List<String> Includes { get; set; }
        KeyValuePair<String, EnumConstant.SortingPairs>? Sorter { get; set; }
    }
}
