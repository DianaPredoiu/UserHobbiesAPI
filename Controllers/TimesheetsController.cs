using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dtos;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]//MAIN ROUTE
    public class TimesheetsController : ControllerBase
    {
        //ATTRIBUTES
        private ITimesheetService _timesheetService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        //CONSTRUCTOR
        public TimesheetsController(
            ITimesheetService timesheetService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _timesheetService = timesheetService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        //GET USER BY ID
        [HttpGet("{id}/{date}")]//ROUTE
        public IActionResult GetById(int id ,DateTime date)
        {
            var timesheet = _timesheetService.GetTimesheetById(id,date);
            var timesheetDto = _mapper.Map<IList<TimesheetDto>>(timesheet);
            return Ok(timesheetDto);
        }

        [AllowAnonymous]
        //GETALL USERS
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _timesheetService.GetAll();
            var userDtos = _mapper.Map<IList<TimesheetDto>>(users);
            return Ok(userDtos);
        }

        [AllowAnonymous]
        //GETALL USERS
        [HttpPost("create")]
        public IActionResult Create([FromBody]TimesheetDto timesheetDto)
        {
            // map dto to entity
            var timesheet = _mapper.Map<Timesheet>(timesheetDto);

            try
            {
                // save 
                _timesheetService.Create(timesheet);
                return Ok(timesheet);
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
