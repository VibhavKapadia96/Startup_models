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

        public async Task<linkRepository> AddLink(linkRepository link)
        {

           
            var result = await appDbContext.LinkRepo.AddAsync(link);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<linkRepository> DeleteLink(int LinkId)
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

        public async Task<linkRepository> GetLink(int LinkId)
        {
            return await appDbContext.LinkRepo
                .FirstOrDefaultAsync(e => e.Id == LinkId);
        }

        public async Task<linkRepository> GetLinkbyCategoryId(int categoryId)
        {
            return await appDbContext.LinkRepo
                .FirstOrDefaultAsync(e => e.categoryId == categoryId);
        }

        public async Task<linkRepository> GetLinkbyLinkTypeId(int LinkTypeId)
        {
            return await appDbContext.LinkRepo
                .FirstOrDefaultAsync(e => e.linkTypeId == LinkTypeId);
        }

        public async Task<linkRepository> GetLinkbyName(string Link)
        {
            return await appDbContext.LinkRepo
                .FirstOrDefaultAsync(e => e.link == Link);
        }

        public async Task<linkRepository> GetLinkbySourceId(int SourceId)
        {
            return await appDbContext.LinkRepo
                .FirstOrDefaultAsync(e => e.sourcesId == SourceId);
        }

        public async Task<IEnumerable<linkRepository>> GetLinks()
        {
            return await appDbContext.LinkRepo.ToListAsync();
        }

        public async Task<linkRepository> UpdateLink(linkRepository link)
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