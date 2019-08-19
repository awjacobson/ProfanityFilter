using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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

            try
            {
                using (var client = new HttpClient())
                {
                    var file = await client.GetStringAsync(uri);
                    var lines = file
                        .Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None)
                        .ToList()
                        .Where(l => !l.StartsWith("#"));
                    return lines;
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
