using Bogus;
using FluentAssertions;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Application.Models.Requests;
using UsuariosApp.Application.Models.Responses;
using UsuariosApp.Tests.Helpers;
using Xunit;

namespace UsuariosApp.Tests
{
    public class UsuariosTest
    {
        [Fact]
        public async Task<CriarContaResponseDTO> Usuarios_POST_CriarConta_Returns_Created()
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
                .Be(System.Net.HttpStatusCode.Created);

            var response = TestHelper.ReadResponse<CriarContaResponseDTO>(result);

            response.Id.Should().NotBeEmpty();
            response.Nome.Should().Be(request.Nome);
            response.Email.Should().Be(request.Email);
            response.DataHoraCriacao.Should().NotBeNull();

            return response;
        }

        [Fact]
        public async Task Usuarios_POST_CriarConta_Returns_BadRequest()
        {
            var usuario = await Usuarios_POST_CriarConta_Returns_Created();

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

        [Fact(Skip = "Not implemented")]
        public void Usuarios_POST_Autenticar_Returns_OK()
        {

        }

        [Fact(Skip = "Not implemented")]
        public void Usuarios_POST_Autenticar_Returns_Unauthorized()
        {

        }
    }
}
