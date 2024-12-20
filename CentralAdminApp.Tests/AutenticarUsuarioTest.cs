﻿using Bogus;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using CentralAdminApp.Domain.Dtos;
using Xunit;

namespace CentralAdminApp.Tests
{
    /// <summary>
    /// Testes para o serviço de autenticação de usuário da API
    /// </summary>
    public class AutenticarUsuarioTest
    {
        [Fact]
        public async Task Autenticar_Usuario_Com_Sucesso_Test()
        {
            var faker = new Faker("pt_BR");

            var requestCriarUsuario = new CriarUsuarioRequest
            {
                Nome = faker.Person.FullName,
                Email = faker.Internet.Email(),
                Senha = "@Teste2024"
            };

            var jsonCriarUsuario = new StringContent(JsonConvert.SerializeObject
                (requestCriarUsuario), Encoding.UTF8, "application/json");

            //criando um usuário na API
            var client = new WebApplicationFactory<Program>().CreateClient();
            await client.PostAsync("/api/usuarios/criar", jsonCriarUsuario);

            var requestAutenticarUsuario = new AutenticarUsuarioRequest
            {
                Email = requestCriarUsuario.Email,
                Senha = requestCriarUsuario.Senha
            };

            var jsonAutenticarUsuario = new StringContent(JsonConvert.SerializeObject
                (requestAutenticarUsuario), Encoding.UTF8, "application/json");

            //autenticando o usuário na API
            var response = await client.PostAsync("/api/usuarios/autenticar", jsonAutenticarUsuario);

            //verificando a resposta
            response.StatusCode
                .Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Acesso_Negado_Test()
        {
            var faker = new Faker("pt_BR");

            var request = new AutenticarUsuarioRequest
            {
                Email = faker.Internet.Email(),
                Senha = "@Teste2024"
            };

            var json = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var client = new WebApplicationFactory<Program>().CreateClient();
            var response = await client.PostAsync("/api/usuarios/autenticar", json);

            response.StatusCode
                .Should().Be(HttpStatusCode.Unauthorized);

            var mensagem = await response.Content.ReadAsStringAsync();
            mensagem
                .Should().Contain("Acesso negado. Usuário inválido.");
        }
    }
}