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
    [Migration("20220610010130_M63")]
    partial class M63
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AlunoResponsavel", b =>
                {
                    b.Property<int>("AlunosId")
                        .HasColumnType("int");

                    b.Property<int>("ResponsaveisResponsavelId")
                        .HasColumnType("int");

                    b.HasKey("AlunosId", "ResponsaveisResponsavelId");

                    b.HasIndex("ResponsaveisResponsavelId");

                    b.ToTable("AlunoResponsavel");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.Agenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Perfil")
                        .HasColumnType("int");

                    b.Property<int?>("TurmaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TurmaId");

                    b.ToTable("Agendas");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CodigoDoAluno")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("DataDeNascimento")
                        .HasColumnType("date");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NomeAlunoComCodigoEntreParenteses")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("TurmaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CodigoDoAluno")
                        .IsUnique();

                    b.HasIndex("TurmaId");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.AlunoLinhaDoTempo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId")
                        .IsUnique();

                    b.ToTable("AlunosLinhaDoTempo");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.AutorizacaoEvento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AlunoId")
                        .HasColumnType("int");

                    b.Property<string>("AssinadoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Autorizado")
                        .HasColumnType("bit");

                    b.Property<int?>("EventoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("EventoId");

                    b.ToTable("AutorizacoesEventos");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.ComentarioPostagemLinhaDoTempo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AutorId")
                        .HasColumnType("int");

                    b.Property<string>("Conteudo")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PostagemLinhaDoTempoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AutorId");

                    b.HasIndex("PostagemLinhaDoTempoId");

                    b.ToTable("ComentariosPostagensLinhaDoTempo");
                });

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

            modelBuilder.Entity("App_comunicacao_escolar.Models.Disciplina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NomeComCodigoEntreParenteses")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TurmaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Codigo")
                        .IsUnique();

                    b.HasIndex("TurmaId");

                    b.ToTable("Disciplinas");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.EventoDaAgenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AgendaId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<DateTime?>("FimDoEvento")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int>("IdUsuarioQueCadastrouEvento")
                        .HasColumnType("int");

                    b.Property<DateTime?>("InicioDoEvento")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("RequerAutorizacao")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AgendaId");

                    b.HasIndex("IdUsuarioQueCadastrouEvento");

                    b.ToTable("EventosDaAgenda");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.HorariosDaDisciplina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("DiaDaSemana")
                        .HasColumnType("int");

                    b.Property<int?>("DisciplinaId")
                        .HasColumnType("int");

                    b.Property<string>("HorarioFim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HorarioInicio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DisciplinaId");

                    b.ToTable("HorariosDasDisciplinas");
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

                    b.Property<string>("ListaDestinatarios")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ListaDestinatariosNome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MensagemRespondidaId")
                        .HasColumnType("int");

                    b.Property<int?>("RemetenteId")
                        .HasColumnType("int");

                    b.Property<string>("RemetenteNome")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

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

            modelBuilder.Entity("App_comunicacao_escolar.Models.Notificacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Assunto")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Conteudo")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<int>("Perfil")
                        .HasColumnType("int");

                    b.Property<int?>("TurmaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TurmaId");

                    b.ToTable("Notificacoes");
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

            modelBuilder.Entity("App_comunicacao_escolar.Models.PostagemLinhaDoTempo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Assunto")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("AutorId")
                        .HasColumnType("int");

                    b.Property<string>("CodigoImagemPostada")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Conteudo")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LinhaDoTempoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AutorId");

                    b.HasIndex("LinhaDoTempoId");

                    b.ToTable("PostagensLinhaDoTempo");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.Professor", b =>
                {
                    b.Property<int>("ProfessorId")
                        .HasColumnType("int");

                    b.Property<string>("Formacao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Nivel")
                        .HasColumnType("int");

                    b.HasKey("ProfessorId");

                    b.ToTable("Professores");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.Responsavel", b =>
                {
                    b.Property<int>("ResponsavelId")
                        .HasColumnType("int");

                    b.HasKey("ResponsavelId");

                    b.ToTable("Responsaveis");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.Turma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NomeComCodigoEntreParenteses")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Codigo")
                        .IsUnique();

                    b.ToTable("Turmas");
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
                        .IsRequired()
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

                    b.Property<string>("NomeDisplayLista")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

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
                        .IsUnique();

                    b.HasIndex("NomeDeUsuario")
                        .IsUnique();

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.UsuarioLeuNotificacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("NotificacaoId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NotificacaoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("UsuarioLeuNotificacao");
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

            modelBuilder.Entity("DisciplinaProfessor", b =>
                {
                    b.Property<int>("DisciplinasId")
                        .HasColumnType("int");

                    b.Property<int>("ProfessoresProfessorId")
                        .HasColumnType("int");

                    b.HasKey("DisciplinasId", "ProfessoresProfessorId");

                    b.HasIndex("ProfessoresProfessorId");

                    b.ToTable("DisciplinaProfessor");
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

            modelBuilder.Entity("AlunoResponsavel", b =>
                {
                    b.HasOne("App_comunicacao_escolar.Models.Aluno", null)
                        .WithMany()
                        .HasForeignKey("AlunosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App_comunicacao_escolar.Models.Responsavel", null)
                        .WithMany()
                        .HasForeignKey("ResponsaveisResponsavelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.Agenda", b =>
                {
                    b.HasOne("App_comunicacao_escolar.Models.Turma", "Turma")
                        .WithMany("Agendas")
                        .HasForeignKey("TurmaId");

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.Aluno", b =>
                {
                    b.HasOne("App_comunicacao_escolar.Models.Turma", "Turma")
                        .WithMany("Alunos")
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.AlunoLinhaDoTempo", b =>
                {
                    b.HasOne("App_comunicacao_escolar.Models.Aluno", "Aluno")
                        .WithOne("AlunosLinhaDoTempo")
                        .HasForeignKey("App_comunicacao_escolar.Models.AlunoLinhaDoTempo", "AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.AutorizacaoEvento", b =>
                {
                    b.HasOne("App_comunicacao_escolar.Models.Aluno", "Aluno")
                        .WithMany("Autorizacoes")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("App_comunicacao_escolar.Models.EventoDaAgenda", "Evento")
                        .WithMany("Autorizacoes")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Aluno");

                    b.Navigation("Evento");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.ComentarioPostagemLinhaDoTempo", b =>
                {
                    b.HasOne("App_comunicacao_escolar.Models.Usuario", "Autor")
                        .WithMany("ComentariosPostagensLinhaDoTempo")
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("App_comunicacao_escolar.Models.PostagemLinhaDoTempo", "Postagem")
                        .WithMany("Comentarios")
                        .HasForeignKey("PostagemLinhaDoTempoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Autor");

                    b.Navigation("Postagem");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.Disciplina", b =>
                {
                    b.HasOne("App_comunicacao_escolar.Models.Turma", "Turma")
                        .WithMany("Disciplinas")
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.EventoDaAgenda", b =>
                {
                    b.HasOne("App_comunicacao_escolar.Models.Agenda", "Agenda")
                        .WithMany("EventosDaAgenda")
                        .HasForeignKey("AgendaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("App_comunicacao_escolar.Models.Usuario", "Usuario")
                        .WithMany("EventosCadastrados")
                        .HasForeignKey("IdUsuarioQueCadastrouEvento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agenda");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.HorariosDaDisciplina", b =>
                {
                    b.HasOne("App_comunicacao_escolar.Models.Disciplina", "Disciplina")
                        .WithMany("HorariosDaDisciplina")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Disciplina");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.Mensagem", b =>
                {
                    b.HasOne("App_comunicacao_escolar.Models.Conversa", "Conversa")
                        .WithMany("Mensagens")
                        .HasForeignKey("ConversaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("App_comunicacao_escolar.Models.Mensagem", "MensagemRespondida")
                        .WithMany("Respostas")
                        .HasForeignKey("MensagemRespondidaId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Conversa");

                    b.Navigation("MensagemRespondida");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.MensagemArquivosAnexados", b =>
                {
                    b.HasOne("App_comunicacao_escolar.Models.Mensagem", "MensagemDosAnexos")
                        .WithMany("Anexos")
                        .HasForeignKey("MensagemDosAnexosId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("MensagemDosAnexos");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.Notificacao", b =>
                {
                    b.HasOne("App_comunicacao_escolar.Models.Turma", "Turma")
                        .WithMany("NotificacoesTurma")
                        .HasForeignKey("TurmaId");

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.NumeroDeNovasMensagensNaConversa", b =>
                {
                    b.HasOne("App_comunicacao_escolar.Models.Conversa", "Conversa")
                        .WithMany("NumeroDeNovasMensagensNaConversa")
                        .HasForeignKey("ConversaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Conversa");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.PostagemLinhaDoTempo", b =>
                {
                    b.HasOne("App_comunicacao_escolar.Models.Usuario", "Autor")
                        .WithMany("PostagensLinhaDoTempo")
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("App_comunicacao_escolar.Models.AlunoLinhaDoTempo", "LinhaDoTempo")
                        .WithMany("Postagens")
                        .HasForeignKey("LinhaDoTempoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Autor");

                    b.Navigation("LinhaDoTempo");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.Professor", b =>
                {
                    b.HasOne("App_comunicacao_escolar.Models.Usuario", "Usuario")
                        .WithOne("Professor")
                        .HasForeignKey("App_comunicacao_escolar.Models.Professor", "ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.Responsavel", b =>
                {
                    b.HasOne("App_comunicacao_escolar.Models.Usuario", "Usuario")
                        .WithOne("Responsavel")
                        .HasForeignKey("App_comunicacao_escolar.Models.Responsavel", "ResponsavelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.UsuarioLeuNotificacao", b =>
                {
                    b.HasOne("App_comunicacao_escolar.Models.Notificacao", "Notificacao")
                        .WithMany("NotificacoesLidas")
                        .HasForeignKey("NotificacaoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("App_comunicacao_escolar.Models.Usuario", "Usuario")
                        .WithMany("NotificacoesLidas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Notificacao");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.UsuariosQueArquivaramConversa", b =>
                {
                    b.HasOne("App_comunicacao_escolar.Models.Conversa", "Conversa")
                        .WithMany("UsuariosQueArquivaramConversa")
                        .HasForeignKey("ConversaId")
                        .OnDelete(DeleteBehavior.Cascade);

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

            modelBuilder.Entity("DisciplinaProfessor", b =>
                {
                    b.HasOne("App_comunicacao_escolar.Models.Disciplina", null)
                        .WithMany()
                        .HasForeignKey("DisciplinasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App_comunicacao_escolar.Models.Professor", null)
                        .WithMany()
                        .HasForeignKey("ProfessoresProfessorId")
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

            modelBuilder.Entity("App_comunicacao_escolar.Models.Agenda", b =>
                {
                    b.Navigation("EventosDaAgenda");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.Aluno", b =>
                {
                    b.Navigation("AlunosLinhaDoTempo");

                    b.Navigation("Autorizacoes");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.AlunoLinhaDoTempo", b =>
                {
                    b.Navigation("Postagens");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.Conversa", b =>
                {
                    b.Navigation("Mensagens");

                    b.Navigation("NumeroDeNovasMensagensNaConversa");

                    b.Navigation("UsuariosQueArquivaramConversa");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.Disciplina", b =>
                {
                    b.Navigation("HorariosDaDisciplina");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.EventoDaAgenda", b =>
                {
                    b.Navigation("Autorizacoes");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.Mensagem", b =>
                {
                    b.Navigation("Anexos");

                    b.Navigation("Respostas");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.Notificacao", b =>
                {
                    b.Navigation("NotificacoesLidas");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.PostagemLinhaDoTempo", b =>
                {
                    b.Navigation("Comentarios");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.Turma", b =>
                {
                    b.Navigation("Agendas");

                    b.Navigation("Alunos");

                    b.Navigation("Disciplinas");

                    b.Navigation("NotificacoesTurma");
                });

            modelBuilder.Entity("App_comunicacao_escolar.Models.Usuario", b =>
                {
                    b.Navigation("ComentariosPostagensLinhaDoTempo");

                    b.Navigation("EventosCadastrados");

                    b.Navigation("NotificacoesLidas");

                    b.Navigation("PostagensLinhaDoTempo");

                    b.Navigation("Professor");

                    b.Navigation("Responsavel");
                });
#pragma warning restore 612, 618
        }
    }
}
