using Microsoft.EntityFrameworkCore;
using Startup_models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Startup_API.Models
{
    public class CRUDSources : ISources
    {

        public readonly AppDbContext appDbContext;

        public CRUDSources(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Sources> AddSource(Sources source)
        {
            var result = await appDbContext.Sources.AddAsync(source);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Sources> DeleteSource(int SourceId)
        {
            var result = await appDbContext.Sources
                .FirstOrDefaultAsync(e => e.Id == SourceId);
            if (result != null)
            {
                appDbContext.Sources.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<Sources> GetSource(int SourceId)
        {
            return await appDbContext.Sources
                .FirstOrDefaultAsync(e => e.Id == SourceId);
        }

        public async Task<Sources> GetSourcebyName(string SourceName)
        {
            return await appDbContext.Sources
                .FirstOrDefaultAsync(e => e.Source_Name == SourceName);
        }

        public async Task<IEnumerable<Sources>> GetSources()
        {
            return await appDbContext.Sources.ToListAsync();
        }

        public async Task<Sources> UpdateSource(Sources source)
        {
            var result = await appDbContext.Sources.FirstOrDefaultAsync(e => e.Id == source.Id);
            if (result != null)
            {
                result.Source_Name = source.Source_Name;
                await appDbContext.SaveChangesAsync();
                return result;
            }   
            return null;
        }
    }
}
