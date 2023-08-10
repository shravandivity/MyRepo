using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI_Service.DTOs;
using SchoolAPI_Service.IRepository;
using SchoolAPI_Service.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolAPI_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        protected APIResponse _apiResponse;
        public StudentController(IStudentRepository studentRepository,IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            this._apiResponse = new();
        }
        // GET: api/values
        [HttpGet]
        [Authorize(Roles = "Reader")]
        public async Task<ActionResult<APIResponse>> GetAllAsync()
        {
            try
            {
                var studentDomainModel = await _studentRepository.GetAllAsync();
                var studentDto = _mapper.Map<List<StudentDto>>(studentDomainModel);
                _apiResponse.Result = studentDto;
                _apiResponse.StatusCode = System.Net.HttpStatusCode.OK;
                return Ok(_apiResponse);
            }
            catch(Exception ex)
            {
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _apiResponse;
        }

        // GET api/values/5
        [HttpGet("{id:Guid}")]
        [Authorize(Roles = "Reader")]
        public async Task<ActionResult<APIResponse>> GetAsync(Guid id)
        {
            try
            {
                var studentDomainModel = await _studentRepository.GetAsync(s => s.StudentId == id);
                var studentDto = _mapper.Map<StudentDto>(studentDomainModel);
                _apiResponse.Result = studentDto;
                _apiResponse.StatusCode = System.Net.HttpStatusCode.OK;
                return Ok(_apiResponse);
            }
            catch(Exception ex)
            {
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _apiResponse;
        }

        // POST api/values
        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<ActionResult<APIResponse>> Post([FromBody]StudentDto student)
        {
            try
            {
                var studentDomainModel = _mapper.Map<Student>(student);
                await _studentRepository.CreateAsync(studentDomainModel);
                _apiResponse.Result = _mapper.Map<StudentDto>(studentDomainModel);
                _apiResponse.StatusCode = System.Net.HttpStatusCode.OK;
                return Ok(_apiResponse);
            }
            catch(Exception ex)
            {
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _apiResponse;
        }

        // PUT api/values/5
        [HttpPut]
        [Authorize(Roles = "Writer")]
        public async Task<ActionResult<APIResponse>> Put([FromBody]StudentDto studentDto)
        {
            try
            {
                var studentDomainModel = await _studentRepository.GetAsync(s => s.StudentId == studentDto.StudentId);
                if(studentDomainModel == null)
                {
                    _apiResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
                    _apiResponse.IsSuccess = false;
                    _apiResponse.ErrorMessages = new List<string>() { "Student not found" };
                    return NotFound(_apiResponse);
                }
                studentDomainModel.FirstName = studentDto.FirstName;
                studentDomainModel.LastName = studentDto.LastName;
                studentDomainModel.RollNo = studentDto.RollNo;
                studentDomainModel.Grade = studentDto.Grade;
                studentDomainModel.Correspondence.AddressLine1 = studentDto.Correspondence.AddressLine1;
                studentDomainModel.Correspondence.AddressLine2 = studentDto.Correspondence.AddressLine2;
                studentDomainModel.Correspondence.AddressLine3 = studentDto.Correspondence.AddressLine3;
                studentDomainModel.Correspondence.City = studentDto.Correspondence.City;
                studentDomainModel.Correspondence.State = studentDto.Correspondence.State;
                studentDomainModel.Correspondence.PostalCode = studentDto.Correspondence.PostalCode;
                studentDomainModel.Correspondence.ContactNo = studentDto.Correspondence.ContactNo;

                await _studentRepository.UpdateAsync(studentDomainModel);
                _apiResponse.Result = studentDomainModel;
                _apiResponse.StatusCode = System.Net.HttpStatusCode.OK;
                return Ok(_apiResponse);
            }
            catch(Exception ex)
            {
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _apiResponse;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

