using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using WebApi.Dtos;
using WebApi.Helpers;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]//MAIN ROUTE
    public class UserHobbiesViewController : ControllerBase
    {
        //ATTRIBUTES
        private IQueryService _queryService;
        private IMapper _mapper;

        //CONSTRUCTOR
        public UserHobbiesViewController(
            IQueryService queryService,
            IMapper mapper)
        {
            _queryService = queryService;
            _mapper = mapper;
        }

        //GET ALL HOBBIES FOR SPECIFIED USER
        [AllowAnonymous]
        [HttpGet("listhobbies/{id}")]//ROUTE
        public IActionResult ListAllHobbies(int Id)
        {
            var _userHobbieslist = _queryService.getList(Id);         
            var userHobbiesListDto = _mapper.Map<IList<HobbyDto>>(_userHobbieslist);
            return Ok(userHobbiesListDto);
        }

    }//CLASS UserHobbiesView

}//NAMESPACE WebApi.Controllers
                                      
     