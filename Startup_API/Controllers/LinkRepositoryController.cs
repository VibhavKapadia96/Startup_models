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
    [Route("api/[controller]")]
    [ApiController]
    public class LinkRepositoryController : ControllerBase
    {

        
        private readonly ILinkRepository linkRepository;

        public LinkRepositoryController(ILinkRepository linkRepository)
        {
            this.linkRepository = linkRepository;
          
        }

        [HttpGet]
        public async Task<ActionResult> GetLinks()
        {
            try
            {
                return Ok(await linkRepository.GetLinks());
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

                var result = await linkRepository.GetLink(id);

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
                var result = await linkRepository.GetLinkbyName(name);

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
        public async Task<ActionResult> AddLink(LinkRepository linkRepodata)
        {

            try
            {
                if (linkRepodata == null)
                    return BadRequest();


                var result = await linkRepository.GetLinkbyName(linkRepodata.link);
                if (result != null)
                {
                    ModelState.AddModelError("Source_Name", "Source Name Already Created");
                    return BadRequest(ModelState);
                }

                var createdSource = await linkRepository.AddLink(linkRepodata);

                return CreatedAtAction(nameof(GetLink), new { id = createdSource.Id }, createdSource);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new Link record " + ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<LinkRepository>> UpdateLink(int id, LinkRepository linkRepodata)
        {
            try
            {
                if (id != linkRepodata.Id)
                    return BadRequest("Source ID mismatch");

                var sourceToUpdate = await linkRepository.GetLink(id);

                if (sourceToUpdate == null)
                    return NotFound($"Source with Id = {id} not found");


                return await linkRepository.UpdateLink(linkRepodata);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<LinkRepository>> DeleteLink(int id)
        {
            try
            {
                var sourceToDelete = await linkRepository.GetLink(id);

                if (sourceToDelete == null)
                {
                    return NotFound($"Source with Id = {id} not found");
                }

                return await linkRepository.DeleteLink(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

    }
}