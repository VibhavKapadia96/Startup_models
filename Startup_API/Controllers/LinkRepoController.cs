using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Startup_API.Models;
using Startup_models;
using System;
using System.Threading.Tasks;

namespace Startup_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkRepoController : ControllerBase
    {

        private readonly ILinkRepo linkRepo;
        private readonly ILinkTypes linkType;
        private readonly ICategories categories;
        private readonly ISources sources;

        public LinkRepoController(ILinkRepo linkRepo,ILinkTypes linkType, ISources sources, ICategories categories)
        {
            this.linkRepo = linkRepo;
            this.linkType = linkType;
            this.sources = sources;
            this.categories = categories;
        }

        [HttpGet]
        public async Task<ActionResult> GetLinks()
        {
            try
            {
                return Ok(await linkRepo.GetLinks());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetLink(int id)
        {

            try
            {

                var result = await linkRepo.GetLink(id);

                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }


        }

        [HttpGet("{name}")]
        public async Task<ActionResult> GetLinkbyName(string name)
        {
            try
            {
                var result = await linkRepo.GetLinkbyName(name);

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
        public async Task<ActionResult> AddLink(linkRepository linkRepodata)
        {

            try
            {
                if (linkRepodata == null)
                    return BadRequest();


                var result = await linkRepo.GetLinkbyName(linkRepodata.link);
                if (result != null)
                {
                    ModelState.AddModelError("Source_Name", "Source Name Already Created");
                    return BadRequest(ModelState);
                }

                var isPresentLinkType = await linkType.GetLinkType(linkRepodata.linkTypeId);

                if (isPresentLinkType == null) {
                    ModelState.AddModelError("Link Type", "Link Type not found");
                    return BadRequest(ModelState);
                }

                var isPresentCategory = await categories.GetCategory(linkRepodata.categoryId);

                if (isPresentCategory == null) {
                    ModelState.AddModelError("Category", "Category not found");
                    return BadRequest(ModelState);
                }

                var isPresentSource = await sources.GetSource(linkRepodata.sourcesId);

                if (isPresentSource == null) {
                    ModelState.AddModelError("Source", "Source not found");
                    return BadRequest(ModelState);
                }

                var createdSource = await linkRepo.AddLink(linkRepodata);

                return CreatedAtAction(nameof(GetLink), new { id = createdSource.Id }, createdSource);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new Link record");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<linkRepository>> UpdateLink(int id, linkRepository linkRepodata)
        {
            try
            {
                if (id != linkRepodata.Id)
                    return BadRequest("Source ID mismatch");

                var sourceToUpdate = await linkRepo.GetLink(id);

                if (sourceToUpdate == null)
                    return NotFound($"Source with Id = {id} not found");

                var isPresentLinkType = await linkType.GetLinkType(linkRepodata.linkTypeId);

                if (isPresentLinkType == null)
                {
                    ModelState.AddModelError("Link Type", "Link Type not found");
                    return BadRequest(ModelState);
                }

                var isPresentCategory = await categories.GetCategory(linkRepodata.categoryId);

                if (isPresentCategory == null)
                {
                    ModelState.AddModelError("Category", "Category not found");
                    return BadRequest(ModelState);
                }

                var isPresentSource = await sources.GetSource(linkRepodata.sourcesId);

                if (isPresentSource == null)
                {
                    ModelState.AddModelError("Source", "Source not found");
                    return BadRequest(ModelState);
                }


                return await linkRepo.UpdateLink(linkRepodata);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<linkRepository>> DeleteLink(int id)
        {
            try
            {
                var sourceToDelete = await linkRepo.GetLink(id);

                if (sourceToDelete == null)
                {
                    return NotFound($"Source with Id = {id} not found");
                }

                return await linkRepo.DeleteLink(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

    }
}