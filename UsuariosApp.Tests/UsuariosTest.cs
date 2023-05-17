using Azure.Core;
using Bogus;
using FluentAssertions;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Application.Models.Requests;
using UsuariosApp.Application.Models.Responses;
using UsuariosApp.Domain.Models;
using UsuariosApp.Tests.Helpers;
using Xunit;

namespace UsuariosApp.Tests
{
    public class UsuariosTest
    {
        [Fact]
        public async Task<CriarContaRequestDTO> Usuarios_Post_CriarConta_Returns_Created()
        {
            var faker = new Faker("pt_BR");
            var request = new CriarContaRequestDTO
            {
                Nome = faker.Person.FullName,
                Email = faker.Internet.Email(),
                Senha = "@Teste123"
            };

            var content = TestHelper.CreateContent(request);
            var result = await TestHelper.CreateClient.PostAsync("/api/usuarios/criar-conta", content);

            result.StatusCode
                .Should()
                .Be(HttpStatusCode.Created);

            var response = TestHelper.ReadResponse<CriarContaResponseDTO>(result);

            response.Id.Should().NotBeEmpty();
            response.Nome.Should().Be(request.Nome);
            response.Email.Should().Be(request.Email);
            response.DataHoraCriacao.Should().NotBeNull();

            return request;
        }

        [Fact]
        public async Task Usuarios_Post_CriarConta_Returns_BadRequest()
        {
            var usuario = await Usuarios_Post_CriarConta_Returns_Created();

            var request = new CriarContaRequestDTO
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = "@Teste123"
            };

            var content = TestHelper.CreateContent(request);
            var result = await TestHelper.CreateClient.PostAsync("/api/usuarios/criar-conta", content);

            result.StatusCode
                .Should()
                .Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Usuarios_Post_Autenticar_Returns_Ok()
        {
            var usuario = await Usuarios_Post_CriarConta_Returns_Created();

            var request = new AutenticarRequestDTO
            {
                Email = usuario.Email,
                Senha = usuario.Senha
            };

            var content = TestHelper.CreateContent(request);
            var result = await TestHelper.CreateClient.PostAsync("/api/usuarios/autenticar", content);

            result.StatusCode
                .Should()
                .Be(HttpStatusCode.OK);

            var response = TestHelper.ReadResponse<AutenticarResponseDTO>(result);

            response.Email.Should().Be(request.Email);
            response.AccessToken.Should().NotBeNullOrEmpty();
            response.DataHoraExpiracao.Should().NotBeNull();
        }

        [Fact]
        public async Task Usuarios_Post_Autenticar_Returns_Unauthorized()
        {
            var faker = new Faker("pt_BR");
            var request = new AutenticarRequestDTO
            {
                Email = faker.Internet.Email(),
                Senha = "@Teste321"
            };

            var content = TestHelper.CreateContent(request);
            var result = await TestHelper.CreateClient.PostAsync("/api/usuarios/autenticar", content);

            result.StatusCode
                .Should()
                .Be(HttpStatusCode.Unauthorized);
        }

        [Fact(Skip = "Não implementado.")]
        public void Usuarios_Post_RecuperarSenha_Returns_Ok()
        {

        }

        [Fact(Skip = "Não implementado.")]
        public void Usuarios_Post_RecuperarSenha_Returns_NotFound()
        {

        }
    }
}



