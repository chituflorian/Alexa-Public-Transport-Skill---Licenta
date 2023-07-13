using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CityTransport.Infrastructure.DataRegex
{
    public static class RatBVDbDataRegex
    {
        public static bool MatchesStadMunicipal(string inputString)
        {
            string regexPattern = @"stad(\.|ionul)? municipal(e)?";

            Regex regex = new Regex(regexPattern);
            return regex.IsMatch(inputString);
        }
    }
}
