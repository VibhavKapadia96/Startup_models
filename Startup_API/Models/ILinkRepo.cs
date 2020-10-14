using Startup_models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Startup_API.Models
{
    public interface ILinkRepo
    {
        Task<IEnumerable<linkRepository>> GetLinks();
        Task<linkRepository> GetLink(int linkId);
        Task<linkRepository> GetLinkbyName(string SourceName);
        Task<linkRepository> AddLink(linkRepository linkRepo);
        Task<linkRepository> UpdateLink(linkRepository linkRepo);
        Task<linkRepository> DeleteLink(int linkId);
        Task<linkRepository> GetLinkbyCategoryId(int categoryId);
        Task<linkRepository> GetLinkbyLinkTypeId(int LinkTypeId);
        Task<linkRepository> GetLinkbySourceId(int SourceId);


    }
}