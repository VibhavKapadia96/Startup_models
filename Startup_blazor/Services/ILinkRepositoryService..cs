using Startup_models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Startup_blazor.Services
{
    public interface ILinkRepositoryService
    {
        Task<IEnumerable<LinkRepository>> GetLinks();
        Task<IEnumerable<LinkRepository>> GetLinksbyCategoryId(int id);
    }
}
