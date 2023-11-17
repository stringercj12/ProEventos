using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProEventos.API.DataContext;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{

    private readonly AppDbContext _context;
    private readonly ILogger<EventoController> _logger;

    public EventoController(ILogger<EventoController> logger,AppDbContext context)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Evento> Get()
    {
        return _context.Eventos;
    }

    [HttpGet("{id}")]
    public Evento GetById(int id)
    {
        return _context.Eventos.FirstOrDefault(evento => evento.EventoId == id);
    }

    // [HttpPost]
    // public IEnumerable<Evento> Post()
    // {
    //     return _eventos;
    // }

    // [HttpPut("{id}")]
    // public IEnumerable<Evento> Put(int id)
    // {
    //     return _eventos;
    // }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var evento = _context.Eventos.Where(evento => evento.EventoId == id);

        if (evento == null)
        {
            return BadRequest();
        }

        _context.Remove(evento);
        _context.SaveChanges();

        return Ok("Deletado com sucesso!");

    }

}
