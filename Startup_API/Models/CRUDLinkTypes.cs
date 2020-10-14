using Microsoft.EntityFrameworkCore;
using Startup_models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Startup_API.Models
{
    public class CRUDLinkTypes : ILinkTypes
    {

        public readonly AppDbContext appDbContext;

        public CRUDLinkTypes(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<LinkType> AddLinkType(LinkType linkType)
        {
            var result = await appDbContext.LinkType.AddAsync(linkType);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<LinkType> DeleteLinkType(int LinkTypeId)
        {
            var result = await appDbContext.LinkType
                .FirstOrDefaultAsync(e => e.Id == LinkTypeId);
            if (result != null)
            {
                appDbContext.LinkType.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<LinkType> GetLinkType(int LinkTypeId)
        {
            return await appDbContext.LinkType
                .FirstOrDefaultAsync(e => e.Id == LinkTypeId);
        }

        public async Task<LinkType> GetLinkTypebyName(string LinkTypeName)
        {
            return await appDbContext.LinkType
                .FirstOrDefaultAsync(e => e.Linktype_Name == LinkTypeName);
        }

        public async Task<IEnumerable<LinkType>> GetLinkTypes()
        {
            return await appDbContext.LinkType.ToListAsync();
        }

        public async Task<LinkType> UpdateLinkType(LinkType linkType)
        {
            var result = await appDbContext.LinkType.FirstOrDefaultAsync(e => e.Id == linkType.Id);
            if (result != null)
            {
                result.Linktype_Name = linkType.Linktype_Name;
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
