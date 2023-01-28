using HotelManagementAbstractions.Repository;
using HotelManagementDataLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementApplication.Controllers;

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
    public async Task<IActionResult> Get()
    {
        return Ok(await _guestRepository.GetAll());
    }

    // GET api/<GuestsController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(await _guestRepository.GetGusetById(id));
    }

    // POST api/<GuestsController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Guest guest)
    {
        await _guestRepository.SaveGuest(guest);
        return new CreatedAtActionResult(nameof(GetById), "Guests", new { id = guest.Id }, guest);

    }

    // PUT api/<GuestsController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] Guest guest)
    {
        await _guestRepository.UpdateGuest(id, guest);
        return NoContent();
        
    }

}
