using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VaquinhaWebAPI.DTOs;
using VaquinhaWebAPI.Models;
using VaquinhaWebAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using SharedBillWebApi.DTOs;
using Newtonsoft.Json;

namespace VaquinhaWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DespesasController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TipoItemDespesa> _repository;
        private readonly IRepository<CategoriaItemDespesa> _categoriaItemDespesa;
        private readonly IDespesaRepository _despesaRepository;
        public DespesasController(
            IMapper mapper,
            IRepository<TipoItemDespesa> repository,
            IRepository<CategoriaItemDespesa> categoriaItemDespesa,
            IDespesaRepository despesaRepository
            )
        {
            _mapper = mapper;
            _repository = repository;
            _categoriaItemDespesa = categoriaItemDespesa;
            _despesaRepository = despesaRepository;
        }

        [HttpGet("{ano:int?}")]
        [Authorize]
        public IActionResult Get(int? ano)
        { 
            var despesas = _despesaRepository.ListarDespesasPorMes(ano);
            var listaDespesas = new List<DespesasPorMesViewModel>();
            
            foreach (var mes in despesas)
            {
                var despVM = new DespesasPorMesViewModel();
                despVM.Mes = mes.Mes;
                //var lista = new List<DespesaViewModel>();
                foreach(var item in mes.Despesas) 
                {
                    var desp = new DespesaViewModel();
                    desp.PagamentoId = item.Id;
                    desp.DtItemDespesa = item.ItemDespesa.DtItemDespesa;
                    desp.DescricaoItemDespesa = item.ItemDespesa.DescricaoItemDespesa;
                    desp.PaganteId = item.PaganteId;
                    desp.ItemDespesaId = item.ItemDespesaId;
                    desp.ValorItemDespesa = item.ItemDespesa.ValorItemDespesa;
                    desp.NomePagante = item.Pagante.NomePagante;
                    desp.PercentualPago = item.PercentualPago;
                    desp.NomeTipoItemDespesa = item.ItemDespesa.TipoItemDespesa.NomeTipoItemDespesa;
                    desp.NomeCategoriaItemDespesa = item.ItemDespesa.CategoriaItemDespesa.NomeCategoriaItemDespesa;                                        
                    despVM.Despesas.Add(desp);  
                }
                
                listaDespesas.Add(despVM);
                
            }
            var jsonResponse = JsonConvert.SerializeObject(listaDespesas);
            return Ok(jsonResponse);
        }

        [HttpGet("totais/{ano:int?}/{mes:int?}")]
        public IActionResult GetTotais(int? ano, int? mes)
        {
            var totais = _despesaRepository.GetTotais(ano, mes);
            return Ok(totais);
        }
        [HttpGet("totalReceber/{ano:int?}")]
        public IActionResult GetTotalAReceber(int? ano)
        {
            var totais = _despesaRepository.GetTotalReceber(ano);
            return Ok(totais);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var despesa = _despesaRepository.GetDespesaById(id);

            var desp = new DespesaDTO();
            desp.PagamentoId = despesa.Id;
            desp.DtItemDespesa = despesa.ItemDespesa.DtItemDespesa;
            desp.DescricaoItemDespesa = despesa.ItemDespesa.DescricaoItemDespesa;
            desp.ValorItemDespesa = despesa.ItemDespesa.ValorItemDespesa;
            desp.PaganteId = despesa.PaganteId;
            desp.PercentualPago = despesa.PercentualPago;
            desp.TipoItemDespesaId = despesa.ItemDespesa.TipoItemDespesaId;
            desp.CategoriaItemDespesaId = despesa.ItemDespesa.CategoriaItemDespesaId;
            var jsonResult = JsonConvert.SerializeObject(desp);
            return Ok(jsonResult);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, [FromBody] DespesaDTO model)
        {
            var despesa = _despesaRepository.GetDespesaById(id);

            if (despesa == null) return BadRequest("Despesa não encontrada");

            model.ItemDespesaId = despesa.ItemDespesaId;
            var itemDespesa = _mapper.Map<ItemDespesa>(model);
            var pgto = _mapper.Map<Pagamento>(model);
            _despesaRepository.UpdateDespesa(itemDespesa, pgto);

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

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _despesaRepository.ExcluirDespesa(id);
            return Ok("Despesa excluída");
        }

        [HttpGet("MesesComDespesaPorAno/{ano}")]
        public IActionResult GetMesesByAno(int ano)
        {
            var meses = _despesaRepository.GetMesesComDespesa(ano);
            return Ok(meses);
        }

        [HttpGet("AnosComDespesas")]
        [Authorize]
        public IActionResult GetAnos()
        {
            var anos = _despesaRepository.GetAnosComDespesas();
            return Ok(anos);
        }


    }
}