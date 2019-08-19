using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AWJ.ProfanityFilter.Repositories
{
    public interface IProfanityRepository
    {
        Task<IEnumerable<string>> ReadAsync(Uri uri);
    }

    public class ProfanityRepository : IProfanityRepository
    {
        public async Task<IEnumerable<string>> ReadAsync(Uri uri)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));

            using (var client = new HttpClient())
            {
                var content = await client.GetStringAsync(uri);
                var lines = ParseLines(content);
                return lines;
            }
        }

        public IEnumerable<string> ParseLines(string content)
        {
            var lines = content
                .Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None)
                .ToList()
                .Where(l => !l.StartsWith("#"))
                .Select(l => l.Trim())
                .Where(l => !string.IsNullOrWhiteSpace(l));
            return lines;
        }
    }
}
