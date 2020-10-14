using Microsoft.EntityFrameworkCore;
using Startup_models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Startup_API.Models
{
    public class CRUDLinkRepository : ILinkRepository
    {

        public readonly AppDbContext appDbContext;

        public CRUDLinkRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<LinkRepository> AddLink(LinkRepository link)
        {

            var result = await appDbContext.LinkRepository.AddAsync(link);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<LinkRepository> DeleteLink(int LinkId)
        {
            var result = await appDbContext.LinkRepository
                .FirstOrDefaultAsync(e => e.Id == LinkId);
            if (result != null)
            {
                appDbContext.LinkRepository.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<LinkRepository> GetLink(int LinkId)
        {
            return await appDbContext.LinkRepository
                .FirstOrDefaultAsync(e => e.Id == LinkId);
        }

       

        public async Task<LinkRepository> GetLinkbyName(string Link)
        {
            return await appDbContext.LinkRepository
                .FirstOrDefaultAsync(e => e.link == Link);
        }

     

        public async Task<IEnumerable<LinkRepository>> GetLinks()
        {
            return await appDbContext.LinkRepository.ToListAsync();
        }

        public async Task<LinkRepository> UpdateLink(LinkRepository link)
        {
            var result = await appDbContext.LinkRepository.FirstOrDefaultAsync(e => e.Id == link.Id);
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