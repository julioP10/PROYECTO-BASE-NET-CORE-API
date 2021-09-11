using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ServiceConfigs
{
    public static class SecurityService
    {
        public static async Task<bool> AnalizerAsync(this HttpRequest request)
        {
            return await Task<bool>.Factory.StartNew(() =>
            {
                return true;
            });
        }
    }
}
