using Application.Core;
using Application.Dto;
using Application.MainModule.Interfaces;
using AutoMapper.QueryableExtensions;
using Domain.MainModule.Entities;
using Domain.MainModule.Interfaces;
using Domain.MainModule.Interfaces.RepositoryContracts;
using Infraestructure.Crosscutting;
using Infraestructure.Crosscutting.Enums;
using Infraestructure.Crosscutting.Exceptions;
using Infraestructure.Crosscutting.Resources;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPush;

namespace Application.MainModule
{
    public class UsuarioAppService : BaseAppService, IUsuarioAppService
    {
        private readonly IUsuarioRepository _userRepository;
        public UsuarioAppService(
            IServiceProvider serviceProvider,
            IUsuarioRepository userRepository) : base(serviceProvider)
        {
            _userRepository = userRepository;
        }

        public async Task<UsuarioDto> GetAsync(int id)
        {
            var user = await _userRepository.GetAsync(id, p => p.Include(d => d.UsuarioRol));
            return _mapper.Map<UsuarioDto>(user);
        }

        public async Task<IEnumerable<OptionDto>> Search(string term)
        {
            var response = await _userRepository.Search(term)
                                        .ProjectTo<OptionDto>(_mapper.ConfigurationProvider)
                                        .ToListAsync();



            return response;
        }

        public async Task<IEnumerable<UsuarioDto>> SearchByMail(string term)
        {
            var response = await _userRepository.Search(term)
                                        .ProjectTo<UsuarioDto>(_mapper.ConfigurationProvider)
                                        .ToListAsync();

            return response;
        }

        public async Task<PaginationResultDto<UsuarioPaginationDto>> PaginateAsync(int pageIndex, int pageSize, string name, int? idRol, int? idEmpresa)
        {
            var paginationResult = await _userRepository.PaginateAsync(pageIndex, pageSize, name, idRol, idEmpresa);
            var data = await paginationResult.Entities
                                                .AsQueryable()
                                                .ProjectTo<UsuarioPaginationDto>(_mapper.ConfigurationProvider)
                                                .ToListAsync();

            return new PaginationResultDto<UsuarioPaginationDto>
            {
                Count = paginationResult.Count,
                Entities = data
            };
        }

        public async Task<UsuarioDto> CreateAsync(UsuarioDto userDto)
        {
            return null;
        }

        public async Task<UsuarioDto> UpdateAsync(UsuarioDto userDto)
        {
            var exist = await _userRepository.Search(userDto.Email).ToListAsync();

            if (exist.Where(x => x.Id != userDto.Id).ToList().Count > 0)
            {
                throw new ValidationException($"{userDto.Email} ya está regiastrado");
            }

            _unitOfWork.BeginTransaction();

            var user = await _userRepository.GetAsync(userDto.Id, p => p.Include(d => d.UsuarioRol));
            var clave = user.Clave;
            var UsuarioRoles = user.UsuarioRol.FirstOrDefault();
            userDto.UsuarioRoles = new List<UsuarioRolDto>() { new UsuarioRolDto { Id = UsuarioRoles.Id, IdRol = UsuarioRoles.IdRol } };
            user = _mapper.Map(userDto, user);
            user.Clave = clave;
            _userRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();

            var result = string.Join(",", userDto.UsuarioRoles.Select(x => x.IdRol));
            await _userRepository.InsertPermisosAsync(user.Id, result);
            return _mapper.Map(user, userDto);
        }

        public async Task DeleteAsync(int id)
        {
            _unitOfWork.BeginTransaction();

            var user = await _userRepository.GetAsync(id);
            user.Estado = false;
            user.Vigencia = false;
            _userRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateStateAsync(int id, StateDto state)
        {
            _unitOfWork.BeginTransaction();

            var userDomain = await _userRepository.GetAsync(id);
            userDomain.Estado = state.State;

            _userRepository.Update(userDomain);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<UsuarioPushTokenDto> SaveUsuarioPushTokenAsync(UsuarioPushTokenDto model)
        {
            var token = _mapper.Map<UsuarioPushTokenDto, UsuarioPushToken>(model);
            var response = await _userRepository.SaveUsuarioPushTokenAsync(token);
            var reponseData = _mapper.Map(response, model);
            return reponseData;
        }

        public async Task<ICollection<UsuarioPushTokenDto>> GetUsuarioPushTokenAsync(PushTokenDto request)
        {
            var model = new UsuarioPushTokenDto()
            {
                IdUsuario = request.IdUsuario,
                IdRol = request.IdRol,
                IdEmpresa = request.IdEmpresa
            };
            var token = _mapper.Map<UsuarioPushTokenDto, UsuarioPushToken>(model);
            var response = await _userRepository.GetUsuarioPushTokenAsync(token);
            var datas = _mapper.Map<ICollection<UsuarioPushTokenDto>>(response);

            string vapidPublicKey = @"BLyyk2pnqnLyxPmFD8wo79VSNhGabkn_ROfEjM_ghCiqYPPuKkMqVY9_CxDF5W1-LI6fn8fD1_23t20IdK2S2ew";
            string vapidPrivateKey = @"yBKNSt22FBXWAHn4Hu7wfODpLLe86jlJPKlRoSPVdc0";

            Parallel.ForEach(datas, async p =>
            {
                try
                {
                    List<dynamic> actions = new List<dynamic>();

                    dynamic opctions = new
                    {
                        notification = new
                        {
                            title = "Pardo APP",
                            body = string.IsNullOrEmpty(request.Mensaje) ? "Pedido generado" : request.Mensaje,
                            icon = "https://admin.find-all.com.pe/assets/images/logo-text.png",
                            vibrate = "[500,110,500,110,450,110,200,110,170,40,450,110,200,110,170,40,500]",
                            badge = "https://i.imgur.com/9QFB20F.png",
                            click_action = "https://www.google.com",
                            renotify = true,
                            tag = "request",
                            data = new
                            {
                                url = string.IsNullOrEmpty(request.ActionUrl) ? $"{p.Domain}/#/auth/login" : request.ActionUrl
                            },
                            actions = actions,
                            webpush = new
                            {
                                fcm_options = new
                                {
                                    link = "https://dummypage.com"
                                }
                            }
                        }
                    };

                    var payload = JsonConvert.SerializeObject(opctions);

                    var deviceCurrent = JsonConvert.DeserializeObject<TokenPush>(p.Device);

                    var pushSubscription = new PushSubscription(deviceCurrent.endpoint, deviceCurrent.keys.p256dh, deviceCurrent.keys.auth);
                    var vapidDetails = new VapidDetails("mailto:example@example.com", vapidPublicKey, vapidPrivateKey);

                    var webPushClient = new WebPushClient();
                    await webPushClient.SendNotificationAsync(pushSubscription, payload, vapidDetails);
                }
                catch (Exception ex) { }
            });


            return datas;
        }

    }
}
