﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VaquinhaWebAPI.Data;

#nullable disable

namespace VaquinhaWebAPI.Migrations
{
    [DbContext(typeof(VaquinhaContext))]
    partial class VaquinhaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("VaquinhaWebAPI.Models.CategoriaItemDespesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID_CATEGORIA_ITEM_DESPESA");

                    b.Property<string>("NomeCategoriaItemDespesa")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("NM_CATEGORIA_ITEM_DESPESA");

                    b.HasKey("Id");

                    b.ToTable("CATEGORIA_ITEM_DESPESA");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NomeCategoriaItemDespesa = "Supermercado"
                        },
                        new
                        {
                            Id = 2,
                            NomeCategoriaItemDespesa = "Carne"
                        },
                        new
                        {
                            Id = 3,
                            NomeCategoriaItemDespesa = "Outros"
                        });
                });

            modelBuilder.Entity("VaquinhaWebAPI.Models.ItemDespesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID_ITEM_DESPESA");

                    b.Property<int>("CategoriaItemDespesaId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID_CATEGORIA_ITEM_DESPESA");

                    b.Property<string>("DescricaoItemDespesa")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("DS_ITEM_DESPESA");

                    b.Property<DateTime>("DtItemDespesa")
                        .HasColumnType("TEXT")
                        .HasColumnName("DT_ITEM_DESPESA");

                    b.Property<int>("TipoItemDespesaId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID_TIPO_ITEM_DESPESA");

                    b.Property<decimal>("ValorItemDespesa")
                        .HasColumnType("TEXT")
                        .HasColumnName("NR_VALOR");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaItemDespesaId");

                    b.HasIndex("TipoItemDespesaId");

                    b.ToTable("ITEM_DESPESA");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoriaItemDespesaId = 1,
                            DescricaoItemDespesa = "Pão de Açúcar",
                            DtItemDespesa = new DateTime(2023, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TipoItemDespesaId = 1,
                            ValorItemDespesa = 250m
                        },
                        new
                        {
                            Id = 2,
                            CategoriaItemDespesaId = 1,
                            DescricaoItemDespesa = "Swift",
                            DtItemDespesa = new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TipoItemDespesaId = 2,
                            ValorItemDespesa = 350m
                        },
                        new
                        {
                            Id = 3,
                            CategoriaItemDespesaId = 2,
                            DescricaoItemDespesa = "Viagem",
                            DtItemDespesa = new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TipoItemDespesaId = 1,
                            ValorItemDespesa = 50m
                        },
                        new
                        {
                            Id = 4,
                            CategoriaItemDespesaId = 1,
                            DescricaoItemDespesa = "Pão de Açúcar",
                            DtItemDespesa = new DateTime(2023, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TipoItemDespesaId = 2,
                            ValorItemDespesa = 58m
                        },
                        new
                        {
                            Id = 5,
                            CategoriaItemDespesaId = 2,
                            DescricaoItemDespesa = "HortiFrutti",
                            DtItemDespesa = new DateTime(2022, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TipoItemDespesaId = 1,
                            ValorItemDespesa = 20m
                        },
                        new
                        {
                            Id = 6,
                            CategoriaItemDespesaId = 2,
                            DescricaoItemDespesa = "Pão de Açúcar",
                            DtItemDespesa = new DateTime(2022, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TipoItemDespesaId = 2,
                            ValorItemDespesa = 250m
                        });
                });

            modelBuilder.Entity("VaquinhaWebAPI.Models.Pagamento", b =>
                {
                    b.Property<int>("PaganteId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID_PAGANTE");

                    b.Property<int>("ItemDespesaId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID_ITEM_DESPESA");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID_PAGAMENTO");

                    b.Property<int>("PercentualPago")
                        .HasColumnType("INTEGER")
                        .HasColumnName("NR_PERCENTUAL_PAGO");

                    b.HasKey("PaganteId", "ItemDespesaId");

                    b.HasIndex("ItemDespesaId");

                    b.ToTable("PAGAMENTO");

                    b.HasData(
                        new
                        {
                            PaganteId = 1,
                            ItemDespesaId = 1,
                            Id = 1,
                            PercentualPago = 60
                        },
                        new
                        {
                            PaganteId = 1,
                            ItemDespesaId = 2,
                            Id = 2,
                            PercentualPago = 60
                        },
                        new
                        {
                            PaganteId = 1,
                            ItemDespesaId = 3,
                            Id = 3,
                            PercentualPago = 60
                        },
                        new
                        {
                            PaganteId = 1,
                            ItemDespesaId = 4,
                            Id = 4,
                            PercentualPago = 70
                        },
                        new
                        {
                            PaganteId = 2,
                            ItemDespesaId = 1,
                            Id = 5,
                            PercentualPago = 40
                        },
                        new
                        {
                            PaganteId = 2,
                            ItemDespesaId = 2,
                            Id = 6,
                            PercentualPago = 40
                        },
                        new
                        {
                            PaganteId = 2,
                            ItemDespesaId = 3,
                            Id = 7,
                            PercentualPago = 40
                        },
                        new
                        {
                            PaganteId = 2,
                            ItemDespesaId = 4,
                            Id = 8,
                            PercentualPago = 30
                        });
                });

            modelBuilder.Entity("VaquinhaWebAPI.Models.Pagante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID_PAGANTE");

                    b.Property<string>("NomePagante")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("NM_NOME");

                    b.Property<string>("SobrenomePagante")
                        .HasColumnType("TEXT")
                        .HasColumnName("NM_SOBRENOME");

                    b.HasKey("Id");

                    b.ToTable("PAGANTE");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NomePagante = "Woshington",
                            SobrenomePagante = "Silva"
                        },
                        new
                        {
                            Id = 2,
                            NomePagante = "Charline",
                            SobrenomePagante = "Rocha"
                        });
                });

            modelBuilder.Entity("VaquinhaWebAPI.Models.TipoItemDespesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID_TIPO_ITEM_DESPESA");

                    b.Property<string>("NomeTipoItemDespesa")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("NM_TIPO_ITEM_DESPESA");

                    b.HasKey("Id");

                    b.ToTable("TIPO_ITEM_DESPESA");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NomeTipoItemDespesa = "Custeio Mensal"
                        },
                        new
                        {
                            Id = 2,
                            NomeTipoItemDespesa = "Outros"
                        });
                });

            modelBuilder.Entity("VaquinhaWebAPI.Models.ItemDespesa", b =>
                {
                    b.HasOne("VaquinhaWebAPI.Models.CategoriaItemDespesa", "CategoriaItemDespesa")
                        .WithMany()
                        .HasForeignKey("CategoriaItemDespesaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VaquinhaWebAPI.Models.TipoItemDespesa", "TipoItemDespesa")
                        .WithMany()
                        .HasForeignKey("TipoItemDespesaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoriaItemDespesa");

                    b.Navigation("TipoItemDespesa");
                });

            modelBuilder.Entity("VaquinhaWebAPI.Models.Pagamento", b =>
                {
                    b.HasOne("VaquinhaWebAPI.Models.ItemDespesa", "ItemDespesa")
                        .WithMany()
                        .HasForeignKey("ItemDespesaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VaquinhaWebAPI.Models.Pagante", "Pagante")
                        .WithMany()
                        .HasForeignKey("PaganteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemDespesa");

                    b.Navigation("Pagante");
                });
#pragma warning restore 612, 618
        }
    }
}
