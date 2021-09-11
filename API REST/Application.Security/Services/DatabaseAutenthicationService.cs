using Application.Core;
using Application.Security.Core;
using Application.Security.Interfaces;
using AutoMapper.QueryableExtensions;
using Domain.MainModule.Interfaces.RepositoryContracts;
using Infraestructure.Crosscutting;
using Infraestructure.Crosscutting.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Application.Security.Services
{
  public class DatabaseAutenthicationService : BaseAppService, IAutenthicationService
  {
    private readonly IUsuarioRepository _userRepository;

    public DatabaseAutenthicationService(IServiceProvider serviceProvider)
        : base(serviceProvider)
    {
      _userRepository = serviceProvider.GetService<IUsuarioRepository>();
    }

    public async Task<UserApp> Login(string username, string password)
    {
      var encryptedPassword = CryptoCustom.EncryptByAES(password);
      var pas = CryptoCustom.DecryptByAES("A9E4AE8B417AFFA0D9FAF0DCAFF260EA");

      var usuarioAAutenticar = await _userRepository.FindByUsernameAndPassword(username, encryptedPassword)
                                                .ProjectTo<UserApp>(_mapper.ConfigurationProvider)
                                                .FirstOrDefaultAsync();

      return usuarioAAutenticar;
    }
  }
}
