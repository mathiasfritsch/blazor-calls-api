using System;
using System.Net.Http;
using System.Threading.Tasks;
using blazorwasm_calls_MS_graph.Data;
using blazorwasm_calls_MS_graph.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Graph;

namespace blazorwasm_calls_MS_graph
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
        
            // Adds the Microsoft graph client (Graph SDK) support for this app. 
            builder.Services.AddMicrosoftGraphClient("https://graph.microsoft.com/User.Read");

            // Integrates authentication with the MSAL library
            builder.Services.AddMsalAuthentication(options =>
            {
                builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
                options.ProviderOptions.DefaultAccessTokenScopes.Add("https://graph.microsoft.com/User.Read");
            });

            builder.Services.AddHttpClient<ITestDataService, TestDataService>(
              client => client.BaseAddress = new Uri("https://localhost:44342/"))
                .AddHttpMessageHandler(x =>
                {
                    var handler = x.GetRequiredService<AuthorizationMessageHandler>()
                        .ConfigureHandler(new[] { "https://localhost:44342/" },
                            scopes: new[] { "https://graph.microsoft.com/User.Read" });

                    return handler;
                });


            await builder.Build().RunAsync();
        }
    }
}
