using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleApi.Models;

namespace SimpleApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HeroeController : ControllerBase
    {
        private readonly HeroeContext _context;

        public HeroeController(HeroeContext heroeContext)
        {
            _context = heroeContext;
        }

        //Controllers Operations

        [HttpGet("GetHeroes")]

        //Getting all Heroes
        public async Task<ActionResult<List<SuperHero>>> GetHeroes()
        {
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpGet("{id}")]

        //Getting the Heroes by ID
        public async Task<ActionResult<SuperHero>> SearchByID(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
                return BadRequest("Heroe not Found.");
            return hero;
        }

        
        [HttpPost("AddHero")]

        //Adding a New Hero
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();
            return (await _context.SuperHeroes.ToListAsync());
        }

        [HttpPut("UpdateHero")]

        //Updating a Hero
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {
            var hero = await _context.SuperHeroes.FindAsync(request.ID);
            if (hero == null)
                return BadRequest("Hero not found");
            //Updating the Properties
            hero.Name = request.Name;
            hero.PowerName = request.PowerName;
            await _context.SaveChangesAsync();
            return (await _context.SuperHeroes.ToListAsync());
        }

        [HttpDelete("{id}")]

        //Deleting a Hero
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var heroId = await _context.SuperHeroes.FindAsync(id);
            if (heroId == null)
                return BadRequest("Hero not found");
            //Removing the heroe
            _context.SuperHeroes.Remove(heroId);
            await _context.SaveChangesAsync();
            return (await _context.SuperHeroes.ToListAsync());
        }
    }
}
