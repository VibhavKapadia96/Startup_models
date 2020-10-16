using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using Startup_models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Startup_API.Models
{
    public class CRUDCategories : ICategories
    {

        public readonly AppDbContext appDbContext;

        public CRUDCategories(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }


        public async Task<Categories> AddCategory(Categories category)
        {

            var result = await appDbContext.Categories.AddAsync(category);
            await appDbContext.SaveChangesAsync();

            if (category.Parent_Id == 0)
            {
                result.Entity.topParentMapper = result.Entity.Id.ToString();
                await appDbContext.SaveChangesAsync();
            }
            else
            {
                var result2 = await appDbContext.Categories
                            .FirstOrDefaultAsync(e => e.Id == result.Entity.Parent_Id);

                result.Entity.topParentMapper = result.Entity.Id.ToString() + "," + result2.topParentMapper;
                await appDbContext.SaveChangesAsync();

            }


            return result.Entity;
        }

        public async Task<Categories> DeleteCategory(int categoryId)
        {

            var result = await appDbContext.Categories
            .FirstOrDefaultAsync(e => e.Id == categoryId);
            if (result != null)
            {
                appDbContext.Categories.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<IEnumerable<Categories>> GetCategories()
        {
            IQueryable<Categories> query = appDbContext.Categories;

            query = query.Where(e => e.status == "live").OrderBy(e => e.Parent_Id);

            return await query.ToListAsync();
        }

        public async Task<Categories> GetCategory(int categoryId)
        {
            return await appDbContext.Categories
                .FirstOrDefaultAsync(e => e.Id == categoryId);
        }

        public async Task<Categories> GetCategorybyName(string categoryName, string categoryParent)
        {
            return await appDbContext.Categories
                .FirstOrDefaultAsync(e => e.Category_Name == categoryName && e.Category_Parent == categoryParent);
        }

        public async Task<Categories> GetCategoryByParentId(int categoryId)
        {
            return await appDbContext.Categories
                .FirstOrDefaultAsync(e => e.Parent_Id == categoryId);
        }

        public async Task<IEnumerable<Categories>> GetSubCategorybyName(string categoryName)
        {
            IQueryable<Categories> query = appDbContext.Categories;

            query = query.Where(e => e.Category_Parent == categoryName);

            return await query.ToListAsync();

        }

        public async Task<IEnumerable<Categories>> Search(string categoryName, string categoryParent)
        {
            IQueryable<Categories> query = appDbContext.Categories;

            if (!string.IsNullOrEmpty(categoryName))
            {
                query = query.Where(e => e.Category_Name.Contains(categoryName));
            }

            if (categoryParent != null)
            {
                query = query.Where(e => e.Category_Parent.Contains(categoryParent));
            }

            return await query.ToListAsync();
        }

        public async Task<Categories> UpdateCategory(Categories category)
        {
            var result = await appDbContext.Categories
                .FirstOrDefaultAsync(e => e.Id == category.Id);

            if (result != null)
            {
                result.Category_Name = category.Category_Name;
                result.Category_Parent = category.Category_Parent;
                result.Parent_Id = category.Parent_Id;
                result.topParentMapper = result.topParentMapper.Replace((char)result.Parent_Id,(char)category.Parent_Id);
                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
