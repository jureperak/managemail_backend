using Managemail.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managemail.Common.Extensions
{
    public static class StringExtensions
    {
        public static KeyValuePair<String, EnumConstant.SortingPairs> GetSorter(this string value)
        {
            KeyValuePair<String, EnumConstant.SortingPairs> sorter = new KeyValuePair<string, EnumConstant.SortingPairs>("Id", EnumConstant.SortingPairs.Desc);
            if (!string.IsNullOrWhiteSpace(value) && value.Contains("|"))
            {
                var splited = value.Split("|");
                if(splited.Count() == 2)
                {
                    if(Enum.TryParse(splited[1], true, out EnumConstant.SortingPairs sortingDirection))
                    {
                        sorter = new KeyValuePair<string, EnumConstant.SortingPairs>(splited[0], sortingDirection);
                    }
                }
            }

            return sorter;
        }

        public static KeyValuePair<String, EnumConstant.SortingPairs> GetDefaultLookupSorter(this string value)
        {
            KeyValuePair<String, EnumConstant.SortingPairs> sorter = new KeyValuePair<string, EnumConstant.SortingPairs>("Sort", EnumConstant.SortingPairs.Asc);
            if (!string.IsNullOrWhiteSpace(value) && value.Contains("|"))
            {
                var splited = value.Split("|");
                if (splited.Count() == 2)
                {
                    if (Enum.TryParse(splited[1], true, out EnumConstant.SortingPairs sortingDirection))
                    {
                        sorter = new KeyValuePair<string, EnumConstant.SortingPairs>(splited[0], sortingDirection);
                    }
                }
            }

            return sorter;
        }

    }
}
