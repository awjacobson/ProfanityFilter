using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AWJ.ProfanityFilter.Services
{
    public interface IProfanityService
    {
        bool HasBadWords(string input);
    }

    public class ProfanityService : IProfanityService
    {
        private readonly IList<string> _patterns;

        public ProfanityService(IEnumerable<string> badwords)
        {
            _patterns = new List<string>();
            foreach (var badword in badwords)
            {
                _patterns.Add(CreatePattern(badword));
            }
        }

        public bool HasBadWords(string input)
        {
            foreach (var pattern in _patterns)
            {
                var regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);
                if (regex.IsMatch(input))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// porn => /\Wporn\W/
        /// </remarks>
        /// <param name="input"></param>
        /// <returns></returns>
        public string CreatePattern(string input)
        {
            return $@"(^|\W){input}($|\W)";
        }
    }
}
