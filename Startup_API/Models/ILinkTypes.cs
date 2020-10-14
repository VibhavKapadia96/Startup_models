using Startup_models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Startup_API.Models
{
    public interface ILinkTypes
    {
        Task<IEnumerable<LinkType>> GetLinkTypes();
        Task<LinkType> GetLinkType(int linkTypeId);
        Task<LinkType> GetLinkTypebyName(string linkTypeName);
        Task<LinkType> AddLinkType(LinkType linkType);
        Task<LinkType> UpdateLinkType(LinkType linkType);
        Task<LinkType> DeleteLinkType(int linkTypeId);


    }
}
