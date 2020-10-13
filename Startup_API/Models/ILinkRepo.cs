using Startup_models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Startup_API.Models
{
    public interface ILinkRepo
    {
        Task<IEnumerable<LinkRepo>> GetLinks();
        Task<LinkRepo> GetLink(int SourceId);
        Task<LinkRepo> GetLinkbyName(string SourceName);
        Task<LinkRepo> AddLink(LinkRepo linkRepo);
        Task<LinkRepo> UpdateLink(LinkRepo linkRepo);
        Task<LinkRepo> DeleteLink(int SourceId);
       

    }
}
