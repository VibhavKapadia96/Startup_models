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
    public class LinkTypesController : ControllerBase
    {

        private readonly ILinkTypes linkTypes;

        public LinkTypesController(ILinkTypes linkTypes)
        {
            this.linkTypes = linkTypes;
        }

        [HttpGet]
        public async Task<ActionResult> GetLinkTypes()
        {
            try
            {
                return Ok(await linkTypes.GetLinkTypes());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetLinkType(int id)
        {

            try
            {

                var result = await linkTypes.GetLinkType(id);

                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }


        }

        [HttpGet("{name}")]
        public async Task<ActionResult> GetLinkTypebyName(string name)
        {
            try
            {
                var result = await linkTypes.GetLinkTypebyName(name);

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
        public async Task<ActionResult> CreatelinkType(LinkType linkType)
        {

            try
            {
                if (linkType == null)
                    return BadRequest();


                var result = await linkTypes.GetLinkTypebyName(linkType.Linktype_Name);
                if (result != null)

                {
                    ModelState.AddModelError("Linktype_Name", "Linktype Name Already Created");
                    return BadRequest(ModelState);
                }


                var createdlinkType = await linkTypes.AddLinkType(linkType);

                return CreatedAtAction(nameof(GetLinkTypes), new { id = createdlinkType.Id }, createdlinkType);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<LinkType>> UpdateSource(int id, LinkType linkType)
        {
            try
            {
                if (id != linkType.Id)
                    return BadRequest("Source ID mismatch");

                var linkTypeToUpdate = await linkTypes.GetLinkType(id);

                if (linkTypeToUpdate == null)
                    return NotFound($"LinkType with Id = {id} not found");

                return await linkTypes.UpdateLinkType(linkType);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<LinkType>> DeleteSource(int id)
        {
            try
            {
                var linkTypeToDelete = await linkTypes.GetLinkType(id);

                if (linkTypeToDelete == null)
                {
                    return NotFound($"Link Type with Id = {id} not found");
                }

                return await linkTypes.DeleteLinkType(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

    }
}
