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
    public class SourcesController : ControllerBase
    {

        private readonly ISources sources;
        private readonly ILinkRepository linkRepo;
        public SourcesController(ISources sources, ILinkRepository linkRepo)
        {
            this.sources = sources;
            this.linkRepo = linkRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetSources()
        {
            try
            {
                return Ok(await sources.GetSources());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetSource(int id)
        {

            try
            {

                var result = await sources.GetSource(id);

                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }


        }

        [HttpGet("{name}")]
        public async Task<ActionResult> GetSourcebyName(string name)
        {
            try
            {
                var result = await sources.GetSourcebyName(name);

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
        public async Task<ActionResult> CreateSource(Sources source)
        {

            try
            {
                if (source == null)
                    return BadRequest();


                var result = await sources.GetSourcebyName(source.Source_Name);
                if (result != null)

                {
                    ModelState.AddModelError("Source_Name", "Source Name Already Created");
                    return BadRequest(ModelState);
                }


                var createdSource = await sources.AddSource(source);

                return CreatedAtAction(nameof(GetSources), new { id = createdSource.Id }, createdSource);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Sources>> UpdateSource(int id, Sources source)
        {
            try
            {
                if (id != source.Id)
                    return BadRequest("Source ID mismatch");

                var sourceToUpdate = await sources.GetSource(id);

                if (sourceToUpdate == null)
                    return NotFound($"Source with Id = {id} not found");

                return await sources.UpdateSource(source);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Sources>> DeleteSource(int id)
        {
            try
            {
                var sourceToDelete = await sources.GetSource(id);

                if (sourceToDelete == null)
                {
                    return NotFound($"Source with Id = {id} not found");
                }

                var isDatainLinkRepo = await linkRepo.GetLinkbyName(id.ToString());

                if (isDatainLinkRepo != null)
                {
                    return BadRequest($"Source linked to data Links");
                }

                return await sources.DeleteSource(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

    }
}