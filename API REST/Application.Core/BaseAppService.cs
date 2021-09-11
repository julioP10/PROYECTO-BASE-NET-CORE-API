using AutoMapper;
using Domain.Core.Interfaces.UoW;
using Infraestructure.Crosscutting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System;
using System.Linq;

namespace Application.Core
{
    public class BaseAppService
    {
        protected readonly IStringLocalizer<ValidationResource> _localizer;
        protected readonly IMapper _mapper;
        protected readonly IServiceProvider _serviceProvider;
        protected readonly IUnitOfWork _unitOfWork;

        public BaseAppService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            _unitOfWork = serviceProvider.GetService<IUnitOfWork>();
            _mapper = serviceProvider.GetService<IMapper>();
            _localizer = serviceProvider.GetService<IStringLocalizer<ValidationResource>>();

            var httpContextAccessor = serviceProvider.GetService<IHttpContextAccessor>();

            if (httpContextAccessor.HttpContext != null && httpContextAccessor.HttpContext.User.Claims.Any())
            {
                CurrentUser = httpContextAccessor.HttpContext.User.Claims?.ElementAt(0).Value;
                try
                {
                    CurrentUserId = int.Parse(httpContextAccessor.HttpContext.User.Claims?.ElementAt(4).Value);
                }
                catch (Exception ex)
                {

                    CurrentUserId = 0;
                }
            }
        }

        public string CurrentUser { get; }
        public int CurrentUserId { get; set; }
    }
}