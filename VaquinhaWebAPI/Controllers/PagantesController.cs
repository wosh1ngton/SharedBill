using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VaquinhaWebAPI.DTOs;
using VaquinhaWebAPI.Models;
using VaquinhaWebAPI.Repositories.Interfaces;

namespace VaquinhaWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagantesController : ControllerBase
    {
        private readonly IRepository<Pagante> _repository;
        private readonly IMapper _mapper;
        public PagantesController(IRepository<Pagante> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var pagantes = _repository.GetAll();
            return Ok(pagantes);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var pagante = _repository.GetById(id);
            if (pagante == null) return BadRequest("Registro não localizado");
            return Ok(pagante);
        }

        [HttpPost]
        public IActionResult Post(Pagante model)
        {
            _repository.Add(model);

            if (model != null)
            {
                return Created($"/api/pagantes/{model.Id}", model);
            }
            return BadRequest("Não foi possível cadastrar");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pagante = _repository.GetById(id);
            if (pagante == null) return BadRequest("Registro não encontrado");

            _repository.Delete(pagante);
            return Ok("Registro excluído");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, PaganteDTO model)
        {
            var pagante = _repository.GetById(id);
            if (pagante == null) return BadRequest("Registro não encontrado");            

            _mapper.Map(model, pagante);
            _repository.Update(pagante);
            return Created($"/api/pagantes/{model.Id}", model);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, PaganteDTO model)
        {
            var pagante = _repository.GetById(id);
            if (pagante == null) return BadRequest("Registro não encontrado");            
            
            _mapper.Map(model, pagante);
            _repository.Update(pagante);
            return Created($"/api/pagantes/{model.Id}", model);
        }

    }
}