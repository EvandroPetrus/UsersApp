using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Application.Helpers;
using UsuariosApp.Application.Interfaces;
using UsuariosApp.Application.Models.Requests;
using UsuariosApp.Application.Models.Responses;
using UsuariosApp.Domain.Interfaces.Services;
using UsuariosApp.Domain.Models;

namespace UsuariosApp.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioDomainService _usuarioDomainService;
        private readonly IMapper _mapper;

        public UsuarioAppService(IUsuarioDomainService? usuarioDomainService, IMapper? mapper)
        {
            _usuarioDomainService = usuarioDomainService;
            _mapper = mapper;
        }

        public AutenticarResponseDTO Autenticar(AutenticarRequestDTO dto)
        {
            var usuario = _usuarioDomainService?.Autenticar(dto.Email, SHA1Helper.Encrypt(dto.Senha));
            return _mapper.Map<AutenticarResponseDTO>(usuario);
        }

        public CriarContaResponseDTO CriarConta(CriarContaRequestDTO dto)
        {

            //var usuario = new Usuario
            //{
            //    Id = Guid.NewGuid(),
            //    Nome = dto.Nome,
            //    Email = dto.Email,
            //    Senha = dto.Senha,
            //    DataHoraCriacao = DateTime.Now
            //};

            var usuario = _mapper.Map<Usuario>(dto);

            _usuarioDomainService?.CriarConta(usuario);

            //return new CriarContaResponseDTO
            //{
            //    Id = usuario.Id,
            //    Nome = usuario.Nome,
            //    Email = usuario.Email,
            //    DataHoraCriacao = usuario.DataHoraCriacao
            //};

            return _mapper.Map<CriarContaResponseDTO>(usuario);
        }

        public RecuperarSenhaResponseDTO RecuperarSenha(RecuperarSenhaRequestDTO dto)
        {
            var usuario = _usuarioDomainService.RecuperarSenha(dto.Email);
            return _mapper.Map<RecuperarSenhaResponseDTO>(usuario);
        }

        public void Dispose()
            => _usuarioDomainService.Dispose();
    }
}
