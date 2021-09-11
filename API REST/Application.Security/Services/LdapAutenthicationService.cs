using Application.Security.ActiveDirectory;
using Application.Security.Core;
using Application.Security.Interfaces;
using Infraestructure.Crosscutting.Enums;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Novell.Directory.Ldap;
using System;
using System.Threading.Tasks;

namespace Application.Security.Services
{
    public class LdapAutenthicationService : IAutenthicationService
    {
        private const string MemberOfAttribute = "memberOf";
        private const string DisplayNameAttribute = "displayName";
        private const string SAMAccountNameAttribute = "sAMAccountName";

        private readonly LdapConnection _ldapConnection;
        private readonly LdapConfig _config;

        public LdapAutenthicationService(IServiceProvider serviceProvider)
        {
            _ldapConnection = new LdapConnection();
            _config = serviceProvider.GetService<IOptions<LdapConfig>>().Value;
        }

        public async Task<UserApp> Login(string username, string password)
        {
            _ldapConnection.Connect(_config.Url, LdapConnection.DEFAULT_PORT);
            _ldapConnection.Bind(_config.BindDn, _config.BindCredentials);

            var searchFilter = string.Format("(&(objectClass=user)(objectClass=person)(sAMAccountName={0}))", username);
            var result = _ldapConnection.Search(
                _config.SearchBase,
                LdapConnection.SCOPE_SUB,
                searchFilter,
                new[] { MemberOfAttribute, DisplayNameAttribute, SAMAccountNameAttribute },
                false
            );

            var user = result.Next();
            if (user != null)
            {
                _ldapConnection.Bind(user.DN, password);
                if (_ldapConnection.Bound)
                {
                    return await Task.FromResult(new UserApp
                    {
                        NombreUsuario = user.getAttribute(SAMAccountNameAttribute).StringValue,
                        ModoAutenticacion = (int)AuthenticationType.ActiveDirectory
                    });
                }
            }

            _ldapConnection.Disconnect();
            return null;
        }
    }
}
