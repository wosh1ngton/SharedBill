using Microsoft.AspNetCore.Mvc;
using VaquinhaWebAPI.DTOs;
using VaquinhaWebAPI.Models;
using VaquinhaWebAPI.Repositories;
using VaquinhaWebAPI.Repositories.Interfaces;

namespace VaquinhaWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DespesasController : ControllerBase
    {
        private readonly IRepository<TipoItemDespesa> _repository;
        private readonly IRepository<CategoriaItemDespesa> _categoriaItemDespesa;
        private readonly IDespesaRepository _despesaRepository;
        public DespesasController(
            IRepository<TipoItemDespesa> repository,
            IRepository<CategoriaItemDespesa> categoriaItemDespesa,
            IDespesaRepository despesaRepository
            )
        {
            _repository = repository;
            _categoriaItemDespesa = categoriaItemDespesa;
            _despesaRepository = despesaRepository;
        }

        [HttpGet]
        public IActionResult Get() 
        {

            var despesas = _despesaRepository.ListarDespesas();
            var listaDespesas = new List<DespesaViewModel>();
            foreach (var item in despesas)
            {
                 var desp = new DespesaViewModel();
                 desp.DtItemDespesa = item.ItemDespesa.DtItemDespesa;
                 desp.DescricaoItemDespesa = item.ItemDespesa.DescricaoItemDespesa;
                 desp.ValorItemDespesa = item.ItemDespesa.ValorItemDespesa;
                 desp.Nome = item.Pagante.NomePagante;
                 desp.PercentualPago = item.PercentualPago;
                 desp.NomeTipoItemDespesa = item.ItemDespesa.TipoItemDespesa.NomeTipoItemDespesa;
                 desp.NomeCategoriaItemDespesa = item.ItemDespesa.CategoriaItemDespesa.NomeCategoriaItemDespesa;
                 listaDespesas.Add(desp);
            }
            return Ok(listaDespesas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById() 
        {

            return Ok();
        }
        
        [HttpGet("TiposDespesas")]        
        public IActionResult GetTiposDespesas()
        {
            var tiposDespesa = _repository.GetAll();
            return Ok(tiposDespesa);
        }

        [HttpGet("CategoriasDespesas")]        
        public IActionResult GetCategoriasDespesas()
        {
            var tiposDespesa = _categoriaItemDespesa.GetAll();
            return Ok(tiposDespesa);
        }

        [HttpPost]
        public IActionResult Post([FromBody] DespesaDTO despesa)
        {
            _despesaRepository.CadastrarDespesa(despesa);
            return Ok();
        }

        
    }
}