using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Retry;
using System.Net;

namespace UiBlazor.Helpers
{
    public class CustomHttpMessageHandler : DelegatingHandler
    {
        private readonly AsyncRetryPolicy<HttpResponseMessage> _policy;

        private AuthenticationStateProvider _authenticationStateProvider;
        private NavigationManager _navigationManager;


        public CustomHttpMessageHandler()
        {
            InnerHandler = new HttpClientHandler();

            _policy = Policy
               .HandleResult<HttpResponseMessage>(r => r.StatusCode is HttpStatusCode.Unauthorized or HttpStatusCode.Forbidden)
               .RetryAsync(RetryAsync);
        }
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return await _policy.ExecuteAsync(async _ =>
            {
                //request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await _tokenProvider.GetAccessTokenAsync(myRealUserId));
                var x = await base.SendAsync(request, cancellationToken);
                return x;
            }, new Dictionary<string,object>());
            //return await base.SendAsync(request, cancellationToken);
        }

        public async Task RetryAsync(DelegateResult<HttpResponseMessage> delegateResult, int code, Context context)
        {
            //_authService ??= App.AppHost.Services.GetRequiredService<IAuthService>();
            //_signingCredentials ??= App.AppHost.Services.GetRequiredService<ISigningCredentialsManagementService>();
            //_logger ??= App..GetRequiredService<ILogger<CustomHttpMessageHandler>>();

            try
            {
                IServiceScope serviceScope = null;
                if (_authenticationStateProvider is null)
                {
                    serviceScope = Application.App.Services.CreateScope();
                    _authenticationStateProvider = serviceScope.ServiceProvider.GetRequiredService<AuthenticationStateProvider>();
                }

                var state = await _authenticationStateProvider.GetAuthenticationStateAsync();

                if (!(bool)state.User.Identity?.IsAuthenticated)
                {
                    if (_navigationManager is null)
                    {
                        serviceScope ??= Application.App.Services.CreateScope();
                        _navigationManager = serviceScope.ServiceProvider.GetRequiredService<NavigationManager>();
                    }
                    _navigationManager.NavigateTo("login?returnUrl=" + _navigationManager.ToBaseRelativePath(_navigationManager.Uri));
                }
            }
            catch (Exception e)
            {

            }
        }
    }
}
