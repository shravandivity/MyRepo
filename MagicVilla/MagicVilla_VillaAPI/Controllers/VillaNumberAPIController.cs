using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MagicVilla_VillaAPI.Controllers
{
    [Route("api/[controller]")]
    public class VillaNumberAPIController : ControllerBase
    {
        private readonly IVillaNumberRepository _dbVillaNumber;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public VillaNumberAPIController(IVillaNumberRepository dbVillaNumber, IMapper mapper)
        {
            _dbVillaNumber = dbVillaNumber;
            _mapper = mapper;
            this._response = new();
        }

        // GET: api/values
        [HttpGet("GetAllVillaNumbers")]
        public async Task<ActionResult<APIResponse>> GetAllVillaNumbers()
        {
            try
            {
                List<VillaNumber> villaNumbers = await _dbVillaNumber.GetAllAsync();
                _response.Result = _mapper.Map<List<VillaNumberDto>>(villaNumbers);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.Message };

            }
            return _response;
        }

        // GET: api/values
        [HttpGet("GetVillaByNumber/{VillaNo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetVillaByNumber(int VillaNo)
        {
            try
            {
                if (VillaNo == 0)
                {
                    //_logger.Log($"Get villa error with id {Id}","error");
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                //var villa = VillaStore.villaList.Where(a => a.Id == Id).FirstOrDefault();
                var villa = await _dbVillaNumber.GetAsync(a => a.VillaNo == VillaNo);
                if (villa == null)
                {
                    //_logger.Log($"No villa found with id {Id}","error");
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string>() { "Villa not found" };
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<VillaNumberDto>(villa);
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

        [HttpPost("CreateVillaNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> CreateVillaNumber([FromBody] VillaNumberCreateDto villaDto)
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


                if (await _dbVillaNumber.GetAsync(a => a.VillaNo == villaDto.VillaNo) != null)
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


                var villa = _mapper.Map<VillaNumber>(villaDto);

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
                await _dbVillaNumber.CreateAsync(villa);
                _response.Result = _mapper.Map<VillaNumberCreateDto>(villa);
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
    }
}

