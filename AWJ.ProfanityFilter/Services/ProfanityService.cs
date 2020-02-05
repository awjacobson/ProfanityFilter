using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AWJ.ProfanityFilter.Services
{
    public class ProfanityService
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

        public static bool HasUrl(string input)
        {
            var regex = new Regex(@"(https?:\/\/(?:www\.|(?!www))[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|www\.[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|https?:\/\/(?:www\.|(?!www))[a-zA-Z0-9]+\.[^\s]{2,}|www\.[a-zA-Z0-9]+\.[^\s]{2,})", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            return regex.IsMatch(input);
        }

        public static bool HasNonEnglish(string input)
        {
            // ^[\x00-\x7F]+$
            // \P{M}\p{M}
            var regex = new Regex(@"^[\x00-\x7F]+$", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            return !regex.IsMatch(input);
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
