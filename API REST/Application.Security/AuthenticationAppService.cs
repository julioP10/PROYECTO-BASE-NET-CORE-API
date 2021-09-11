using Application.Core;
using Application.Dto;
using Application.Security.Core;
using Application.Security.Exceptions;
using Application.Security.Interfaces;
using Application.Security.JwtToken;
using Application.Security.Services;
using AutoMapper.QueryableExtensions;
using Domain.MainModule.Entities;
using Domain.MainModule.Interfaces.RepositoryContracts;
using Infraestructure.Crosscutting;
using Infraestructure.Crosscutting.Enums;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Application.Security
{
    public class AuthenticationAppService : BaseAppService, IAuthenticationAppService
    {
        private readonly Dictionary<int, IAutenthicationService> _autenthicationProviders =
            new Dictionary<int, IAutenthicationService>();

        private readonly IJwtFactory _jwtFactory;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly JwtIssuerOptions _jwtOptions;
        private UsuarioDto usuario = null;

        public AuthenticationAppService(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            _jwtFactory = serviceProvider.GetService<IJwtFactory>();
            _jwtOptions = serviceProvider.GetService<IOptions<JwtIssuerOptions>>().Value;
            _usuarioRepository = serviceProvider.GetService<IUsuarioRepository>();

            _autenthicationProviders.Add((int)AuthenticationType.DataBase, new DatabaseAutenthicationService(serviceProvider));
            _autenthicationProviders.Add((int)AuthenticationType.ActiveDirectory, new LdapAutenthicationService(serviceProvider));
        }

        public virtual async Task<JwtResponse> LoginAsync(string username, string password)
        {
            var identity = await GetClaimsIdentityAsync(username, password);

            var jwt = await Tokens.GenerateJwt(identity, _jwtFactory, username, _jwtOptions,
                new JsonSerializerSettings { Formatting = Formatting.Indented });
            jwt.Usuario = usuario; 
            return jwt;
        }

        protected virtual async Task<ClaimsIdentity> GetClaimsIdentityAsync(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                return await Task.FromResult<ClaimsIdentity>(null);

            var usuarioDb = _usuarioRepository.FindByUsername(userName)
                                .ProjectTo<UserApp>(_mapper.ConfigurationProvider)
                                .FirstOrDefault();

            if (usuarioDb == null)
                throw new InvalidCredentialsException(_localizer[ResourcesNames.Validation.InvalidCredentials]);

            if (usuarioDb.Vigencia == false)
                throw new UnauthorizedAccessException(_localizer[ResourcesNames.Validation.UserDisabled]);

            usuario = _mapper.Map<UsuarioDto>(usuarioDb);
            var userToVerify = await _autenthicationProviders[usuarioDb.ModoAutenticacion].Login(userName, password);
            if (userToVerify == null) throw new InvalidCredentialsException(_localizer[ResourcesNames.Validation.InvalidCredentials]);

            var claimIndetity = _jwtFactory.GenerateClaimsIdentity(userName, usuarioDb.Id.ToString());

            return await Task.FromResult(claimIndetity);
        }
    }
}
