using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blazorwasm_calls_MS_graph
{
    public class PersonApiAuthorizationMessageHandler : AuthorizationMessageHandler
    {
        public PersonApiAuthorizationMessageHandler(
           IAccessTokenProvider provider, NavigationManager navigation)
           : base(provider, navigation)
        {
            ConfigureHandler(
                  authorizedUrls: new[] { "https://localhost:44342/" });
        }
    }
}
