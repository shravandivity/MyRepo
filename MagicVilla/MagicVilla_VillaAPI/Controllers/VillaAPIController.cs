using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MagicVilla_VillaAPI.Controllers
{
    [ApiController]
    [Route("api/VillaAPI")]
    public class VillaAPIController : ControllerBase
    {
        // GET: api/values
        [HttpGet("GetVillas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDto>> GetVillas()
        {
            return Ok(VillaStore.villaList); 
        }

        // GET: api/values
        [HttpGet("GetVilla/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDto> GetVilla(int Id)
        {
            if (Id == 0)
                return BadRequest();
            var villa = VillaStore.villaList.Where(a => a.Id == Id).FirstOrDefault();
            if (villa == null)
                return NotFound();
            return Ok(villa);
        }

        [HttpPost("CreateVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDto> CreateVilla([FromBody]VillaDto villaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if (VillaStore.villaList.FirstOrDefault(a => a.Name.ToLower() == villaDto.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CustomError", "Villa already exists");
                return BadRequest(ModelState);
            }
                
            if (villaDto == null)
                return BadRequest();
            if (villaDto.Id > 0)
                return StatusCode(StatusCodes.Status500InternalServerError);
            villaDto.Id = VillaStore.villaList.OrderByDescending(a => a.Id).FirstOrDefault().Id + 1;
            VillaStore.villaList.Add(villaDto);
            return Ok(villaDto);
        }

        [HttpDelete("DeleteVilla/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteVilla(int Id)
        {
            var villa = VillaStore.villaList.FirstOrDefault(a => a.Id == Id);
            if (villa == null)
                return NotFound();
            VillaStore.villaList.Remove(villa);
            return NoContent();

        }

        [HttpPut("UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult UpdateVilla([FromBody]VillaDto villaDto)
        {
            var villa = VillaStore.villaList.FirstOrDefault(a => a.Id == villaDto.Id);
            if (villa == null)
                return NotFound();
            villa.Name = villaDto.Name;
            villa.Sqft = villaDto.Sqft;
            villa.Occupancy = villaDto.Occupancy;
            return Ok(villa);

        }
    }
}

