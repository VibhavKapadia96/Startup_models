using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Startup_API.Models;
using Startup_models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Startup_API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategories categories;

        public CategoriesController(ICategories categories)
        {
            this.categories = categories;
        }

        [HttpGet]
        public async Task<ActionResult> GetCategories()
        {

            try
            {
                return Ok(await categories.GetCategories());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }


        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Categories>> GetCategory(int id)
        {

            try
            {

                var result = await categories.GetCategory(id);

                if (result == null) return NotFound();

                return result;

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }


        }

        [HttpGet("{name}")]
        public async Task<ActionResult> GetSubCategorybyName(string name)
        {
            try
            {
                var result = await categories.GetSubCategorybyName(name);

                if (result != null)
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        [HttpPost]
        public async Task<ActionResult<Categories>> CreateCategory(Categories category)
        {


            try
            {
                if (category == null)
                    return BadRequest();


                var result = await categories.GetCategorybyName(category.Category_Name, category.Category_Parent);
                if (result != null)

                {
                    ModelState.AddModelError("Category_Name", "Category Name Already Created");
                    return BadRequest(ModelState);
                }


                var createdCategory = await categories.AddCategory(category);

                return CreatedAtAction(nameof(GetCategory),
                    new { id = createdCategory.Id }, createdCategory);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Categories>> UpdateCategory(int id, Categories category)
        {
            try
            {
                if (id != category.Id)
                    return BadRequest("Category ID mismatch");

                var cateogryToUpdate = await categories.GetCategory(id);

                if (cateogryToUpdate == null)
                    return NotFound($"Cateogory with Id = {id} not found");

                return await categories.UpdateCategory(category);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Categories>> DeleteEmployee(int id)
        {
            try
            {
                var categoryToDelete = await categories.GetCategory(id);

                if (categoryToDelete == null)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }

                return await categories.DeleteCategory(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }


        //[HttpGet("{search}")]
        //public async Task<ActionResult<IEnumerable<Categories>>> Search(string Category_Name, string Category_parent = null)
        //{
        //    try
        //    {
        //        var result = await categories.Search(Category_Name, Category_parent);

        //        if (result.Any())
        //        {
        //            return Ok(result);
        //        }

        //        return NotFound();
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //            "Error retrieving data from the database");
        //    }
        //}

    }


}
