using HotelManagementAbstractions.Repository;
using HotelManagementDataLibrary.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelManagementApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestsController : ControllerBase
    {

        private readonly IGuestRepository _guestRepository;

        public GuestsController(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        // GET: api/<GuestsController>
        [HttpGet]
        public async Task<IEnumerable<Guest>> Get()
        {
            return await _guestRepository.GetAll();
        }

        // GET api/<GuestsController>/5
        [HttpGet("{id}")]
        public async Task<Guest> Get(Guid id)
        {
            return await _guestRepository.GetGusetById(id);
        }

        // POST api/<GuestsController>
        [HttpPost]
        public async Task Post([FromBody] Guest guest)
        {
            await _guestRepository.SaveGuest(guest);

        }

        // PUT api/<GuestsController>/5
        [HttpPut("{id}")]
        public async Task Put(Guid id, [FromBody] Guest guest)
        {
            await _guestRepository.UpdateGuest(id, guest);
        }

    }
}
