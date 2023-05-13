using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Logger;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MagicVilla_VillaAPI.Controllers
{
    [ApiController]
    [Route("api/VillaAPI")]
    public class VillaAPIController : ControllerBase
    {
       
        private readonly IMapper _mapper;
        private readonly IVillaRepository _dbVilla;
        protected APIResponse _response;
        public VillaAPIController(ApplicationDbContext dbCtx,IMapper mapper, IVillaRepository dbVilla)
        {
            _mapper = mapper;
            _dbVilla = dbVilla;
            this._response = new();
        }

        // GET: api/values
        [HttpGet("GetVillas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetVillas()
        {
            try
            {
                List<Villa> villa = await _dbVilla.GetAllAsync();
                _response.Result = _mapper.Map<List<VillaDto>>(villa);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET: api/values
        [HttpGet("GetVilla/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetVilla(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    //_logger.Log($"Get villa error with id {Id}","error");
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                //var villa = VillaStore.villaList.Where(a => a.Id == Id).FirstOrDefault();
                var villa = await _dbVilla.GetAsync(a => a.Id == Id);
                if (villa == null)
                {
                    //_logger.Log($"No villa found with id {Id}","error");
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string>() { "Villa not found" };
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<VillaDto>(villa);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;

        }

        [HttpPost("CreateVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> CreateVilla([FromBody]VillaCreateDto villaDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string>() { "Model not valid" };
                    return BadRequest(_response);
                }
                    

                if (await _dbVilla.GetAsync(a => a.Name.ToLower() == villaDto.Name.ToLower()) != null)
                {
                    ModelState.AddModelError("CustomError", "Villa already exists");
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string>() { "Villa already exists" };
                    return BadRequest(ModelState);
                }

                if (villaDto == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }
                    

                var villa = _mapper.Map<Villa>(villaDto);

                //var villa = new Villa()
                //{
                //    Name = villaDto.Name,
                //    Details=villaDto.Details,
                //    Rate=villaDto.Rate,
                //    Sqft=villaDto.Sqft,
                //    Occupancy=villaDto.Occupancy,
                //    ImageUrl=villaDto.ImageUrl,
                //    Amenity=villaDto.Amenity,
                //    CreatedDate=DateTime.Now,
                //    UpdatedDate=DateTime.Now
                //};
                await _dbVilla.CreateAsync(villa);
                _response.Result = _mapper.Map<VillaDto>(villa);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;

        }

        [HttpDelete("DeleteVilla/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteVilla(int Id)
        {
            try
            {
                var villa = await _dbVilla.GetAsync(a => a.Id == Id);
                if (villa == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string>() { "Villa not found" };
                    return NotFound(_response);
                }
                await _dbVilla.RemoveAsync(villa);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;

        }

        [HttpPut("UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateVilla([FromBody]VillaUpdateDto villaDto)
        {
            try
            {
                var villa = await _dbVilla.GetAsync(a => a.Id == villaDto.Id);
                if (villa == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string>() { "Villa not found" };
                    return NotFound(_response);
                }

                //villa = _mapper.Map<Villa>(villaDto);

                villa.Name = villaDto.Name;
                villa.Details = villaDto.Details;
                villa.Rate = villaDto.Rate;
                villa.Sqft = villaDto.Sqft;
                villa.Occupancy = villaDto.Occupancy;
                villa.ImageUrl = villaDto.ImageUrl;
                villa.Amenity = villaDto.Amenity;
                villa.UpdatedDate = DateTime.Now;

                await _dbVilla.UpdateAsync(villa);

                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = villa;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;

        }

        [HttpPatch("UpdateVilla/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdatePartialVilla(int Id, JsonPatchDocument<Villa> patchDto)
        {
            try
            {
                if (patchDto == null || Id == 0)
                    return BadRequest();
                var villa = await _dbVilla.GetAsync(a => a.Id == Id);
                if (villa == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }
                patchDto.ApplyTo(villa, ModelState);
                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                await _dbVilla.UpdateAsync(villa);

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;

        }
    }
}

