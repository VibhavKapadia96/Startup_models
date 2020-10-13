using Startup_models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Startup_API.Models
{
    public interface ISources
    {
        Task<IEnumerable<Sources>> GetSources();
        Task<Sources> GetSource(int SourceId);
        Task<Sources> GetSourcebyName(string SourceName);
        Task<Sources> AddSource(Sources source);
        Task<Sources> UpdateSource(Sources source);
        Task<Sources> DeleteSource(int SourceId);
       

    }
}
