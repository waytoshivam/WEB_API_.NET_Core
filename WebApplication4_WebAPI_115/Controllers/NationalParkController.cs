using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication4_WebAPI_115.Models.DTOs;
using WebApplication4_WebAPI_115.Models;
using WebApplication4_WebAPI_115.Repository.IRepository;

namespace WebApplication4_WebAPI_115.Controllers
{
    [Route("api/NationalPark")]
    [ApiController]
    public class NationalParkController : ControllerBase
    {
        private readonly INationalParkRepository _nationalParkRepository;
        private readonly IMapper _mapper;
        public NationalParkController(INationalParkRepository nationalParkRepository, IMapper mapper)
        {
            _nationalParkRepository = nationalParkRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetNationalParks()
        {
            var nationalParkListDto = _nationalParkRepository.GetNationalParks().ToList().Select(_mapper.Map<NationalPark, NationalParkDto>);
            return Ok(nationalParkListDto);//200
        }
        [HttpGet("{nationalParkId:int}")]
        public IActionResult GetNationalPark(int nationalParkId)
        {
            var nationalPark = _nationalParkRepository.GetNationalPark(nationalParkId);
            if (nationalPark == null) return NotFound();//404
            var nationalParkDto = _mapper.Map<NationalParkDto>(nationalPark);
            return Ok(nationalParkDto);//200
        }

        [HttpPost]
        public IActionResult CreateNationalPark([FromBody] NationalParkDto nationalParkDto)
        {
            if (nationalParkDto == null) return BadRequest(ModelState);
            if (_nationalParkRepository.NationalParkExists(nationalParkDto.Name))
            {
                ModelState.AddModelError("", "National Park In DB");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            if(!ModelState.IsValid) return BadRequest(ModelState); //400
            var nationalPark = _mapper.Map<NationalParkDto, NationalPark>(nationalParkDto);

            if (!_nationalParkRepository.CreateNationalPark(nationalPark))
            {
                ModelState.AddModelError("", $"Semthing Went Wrong while saving data :{nationalPark.Name}" );
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok();
            //return CreatedAtRoute("GetNationalPark", new { nationalParkId = nationalPark.Id }, nationalPark);
        }
        [HttpPut]
        public IActionResult UpdateNationalPark([FromBody] NationalParkDto nationalParkDto)
        {
            if (nationalParkDto == null) return BadRequest(ModelState);
            if (!ModelState.IsValid) return BadRequest();
            var nationalPark = _mapper.Map<NationalPark>(nationalParkDto);
            if (!_nationalParkRepository.UpdateNationalPark(nationalPark))
            {
                ModelState.AddModelError("", $"Something went wrong while update data :{nationalPark.Name}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return NoContent();//204
        }
        [HttpDelete]
        public IActionResult DeleteNationalPark(int nationalParkId)
        {
            if (!_nationalParkRepository.NationalParkExists(nationalParkId))
                return NotFound();
            var nationalPark = _nationalParkRepository.GetNationalPark(nationalParkId);
            if (nationalPark == null) return NotFound();
            if (!_nationalParkRepository.DeleteNationalPark(nationalPark))
            {
                ModelState.AddModelError("", $"Something Went Wrong While Delete Data:{nationalPark.Id}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok();
        }

    }

    
}
