using Microsoft.EntityFrameworkCore;
using Startup_models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Startup_API.Models
{
    public class CRUDLinkRepo : ILinkRepo
    {

        public readonly AppDbContext appDbContext;

        public CRUDLinkRepo(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<LinkRepo> AddLink(LinkRepo link)
        {
            var result = await appDbContext.LinkRepo.AddAsync(link);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<LinkRepo> DeleteLink(int LinkId)
        {
            var result = await appDbContext.LinkRepo
                .FirstOrDefaultAsync(e => e.Id == LinkId);
            if (result != null)
            {
                appDbContext.LinkRepo.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<LinkRepo> GetLink(int LinkId)
        {
            return await appDbContext.LinkRepo
                .FirstOrDefaultAsync(e => e.Id == LinkId);
        }

        public async Task<LinkRepo> GetLinkbyName(string Link)
        {
            return await appDbContext.LinkRepo
                .FirstOrDefaultAsync(e => e.link == Link);
        }

        public async Task<IEnumerable<LinkRepo>> GetLinks()
        {
            return await appDbContext.LinkRepo.ToListAsync();
        }

        public async Task<LinkRepo> UpdateLink(LinkRepo link)
        {
            var result = await appDbContext.LinkRepo.FirstOrDefaultAsync(e => e.Id == link.Id);
            if (result != null)
            {
                result.link = link.link;
                await appDbContext.SaveChangesAsync();
                return result;
            }   
            return null;
        }
    }
}
