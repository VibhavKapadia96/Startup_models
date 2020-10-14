using Startup_models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Startup_API.Models
{
    public interface ILinkRepository
    {
        Task<IEnumerable<LinkRepository>> GetLinks();
        Task<LinkRepository> GetLink(int linkId);
        Task<LinkRepository> GetLinkbyName(string SourceName);
        Task<LinkRepository> AddLink(LinkRepository linkRepo);
        Task<LinkRepository> UpdateLink(LinkRepository linkRepo);
        Task<LinkRepository> DeleteLink(int linkId);
      


    }
}