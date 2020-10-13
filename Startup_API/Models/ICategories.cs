using Startup_models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Startup_API.Models
{
    public interface ICategories
    {
        Task<IEnumerable<Categories>> GetCategories();
        Task<Categories> GetCategory(int categoryId);
        Task<IEnumerable<Categories>> GetSubCategorybyName(string categoryName);
        Task<Categories> GetCategorybyName(string categoryName, string categoryParent);
        Task<Categories> AddCategory(Categories category);
        Task<Categories> UpdateCategory(Categories category);
        Task<Categories> DeleteCategory(int categoryId);
        Task<IEnumerable<Categories>> Search(string categoryName, string categoryParent=null);

    }
}
