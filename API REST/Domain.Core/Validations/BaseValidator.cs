using FluentValidation;
using Infraestructure.Crosscutting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System;

namespace Domain.Core.Validations
{
    public class BaseValidator<TEntity> : AbstractValidator<TEntity>
    {
        protected readonly IStringLocalizer<ValidationResource> _localizer;

        public BaseValidator(IServiceProvider serviceProvider)
        {
            _localizer = serviceProvider.GetService<IStringLocalizer<ValidationResource>>();
        }
    }
}