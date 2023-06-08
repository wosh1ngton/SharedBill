using AutoMapper;
using VaquinhaWebAPI.DTOs;
using VaquinhaWebAPI.Models;

namespace VaquinhaWebAPI.Mappers 
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Pagante, PaganteDTO>().ReverseMap();
            CreateMap<DespesaDTO, Pagamento>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.PagamentoId)
                )
                .ForMember(
                    dest => dest.PercentualPago,
                    opt => opt.MapFrom(src => src.PercentualPago)
                )
                .ForMember(
                    dest => dest.ItemDespesaId,
                    opt => opt.MapFrom(src => src.ItemDespesaId)
                )
                .ForMember(
                    dest => dest.PaganteId,
                    opt => opt.MapFrom(src => src.PaganteId)
                );
            
            CreateMap<DespesaDTO, ItemDespesa>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.ItemDespesaId)
                )
                .ForMember(
                    dest => dest.DtItemDespesa,
                    opt => opt.MapFrom(src => src.DtItemDespesa)
                )
                .ForMember(
                    dest => dest.DescricaoItemDespesa,
                    opt => opt.MapFrom(src => src.DescricaoItemDespesa)
                )
                .ForMember(
                    dest => dest.ValorItemDespesa,
                    opt => opt.MapFrom(src => src.ValorItemDespesa)
                )
                .ForMember(
                    dest => dest.TipoItemDespesaId,
                    opt => opt.MapFrom(src => src.TipoItemDespesaId)
                )
                .ForMember(
                    dest => dest.CategoriaItemDespesaId,
                    opt => opt.MapFrom(src => src.CategoriaItemDespesaId)
                );
        }
    }
}