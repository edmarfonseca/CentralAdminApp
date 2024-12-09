﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using CentralAdminApp.Infra.Data.Contexts;

#nullable disable

namespace CentralAdminApp.Infra.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241207064643_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("CentralAdminApp.Domain.Entities.Api", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("ATIVO");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DATA_ALTERACAO");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DATA_INCLUSAO");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("NOME");

                    b.Property<int>("SistemaId")
                        .HasColumnType("int")
                        .HasColumnName("SISTEMA_ID");

                    b.Property<string>("Uri")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("URI");

                    b.HasKey("Id");

                    b.HasIndex("SistemaId");

                    b.HasIndex("Uri")
                        .IsUnique();

                    b.ToTable("TB_API", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            DataAlteracao = new DateTime(2024, 12, 7, 3, 46, 35, 57, DateTimeKind.Local).AddTicks(6127),
                            DataInclusao = new DateTime(2024, 12, 7, 3, 46, 35, 57, DateTimeKind.Local).AddTicks(6127),
                            Nome = "Criação de Usuário",
                            SistemaId = 1,
                            Uri = "api/usuarios/criar"
                        });
                });

            modelBuilder.Entity("CentralAdminApp.Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("ATIVO");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("BAIRRO");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)")
                        .HasColumnName("CEP");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("CIDADE");

                    b.Property<string>("CpfCnpj")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)")
                        .HasColumnName("CPF_CNPJ");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DATA_ALTERACAO");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DATA_INCLUSAO");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("LOGRADOURO");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("NOME");

                    b.Property<int?>("Numero")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnName("NUMERO");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)")
                        .HasColumnName("UF");

                    b.HasKey("Id");

                    b.HasIndex("CpfCnpj")
                        .IsUnique();

                    b.ToTable("TB_CLIENTE", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            Bairro = "Centro",
                            Cep = "20031140",
                            Cidade = "Rio de Janeiro",
                            CpfCnpj = "26263267000165",
                            DataAlteracao = new DateTime(2024, 12, 7, 3, 46, 35, 57, DateTimeKind.Local).AddTicks(6127),
                            DataInclusao = new DateTime(2024, 12, 7, 3, 46, 35, 57, DateTimeKind.Local).AddTicks(6127),
                            Logradouro = "Rua México",
                            Nome = "Facto Soluções em TI",
                            Numero = 31,
                            Uf = "RJ"
                        });
                });

            modelBuilder.Entity("CentralAdminApp.Domain.Entities.ClienteSistema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("ATIVO");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int")
                        .HasColumnName("CLIENTE_ID");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DATA_ALTERACAO");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DATA_INCLUSAO");

                    b.Property<int>("SistemaId")
                        .HasColumnType("int")
                        .HasColumnName("SISTEMA_ID");

                    b.HasKey("Id");

                    b.HasIndex("SistemaId");

                    b.HasIndex("ClienteId", "SistemaId")
                        .IsUnique();

                    b.ToTable("TB_CLIENTE_SISTEMA", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            ClienteId = 1,
                            DataAlteracao = new DateTime(2024, 12, 7, 3, 46, 35, 57, DateTimeKind.Local).AddTicks(6127),
                            DataInclusao = new DateTime(2024, 12, 7, 3, 46, 35, 57, DateTimeKind.Local).AddTicks(6127),
                            SistemaId = 1
                        });
                });

            modelBuilder.Entity("CentralAdminApp.Domain.Entities.Perfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("ATIVO");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DATA_ALTERACAO");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DATA_INCLUSAO");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("NOME");

                    b.Property<int>("SistemaId")
                        .HasColumnType("int")
                        .HasColumnName("SISTEMA_ID");

                    b.HasKey("Id");

                    b.HasIndex("SistemaId");

                    b.HasIndex("Nome", "SistemaId")
                        .IsUnique();

                    b.ToTable("TB_PERFIL", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            DataAlteracao = new DateTime(2024, 12, 7, 3, 46, 35, 57, DateTimeKind.Local).AddTicks(6127),
                            DataInclusao = new DateTime(2024, 12, 7, 3, 46, 35, 57, DateTimeKind.Local).AddTicks(6127),
                            Nome = "ADMINISTRADOR",
                            SistemaId = 1
                        });
                });

            modelBuilder.Entity("CentralAdminApp.Domain.Entities.PerfilApi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ApiId")
                        .HasColumnType("int")
                        .HasColumnName("API_ID");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("ATIVO");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DATA_ALTERACAO");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DATA_INCLUSAO");

                    b.Property<int>("PerfilId")
                        .HasColumnType("int")
                        .HasColumnName("PERFIL_ID");

                    b.HasKey("Id");

                    b.HasIndex("ApiId");

                    b.HasIndex("PerfilId", "ApiId")
                        .IsUnique();

                    b.ToTable("TB_PERFIL_API", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApiId = 1,
                            Ativo = true,
                            DataAlteracao = new DateTime(2024, 12, 7, 3, 46, 35, 57, DateTimeKind.Local).AddTicks(6127),
                            DataInclusao = new DateTime(2024, 12, 7, 3, 46, 35, 57, DateTimeKind.Local).AddTicks(6127),
                            PerfilId = 1
                        });
                });

            modelBuilder.Entity("CentralAdminApp.Domain.Entities.Sistema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("ATIVO");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("CODIGO");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DATA_ALTERACAO");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DATA_INCLUSAO");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("NOME");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("URL");

                    b.HasKey("Id");

                    b.HasIndex("Url")
                        .IsUnique();

                    b.ToTable("TB_SISTEMA", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            Codigo = "CA",
                            DataAlteracao = new DateTime(2024, 12, 7, 3, 46, 35, 57, DateTimeKind.Local).AddTicks(6127),
                            DataInclusao = new DateTime(2024, 12, 7, 3, 46, 35, 57, DateTimeKind.Local).AddTicks(6127),
                            Nome = "Central Admin",
                            Url = "http://localhost:5232/"
                        });
                });

            modelBuilder.Entity("CentralAdminApp.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("ATIVO");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int")
                        .HasColumnName("CLIENTE_ID");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DATA_ALTERACAO");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DATA_INCLUSAO");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("NOME");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("SENHA");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("TB_USUARIO", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            ClienteId = 1,
                            DataAlteracao = new DateTime(2024, 12, 7, 3, 46, 35, 57, DateTimeKind.Local).AddTicks(6127),
                            DataInclusao = new DateTime(2024, 12, 7, 3, 46, 35, 57, DateTimeKind.Local).AddTicks(6127),
                            Email = "factoti@factoti.com.br",
                            Nome = "Facto Soluções",
                            Senha = "82a2c0a772363847406da82a26e5f94cda0d4e54b9c1edde375c63610bfe8386"
                        },
                        new
                        {
                            Id = 2,
                            Ativo = true,
                            ClienteId = 1,
                            DataAlteracao = new DateTime(2024, 12, 7, 3, 46, 35, 57, DateTimeKind.Local).AddTicks(6127),
                            DataInclusao = new DateTime(2024, 12, 7, 3, 46, 35, 57, DateTimeKind.Local).AddTicks(6127),
                            Email = "edmarfonseca12@gmail.com",
                            Nome = "Edmar Fonseca",
                            Senha = "e61fef737df8527480b6f25954acd71e17dbd0175bc7b377174f0614274b0535"
                        });
                });

            modelBuilder.Entity("CentralAdminApp.Domain.Entities.UsuarioPerfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("ATIVO");

                    b.Property<int>("ClienteSistemaId")
                        .HasColumnType("int")
                        .HasColumnName("CLIENTE_SISTEMA_ID");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DATA_ALTERACAO");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DATA_INCLUSAO");

                    b.Property<int>("PerfilId")
                        .HasColumnType("int")
                        .HasColumnName("PERFIL_ID");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int")
                        .HasColumnName("USUARIO_ID");

                    b.HasKey("Id");

                    b.HasIndex("ClienteSistemaId");

                    b.HasIndex("PerfilId");

                    b.HasIndex("UsuarioId", "ClienteSistemaId")
                        .IsUnique();

                    b.ToTable("TB_USUARIO_PERFIL", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            ClienteSistemaId = 1,
                            DataAlteracao = new DateTime(2024, 12, 7, 3, 46, 35, 57, DateTimeKind.Local).AddTicks(6127),
                            DataInclusao = new DateTime(2024, 12, 7, 3, 46, 35, 57, DateTimeKind.Local).AddTicks(6127),
                            PerfilId = 1,
                            UsuarioId = 1
                        });
                });

            modelBuilder.Entity("CentralAdminApp.Domain.Entities.Api", b =>
                {
                    b.HasOne("CentralAdminApp.Domain.Entities.Sistema", "Sistema")
                        .WithMany("Apis")
                        .HasForeignKey("SistemaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Sistema");
                });

            modelBuilder.Entity("CentralAdminApp.Domain.Entities.ClienteSistema", b =>
                {
                    b.HasOne("CentralAdminApp.Domain.Entities.Cliente", "Cliente")
                        .WithMany("Sistemas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CentralAdminApp.Domain.Entities.Sistema", "Sistema")
                        .WithMany("Clientes")
                        .HasForeignKey("SistemaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Sistema");
                });

            modelBuilder.Entity("CentralAdminApp.Domain.Entities.Perfil", b =>
                {
                    b.HasOne("CentralAdminApp.Domain.Entities.Sistema", "Sistema")
                        .WithMany("Perfis")
                        .HasForeignKey("SistemaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Sistema");
                });

            modelBuilder.Entity("CentralAdminApp.Domain.Entities.PerfilApi", b =>
                {
                    b.HasOne("CentralAdminApp.Domain.Entities.Api", "Api")
                        .WithMany("Perfis")
                        .HasForeignKey("ApiId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CentralAdminApp.Domain.Entities.Perfil", "Perfil")
                        .WithMany("Apis")
                        .HasForeignKey("PerfilId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Api");

                    b.Navigation("Perfil");
                });

            modelBuilder.Entity("CentralAdminApp.Domain.Entities.Usuario", b =>
                {
                    b.HasOne("CentralAdminApp.Domain.Entities.Cliente", "Cliente")
                        .WithMany("Usuarios")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("CentralAdminApp.Domain.Entities.UsuarioPerfil", b =>
                {
                    b.HasOne("CentralAdminApp.Domain.Entities.ClienteSistema", "ClienteSistema")
                        .WithMany("UsuariosPerfis")
                        .HasForeignKey("ClienteSistemaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CentralAdminApp.Domain.Entities.Perfil", "Perfil")
                        .WithMany("Usuarios")
                        .HasForeignKey("PerfilId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CentralAdminApp.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Perfis")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ClienteSistema");

                    b.Navigation("Perfil");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("CentralAdminApp.Domain.Entities.Api", b =>
                {
                    b.Navigation("Perfis");
                });

            modelBuilder.Entity("CentralAdminApp.Domain.Entities.Cliente", b =>
                {
                    b.Navigation("Sistemas");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("CentralAdminApp.Domain.Entities.ClienteSistema", b =>
                {
                    b.Navigation("UsuariosPerfis");
                });

            modelBuilder.Entity("CentralAdminApp.Domain.Entities.Perfil", b =>
                {
                    b.Navigation("Apis");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("CentralAdminApp.Domain.Entities.Sistema", b =>
                {
                    b.Navigation("Apis");

                    b.Navigation("Clientes");

                    b.Navigation("Perfis");
                });

            modelBuilder.Entity("CentralAdminApp.Domain.Entities.Usuario", b =>
                {
                    b.Navigation("Perfis");
                });
#pragma warning restore 612, 618
        }
    }
}
