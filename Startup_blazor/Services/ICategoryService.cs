using Startup_models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Startup_blazor.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Categories>> Getcategories();
        Task<IEnumerable<Categories>> GetcategoryDetails(string name);
    }
}
