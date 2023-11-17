using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("[controller]")]
public class EventoController : ControllerBase
{

    public IEnumerable<Evento> _eventos = new Evento[]{
        new Evento(){
            EventoId = 1,
            Tema = "Angular 11 e .NET 5",
            Local = "Belo Horizonte",
            Lote = "1º Lote",
            QuantidadeDePessoas = 250,
            DataDoEvento = DateTime.Now.AddDays(2).ToString(),
            ImagemUrl = "http://www.deltas.com/deltas/event.png"
        },
        new Evento(){
            EventoId = 2,
            Tema = "Vue.Js e .NET 5",
            Local = "Belo Horizonte",
            Lote = "2º Lote",
            QuantidadeDePessoas = 250,
            DataDoEvento = DateTime.Now.AddDays(2).ToString(),
            ImagemUrl = "http://www.deltas.com/deltas/event.png"
        }
    };
    private readonly ILogger<EventoController> _logger;

    public EventoController(ILogger<EventoController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Evento> Get()
    {
        return _eventos;
    }
    [HttpGet("{id}")]
    public IEnumerable<Evento> GetById(int id)
    {
        return _eventos.Where(evento => evento.EventoId == id);
    }
    [HttpPost]
    public IEnumerable<Evento> Post()
    {
        return _eventos;
    }

    [HttpPut("{id}")]
    public IEnumerable<Evento> Put(int id)
    {
        return _eventos;
    }

    [HttpDelete("{id}")]
    public IEnumerable<Evento> Delete(int id)
    {
        return _eventos;
    }

}
