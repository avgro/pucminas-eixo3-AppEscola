﻿// <auto-generated />
using System;
using App_comunicacao_escolar.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App_comunicacao_escolar.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220423212342_M10")]
    partial class M10
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("App_comunicacao_escolar.Models.Conversa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Assunto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PrimeiraMensagem")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RemetenteId")
                        .HasColumnType("int");

                    b.Property<string>("RemetenteNome")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Conversas");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.Mensagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Conteudo")
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ConversaId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataEnvio")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MensagemRespondidaId")
                        .HasColumnType("int");

                    b.Property<int?>("RemetenteId")
                        .HasColumnType("int");

                    b.Property<string>("RemetenteNome")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("listaDestinatarios")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("listaDestinatariosNome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ConversaId");

                    b.HasIndex("MensagemRespondidaId");

                    b.ToTable("Mensagem");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.MensagemArquivosAnexados", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("MensagemDosAnexosId")
                        .HasColumnType("int");

                    b.Property<string>("NomeOriginalDoArquivo")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("NomeUnicoDoArquivo")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("MensagemDosAnexosId");

                    b.ToTable("MensagemMensagemArquivosAnexados");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.NumeroDeNovasMensagensNaConversa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ConversaId")
                        .HasColumnType("int");

                    b.Property<int>("NumeroDeMensagensNaoLidas")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConversaId");

                    b.ToTable("NumeroDeNovasMensagensNaConversa");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .HasMaxLength(320)
                        .HasColumnType("nvarchar(320)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NomeDeUsuario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Perfil")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TelefoneFixo")
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("TelefoneMovel")
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("NomeDeUsuario")
                        .IsUnique();

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.UsuariosQueArquivaramConversa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ConversaId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConversaId");

                    b.ToTable("UsuariosQueArquivaramConversa");
                });

            modelBuilder.Entity("ConversaUsuario", b =>
                {
                    b.Property<int>("ConversasId")
                        .HasColumnType("int");

                    b.Property<int>("ParticipantesId")
                        .HasColumnType("int");

                    b.HasKey("ConversasId", "ParticipantesId");

                    b.HasIndex("ParticipantesId");

                    b.ToTable("ConversaUsuario");
                });

            modelBuilder.Entity("MensagemUsuario", b =>
                {
                    b.Property<int>("MensagemId")
                        .HasColumnType("int");

                    b.Property<int>("ParticipantesId")
                        .HasColumnType("int");

                    b.HasKey("MensagemId", "ParticipantesId");

                    b.HasIndex("ParticipantesId");

                    b.ToTable("MensagemUsuario");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.Mensagem", b =>
                {
                    b.HasOne("App_comunicacao_escolar.Models.Conversa", "Conversa")
                        .WithMany("Mensagens")
                        .HasForeignKey("ConversaId");

                    b.HasOne("App_comunicacao_escolar.Models.Mensagem", "MensagemRespondida")
                        .WithMany("Respostas")
                        .HasForeignKey("MensagemRespondidaId");

                    b.Navigation("Conversa");

                    b.Navigation("MensagemRespondida");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.MensagemArquivosAnexados", b =>
                {
                    b.HasOne("App_comunicacao_escolar.Models.Mensagem", "MensagemDosAnexos")
                        .WithMany("Anexos")
                        .HasForeignKey("MensagemDosAnexosId");

                    b.Navigation("MensagemDosAnexos");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.NumeroDeNovasMensagensNaConversa", b =>
                {
                    b.HasOne("App_comunicacao_escolar.Models.Conversa", "Conversa")
                        .WithMany("NumeroDeNovasMensagensNaConversa")
                        .HasForeignKey("ConversaId");

                    b.Navigation("Conversa");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.UsuariosQueArquivaramConversa", b =>
                {
                    b.HasOne("App_comunicacao_escolar.Models.Conversa", "Conversa")
                        .WithMany("UsuariosQueArquivaramConversa")
                        .HasForeignKey("ConversaId");

                    b.Navigation("Conversa");
                });

            modelBuilder.Entity("ConversaUsuario", b =>
                {
                    b.HasOne("App_comunicacao_escolar.Models.Conversa", null)
                        .WithMany()
                        .HasForeignKey("ConversasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App_comunicacao_escolar.Models.Usuario", null)
                        .WithMany()
                        .HasForeignKey("ParticipantesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MensagemUsuario", b =>
                {
                    b.HasOne("App_comunicacao_escolar.Models.Mensagem", null)
                        .WithMany()
                        .HasForeignKey("MensagemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App_comunicacao_escolar.Models.Usuario", null)
                        .WithMany()
                        .HasForeignKey("ParticipantesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.Conversa", b =>
                {
                    b.Navigation("Mensagens");

                    b.Navigation("NumeroDeNovasMensagensNaConversa");

                    b.Navigation("UsuariosQueArquivaramConversa");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.Mensagem", b =>
                {
                    b.Navigation("Anexos");

                    b.Navigation("Respostas");
                });
#pragma warning restore 612, 618
        }
    }
}
