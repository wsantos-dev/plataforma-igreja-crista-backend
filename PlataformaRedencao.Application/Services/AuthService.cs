using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlataformaRedencao.Application.DTOs.Auth;
using PlataformaRedencao.Application.Seguranca;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;

namespace PlataformaRedencao.Application.Services
{
    public class AuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPasswordHasher _passwordHasher;

        public AuthService(IUsuarioRepository usuarioRepository, IPasswordHasher passwordHasher)
        {
            _usuarioRepository = usuarioRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task CadastrarUsuarioAsync(RegisterUserRequestDTO requestDto)
        {
            var usuarioExistente = await _usuarioRepository.GetByEmailAsync(requestDto.Email);
            if (usuarioExistente is not null)
                throw new Exception("Usuário já cadastrado");

            var senhaHash = _passwordHasher.Hash(requestDto.Password);

            var usuario = new Usuario(requestDto.Email, senhaHash);

            await _usuarioRepository.AddAsync(usuario);
        }

        public async Task<Usuario> LoginAsync(LoginRequestDTO requestDto)
        {
            var usuario = await _usuarioRepository.GetByEmailAsync(requestDto.Email);
            if (usuario is null)
                throw new Exception("Credenciais inválidas.");

            var senhaValida = _passwordHasher.Verify(requestDto.Password, usuario.SenhaHash);
            if (!senhaValida)
                throw new Exception("Credenciais inválidas.");

            if (!usuario.IsAtivo)
                throw new Exception("Usuário inativo.");

            return usuario;
        }
    }
}